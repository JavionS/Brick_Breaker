using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallBehavior : MonoBehaviour
{
    public float Speed = 3.0f;
    public float Y_limit = 4.75f;
    public float X_limit = 5.25f;

    private Vector2 _direction;

    public GameObject Paddle;
    
    // Start is called before the first frame update
    void Start()
    {
        Paddle = GameObject.Find("Paddle");
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Speed * _direction.x,
            Speed * _direction.y,
            0.0f) * Time.deltaTime;
        
        if (transform.position.y >= Y_limit)
        {
            _direction.y *= -1;
        }
                
        if (transform.position.y <= -Y_limit)
        {
            ResetBall();
        }
        
        if (Mathf.Abs(transform.position.x) >= X_limit)
        {
            _direction.x *= -1;
        }
    }
    
    void ResetBall()
    {
        transform.position = new Vector3(Paddle.transform.position.x, -3.72f, 0);
            
        _direction = new Vector2(
            Random.value > 0.5f ? 1 : -1, 
            1);
    }
}
