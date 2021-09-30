using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxGold;
    [SerializeField] int maxUnits;
    [SerializeField] List<int> limitOfUnits; //Limitante de las unidades segun su tipo en el enum  BARBARO,ARQUERA,KAMIKAZE,PIPILA,CANON,BOMBARDERO,LADRON,MINERO,GENERAL,

    [SerializeField] List<int> actualxUnits;
    int actualUnits;
    float actualGold;
    
    

    [SerializeField] List<Transform> spawnPoints;
    
    bool canSpawn;

    private void Start()
    {

        Debug.Log(limitOfUnits.Count);
        actualxUnits = new List<int>();

        for (int i = 0; i < limitOfUnits.Count; i++) actualxUnits.Add(0);
    }
    public void SpawnUnit(GameObject unitToSpawn)
    {
        if (actualUnits < maxUnits)
        {
            Unit u = unitToSpawn.GetComponent<Unit>();

            var currentEvent = EventSystem.current;

            if (currentEvent == null)
                return;

            var goSelected = currentEvent.currentSelectedGameObject.GetComponent<Button>();

            if (goSelected == null)
                return;

            goSelected.interactable = false;

            if (actualxUnits[(int)u.myType] < limitOfUnits[(int)u.myType])
            {
                actualUnits++;

                actualxUnits[(int)u.myType]++;

                goSelected.interactable = true;

                Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)];
           
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
