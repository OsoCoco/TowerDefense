using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* enum SpawnPoints 
{ UP, DOWN}*/
public class CardsManager : MonoBehaviour
{
    [Header("Controlador del Jugador")]
    public PlayerManager player;

    public void SpawnUnit(GameObject objectToSpawn)
    {
        player.SpwanAgent(objectToSpawn, player.RandomSpawnPoint(player.spwanPoints));
    }
    //[Header("Spawn Points")]
    //[SerializeField]
    //private SpawnPoints spawn;
    //public Transform upSpawn; 
    //public Transform downSpawn;

    /*
    [Header("Cannon SpawnPoints")]
    public Transform upCannon;
    public Transform downCannon;

    [Header("Other SpawnPoints")]
    public Transform minerSpawn;
    public Transform generalSpawn;
    */

    //CAMBIAMOS EL SPAWNPOINT DE LAS UNIDADES DEL JUGADOR
    /*public void GoUp()
    {
        if (spawn != SpawnPoints.UP)
        {
            spawn = SpawnPoints.UP;
        }
    }

    public void GoDown()
    {
        if (spawn != SpawnPoints.DOWN)
        {
            spawn = SpawnPoints.DOWN;
        }
    }
    */
    //INSTANCIAR A LAS UNIDADES (PREFABS)
    #region Spawn Units
    /*
    public void SpawnMelee()
    {
        if (spawn == SpawnPoints.UP)
        {
            player.GenMelee(upSpawn.position);
        }
        else if (spawn == SpawnPoints.DOWN)
        {
            player.GenMelee(downSpawn.position);
        }
    }

    public void SpawnRange()
    {
        if (spawn == SpawnPoints.UP)
        {
            player.GenRange(upSpawn.position);
        }
        else if (spawn == SpawnPoints.DOWN)
        {
            player.GenRange(downSpawn.position);
        }
    }

    public void SpawnKamikaze()
    {
        if (spawn == SpawnPoints.UP)
        {
            player.GenKamikaze(upSpawn.position);
        }
        else if (spawn == SpawnPoints.DOWN)
        {
            player.GenKamikaze(downSpawn.position);
        }
    }

    public void SpawnTank()
    {
        if (spawn == SpawnPoints.UP)
        {
            player.GenTank(upSpawn.position);
        }
        else if (spawn == SpawnPoints.DOWN)
        {
            player.GenTank(downSpawn.position);
        }
    }

    public void SpawnBomber()
    {
        if (spawn == SpawnPoints.UP)
        {
            player.GenBomber(upSpawn.position);
        }
        else if (spawn == SpawnPoints.DOWN)
        {
            player.GenBomber(downSpawn.position);
        }
    }

    //NECESITAN SPWAN POINTS DIFERENTES
    public void SpawnCannon()
    {
        if (spawn == SpawnPoints.UP)
        {
            player.GenCannon(upCannon.position);
        }
        else if (spawn == SpawnPoints.DOWN)
        {
            player.GenCannon(downCannon.position);
        }
    }

    public void SpawnMiner()
    {
        player.GenMiner(minerSpawn.position);
    }

    public void SpawnGeneral()
    {
        player.GenGeneral(generalSpawn.position);
    }
    */
    #endregion
}
