using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //GameManager instance = GameManager.Instance;
   
    /*[Header("Variables de Recursos", order = 0)]
    public int maxGold;
    [HideInInspector]
    public int actualGold = 5;
    public float goldTime; //CUANTO TIEMPO TARDA EN GENERAR ORO
    public int goldGeneration; //CUANTO ORO GENERA

    [Header("Prefabs de Unidades", order =1)] //LOS PREFABS DE TODAS LAS UNIDADS  //SE PUEDE USAR UN ARREGLO PARA NO TENER TANTAS VARIABLES
    public GameObject meleePref;
    public GameObject rangePref;
    public GameObject kamikazePref;
    public GameObject tankPref;
    public GameObject bomberPref;
    public GameObject cannonPref;
    public GameObject minerPref;
    public GameObject generalPref;

    [Header("Maximo de Unidades", order =2)]
    public int maxMeles;
    private int actualMelees; //MAXIMO DE UNIDADES POR TIPO Y EL NUMERO ACTUAL DE CADA TIPO DE UNIDAD
    private int actualRanges;
    public int maxRanges;
    private int actualKamikazes;
    public int maxKamikazes;
    private int actualTanks;
    public int maxTanks;
    private int actualBombers;
    public int maxBombers;
    private int actualCannons;
    public int maxCannons;
    private int actualMiners;
    public int maxMiners;
    private int actualGenerals;
    public int maxGenerals;

    [Header("Base Principal", order = 3)]
    public Tower myBase;

    private GameManager manager;
    */

    [SerializeField]
    Tower tower;

    private void Awake()
    {
        tower.actualGold = tower.maxGold;
        //ES MEJOR USAR EL SINGLETON YA QUE SOLO EXISTIRA UN GAME MANAGAER EN TODO EL JUEGO, IGUAL APLICA PARA TODOS LOS MANAGERS QUE TIENES PENSADOS
    }

    private void Start()
    {
        //StartCoroutine(MiningGold(goldTime));
    }

    #region Gold Functions

    //GENERAMOS X CANTIDAD DE ORO CADA X SEGUNDOS
    /*private IEnumerator MiningGold(float time)
    {
        while (manager.actualState == GameState.PLAYING)
        {
            yield return new WaitForSeconds(time);
            actualGold = AddGold(goldGeneration);
        }
    }

    //RESTAMOS EL COSTO A LA CANTIDAD ACTUAL DE ORO
    private int RestGold(int cost)
    {
        if (actualGold > 0 && actualGold >= cost)
        {
            actualGold -= cost;
        }

        return actualGold;
    }

    //SUMAMOS EL VALOR A LA CANTIDAD ACTUAL DE ORO
    private int AddGold(int value)
    {
        if (actualGold < maxGold)
        {
            actualGold += value;
        }

        return actualGold;
    }

    #endregion

    #region Instanciate Units
    //INSTANCIAMOS LAS UNIDADES EN UNA POSICION Y AGREGAMOS LA UNIDAD AL CONTADOR ACTUAL
    public void GenMelee(Vector3 pos)
    {
        if(actualMelees < maxMeles)
        {
            Instantiate(meleePref, pos, Quaternion.identity);
            actualMelees += 1;
        }
    }

    public void GenRange(Vector3 pos)
    {
        if (actualRanges < maxRanges)
        {
            Instantiate(rangePref, pos, Quaternion.identity);
            actualRanges += 1;
        }
    }

    public void GenKamikaze(Vector3 pos)
    {
        if (actualKamikazes < maxKamikazes)
        {
            Instantiate(kamikazePref, pos, Quaternion.identity);
            actualKamikazes += 1;
        }
    }

    public void GenTank(Vector3 pos)
    {
        if (actualTanks < maxTanks)
        {
            Instantiate(tankPref, pos, Quaternion.identity);
            actualTanks += 1;
        }
    }

    public void GenBomber(Vector3 pos)
    {
        if (actualBombers < maxBombers)
        {
            Instantiate(bomberPref, pos, Quaternion.identity);
            actualBombers += 1;
        }
    }

    public void GenCannon(Vector3 pos)
    {
        if (actualCannons < maxCannons)
        {
            Instantiate(cannonPref, pos, Quaternion.identity);
            actualCannons += 1;
        }
    }

    public void GenMiner(Vector3 pos)
    {
        if (actualMiners < maxMiners)
        {
            Instantiate(minerPref, pos, Quaternion.identity);
            actualMiners += 1;
        }
    }

    public void GenGeneral(Vector3 pos)
    {
        if (actualGenerals < maxGenerals)
        {
            Instantiate(generalPref, pos, Quaternion.identity);
            actualGenerals += 1;
        }
    }
    */
    #endregion

}
