using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PLAYING,
    PLAYERWIN,
    AIWIN,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

     public GameState actualState;
     public PlayerManager player;
     public IAManager intel;
 

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
