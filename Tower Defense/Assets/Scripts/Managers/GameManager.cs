using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    //START,
    PLAYING,
    PLAYERWIN,
    AIWIN,
}
public class GameManager : MonoBehaviour
{
    //EN ESTE SCRIPT SOLO ES EL ARBRITO Y EL QUE DA LAS PAUTAS(ESTADOS) PARA QUE EL RESTO DE SCRIPTS HAGAN LO SUYO XD
    public PlayerManager player;
    public IAManager intel;

    public GameState actualState;

    //HAY QUE CHECAR EL ESTADO DE LAS TORRES DE LA IA Y DEL JUGADOR PARA CAMBIAR DE ESTADO

/*    private static GameManager _instance;

    public GameObject towerAI;
    public GameObject towerPlayer;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject instance = new GameObject("Game Manager");
                instance.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;

        if (_instance != null)
            DontDestroyOnLoad(this);

    }/*/
}
