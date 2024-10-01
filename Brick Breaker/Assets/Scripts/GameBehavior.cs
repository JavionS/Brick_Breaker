using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    [SerializeField] private Player _player;
    
    private void Awake()
    {
        // If a duplicate tries to be create, this logic will prevent it from being created.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // The first time around, this will run
            Instance = this;
            
            // Uncomment this line for level based games
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Start()
    {
            _player.Score = 100;
    }
}
