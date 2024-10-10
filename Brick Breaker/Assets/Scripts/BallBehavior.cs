using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    public float Y_limit = 4.75f;
    public float X_limit = 5.25f;

    private Vector2 _direction;

    public GameObject Paddle;
    
    private AudioSource _source;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _scorePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Paddle = GameObject.Find("Paddle");
        ResetBall();
        
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            
            transform.position += new Vector3(
                _speed * _direction.x,
                _speed * _direction.y,
                0.0f) * Time.deltaTime;
        
            if (transform.position.y >= Y_limit)
            {
                transform.position = new Vector3(
                    transform.position.x, 
                    (Y_limit - 0.01f) * Mathf.Sign(transform.position.y), 
                    0);
                
                _direction.y *= -1;
                _source.pitch = Random.Range(0.75f, 1.25f);
                _source.PlayOneShot(_wallHit);
            }
                
            if (transform.position.y <= -Y_limit)
            {
                ResetBall();
            }
        
            if (Mathf.Abs(transform.position.x) >= X_limit)
            {
                _direction.x *= -1;
                _source.pitch = Random.Range(0.75f, 1.25f);
                _source.PlayOneShot(_wallHit);
            }
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Paddle"))
        {
            _speed *= GameBehavior.Instance.BallSpeedIncrement;
            _direction.y *= -1;
            
            _source.pitch = Random.Range(0.75f, 1.25f);
            _source.PlayOneShot(_paddleHit);
        }
        
        if (other.transform.CompareTag("Brick"))
        {
            GameBehavior.Instance.ScorePoint();
            _source.pitch = 1.0f;
            _source.PlayOneShot(_scorePoint);
            
            float xDistance = Mathf.Abs(transform.position.x - other.transform.position.x);
            float yDistance = Mathf.Abs(transform.position.y - other.transform.position.y);
            
            
            if (xDistance > yDistance)
            {
                _direction *= new Vector2(-1, -1);
            }
            else
            {
                _direction *= new Vector2(1, -1);
            }
            
            
            
        }
    }
    void ResetBall()
    {
        transform.position = new Vector3(Paddle.transform.position.x, -3.71f, 0);
            
        _direction = new Vector2(
            Random.value > 0.5f ? 1 : -1, 
            1);
        
        _speed = GameBehavior.Instance.InitBallSpeed;
    }
}
