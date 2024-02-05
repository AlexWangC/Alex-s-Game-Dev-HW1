using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    public float speedForward;
    public float speedBackward;
    private bool isHitting;
    private bool isMoving;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speedForward * Time.deltaTime, 0, 0);
            isMoving = true;
            isHitting = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speedBackward * Time.deltaTime, 0, 0);
            isMoving = true;
            isHitting = false;
        }

    }
}
