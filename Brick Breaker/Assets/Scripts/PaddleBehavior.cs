using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;
    public float X_Limit = 4.35f;

    public KeyCode LKey;
    public KeyCode RKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(LKey) && transform.position.x > -X_Limit)
        {
            transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);   
        };        
        if (Input.GetKey(RKey) && transform.position.x < X_Limit)
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);   
        };
    }
}
