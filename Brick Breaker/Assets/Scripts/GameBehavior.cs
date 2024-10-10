using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 1.2f;
    
    [SerializeField] private Player _player;

    public Utilities.GameplayState State = Utilities.GameplayState.Play;
    
    [SerializeField] private TextMeshProUGUI _messages;
    
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
            ResetGame();
            _messages.enabled = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchState();
        }
    }
    
    private void SwitchState()
    {
        if (State == Utilities.GameplayState.Play)
        {
            State = Utilities.GameplayState.Pause;
            _messages.text = "Pause";
            _messages.enabled = true;
        }
        else
        {
            State = Utilities.GameplayState.Play;
            _messages.enabled = false;
        }
    }
    
    public void ScorePoint()
    {
        _player.Score += 1;
        Win();
        
    }

    private void Win()
    {
        if (_player.Score >= 10)
        {
            _messages.text = "Win!";
            _messages.enabled = true;
        }
    }
    void ResetGame()
    {

        _player.Score = 0;
    }
}
