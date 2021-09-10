using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState
{
    START,
    PLAYERWIN,
    AIWIN,
}
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

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

    }
}
