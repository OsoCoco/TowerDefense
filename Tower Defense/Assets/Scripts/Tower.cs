using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tower
{
    [Header("Tower Variables", order = 0)]
    public int HP;
    public int attackDamage;
    public int maxGold;
    public int maxAgents;
    public int goldPerRate;
    public float attackRate;
    public float attackRange;
    public float miningRate;

    public int actualGold;
    //public float rangePerception;

    [Header("Lista de Agentes", order = 1)]
    public GameObject[] agentsToSpawn;

    [Header("Manejo Unidades", order = 2)]
    public int maxMelees;
    public int maxRanges;
    public int maxKamikazes;
    public int maxTanks;
    public int maxBombers;
    public int maxCannons;
    public int maxGenerals;
    public int maxMiners;

    int actualMelees;
    int actualRanges;
    int actualKamikazes;
    int actualTanks;
    int actualBombers;
    int actualCannons;
    int actualGenerals;
    int actualMiners;
    int actualAgents;

    [Header("Spawn", order = 3)]
    public Transform[] spwanPoints;

    //public GameManager manager; //GameManager.Instance;

    
    //string tagName;

    /* 
     [Header("Colliders", order = 4)]
     public CircleCollider2D perception;
     public CircleCollider2D range;

     [Header("Tower Targets", order = 5)]
     public Unit actualTarget;
     public List<Unit> targets;

     [Header("Units Spawn Points", order = 6)]
     public Transform[] mineSpawnPoints;
     public Transform[] unitsSpawnPoints;

     [Header("")]
    */
    //IMPORTANTEEEEEEEEEEE AGREGAR IDENTIFICADOR SI PERTENECEN AL JUGADOR O LA IA Y CUALES SON SUS ENEMIGOS, ESTE SCRIPT SOLO SERVIRA PARA LA BASE (OSEA ATACAR UNIDADES Y PARA CAMBIAR EL ESTADO DEL JUEGO EN CASO DE QUE SU VIDA LLEGE A 0)
    //ATACA A LA UNIDAD CON MENOR VIDA


    public void Attack() //SE HARA UNA FUNCION BOOL QUE DETERMINE SI TIENE ALGO QUE ATACAR
    {
        
    }

    public GameObject AgentToSpawn(GameObject objectToSpawn)
    {
        GameObject temp = objectToSpawn;
        string tagName = temp.tag;
        if (actualAgents < maxAgents || actualGold < maxGold)
        {
            switch (tagName)
            {
                case "Melee":
                    if (actualMelees < maxMelees)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualMelees++;
                        //Instantiate(objectToSpawn,spawnPoint.position,Quaternion.identity);
                        //return temp;
                    }
                    break;
                case "Range":
                    if (actualRanges < maxRanges)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualRanges++;
                        //Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                    }
                    break;
                case "Kamikaze":
                    if (actualKamikazes < maxKamikazes)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualKamikazes++;
                        //Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                    }
                    break;
                case "Tank":
                    if (actualTanks < maxTanks)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualTanks++;
                        //Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                    }
                    break;
                case "Bomber":
                    if (actualBombers < maxBombers)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualBombers++;
                        //Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                    }
                    break;
                case "Cannon":
                    if (actualCannons < maxCannons)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualCannons++;
                        //Instantiate(objectToSpawn,spawnPoint.position, Quaternion.identity);
                    }
                    break;
                case "General":
                    if (actualGenerals < maxGenerals)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualGenerals++;
                        //Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                    }
                    break;
                case "Miner":
                    if (actualMiners < maxMiners)
                    {
                        actualGold -= objectToSpawn.GetComponent<Unit>().cost;
                        actualMiners++;
                        //Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                    }
                    break;
                default:
                    temp = null;
                    break;
            }

            actualAgents++;
        }
        else
            temp = null;
      
        return temp;
    }

    public GameObject RandomAgent(GameObject[] listOfAgents)
    {
        return listOfAgents[Random.Range(0,listOfAgents.Length)];
    }

    public Transform RandomSpawnPoint(Transform[] listOfSpawns)
    {
        return listOfSpawns[Random.Range(0, listOfSpawns.Length)];
    }

    
    public IEnumerator MiningGold(float time)
    {
        while (GameManager.Instance.actualState == GameState.PLAYING)
        {
            yield return new WaitForSeconds(time);
            actualGold = AddGold(goldPerRate);
        }
    }

    private int AddGold(int value)
    {
        if (actualGold < maxGold)
        {
            actualGold += value;
        }

        return actualGold;
    }

    /*
    public GameObject[] agentsToSpawn;

    public float life;
    public float attackRange, attackDamage;
    public float attackRate;

    public int recursos;
    public float spawnRate;
    float nextAgent;
    public int agentLimit;


    [SerializeField] int actualAgents;

    float nextAttack;
    public LayerMask mask;

    public Collider2D[] enemies;
    List<int> prio;
    
    public Agent target;
    //public Agent agentToAttack;

    private void Update()
    {
       enemies = Physics2D.OverlapCircleAll(transform.position,attackRange,mask);
       target = ObjectToAttack(enemies);

        if(target != null && Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            //Attack(target);
        }

       if(recursos > 0 && actualAgents < agentLimit && Time.time > nextAgent)
       {
            nextAgent = Time.time + spawnRate;
            //SpawnAgent();
            actualAgents++;
       }
      

    }

    Agent ObjectToAttack(Collider2D[] col)
    {
        Agent objectToAttack;

        if (col != null)
        {
            prio = new List<int>();

            for (int i = 0; i < col.Length; i++)
            {
                prio.Add(col[i].GetComponent<Agent>().priority);
            }

            if (prio.Count != 0)
            {
                int maxPrio = prio.Max();

                Debug.Log("Max Prio " + maxPrio);

                int index = prio.IndexOf(maxPrio);
                Debug.Log("Index " + index);

                objectToAttack = col[index].gameObject.GetComponent<Agent>();
            }
            else
                objectToAttack = null;
        }
        else
            objectToAttack = null;

        if(objectToAttack != null)
        {
            if (objectToAttack.isPlayer)
                return objectToAttack;
            else
                return null;
        }
        else
            return null;
    }
    
    /*void Attack(Agent t)
    {
      if(t != null)  
        t.life -= attackDamage;
      
    }*/

    /*void SpawnAgent()
    {
        GameObject temp = agentsToSpawn[Random.Range(0, agentsToSpawn.Length)];

        Agent agenTemp = temp.GetComponent<Agent>();

        recursos -= agenTemp.costo;
        agenTemp.isPlayer = false;
        
        Instantiate(temp, transform.position, Quaternion.identity);
    }*/

    //return agentsToSpawn[Random.Range(0, agentsToSpawn.Length)];
}


