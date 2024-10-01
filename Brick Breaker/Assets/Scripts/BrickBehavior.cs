using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
        
    }

}
