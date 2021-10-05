using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public struct Tower
{
    public float health;
    public float maxGold;
    public int maxUnits;
    public List<int> limitOfUnits;
    public List<int> actualxUnits;
    public List<Transform> spawnPoints;
    public int actualUnits;
    public float actualGold;
    public bool canSpawn;
}
public class Player : MonoBehaviour
{

    public Tower tower;
    /*
    [SerializeField] float health;
    [SerializeField] float maxGold;
    [SerializeField] int maxUnits;
    [SerializeField] List<int> limitOfUnits; //Limitante de las unidades segun su tipo en el enum  BARBARO,ARQUERA,KAMIKAZE,PIPILA,CANON,BOMBARDERO,LADRON,MINERO,GENERAL,

    [SerializeField] List<int> actualxUnits;
    int actualUnits;
    float actualGold;
    
    

    [SerializeField] List<Transform> spawnPoints;
    
    bool canSpawn;
    */

    private void Start()
    {

        Debug.Log(tower.limitOfUnits.Count);
        tower.actualxUnits = new List<int>();

        for (int i = 0; i < tower.limitOfUnits.Count; i++) tower.actualxUnits.Add(0);
    }
    public void SpawnUnit(GameObject unitToSpawn)
    {
        if (tower.actualUnits < tower.maxUnits)
        {
            Unit u = unitToSpawn.GetComponent<Unit>();

            var currentEvent = EventSystem.current;

            if (currentEvent == null)
                return;

            var goSelected = currentEvent.currentSelectedGameObject.GetComponent<Button>();

            if (goSelected == null)
                return;

            goSelected.interactable = false;

            if (tower.actualxUnits[(int)u.myType] < tower.limitOfUnits[(int)u.myType])
            {
                tower.actualUnits++;

                tower.actualxUnits[(int)u.myType]++;

                goSelected.interactable = true;

                Transform randomSpawn = tower.spawnPoints[Random.Range(0, tower.spawnPoints.Count)];
           
                u.isPlayer = true;

                Instantiate(unitToSpawn, randomSpawn.position, Quaternion.identity);
            }
            else
            {
                goSelected.interactable = false;
            }
        }
       
    }


}
