using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _score = 0;

    
    public int Score
    {
        // This notation is replacement to retuning the _score value
        get => _score;
        
        set
        {
            // Update value of backing variable
            _score = value;
            
            // Use getter property to upadate the GUI
            _scoreGUI.text = Score.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreGUI;
}
