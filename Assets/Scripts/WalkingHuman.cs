using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingHuman : MonoBehaviour
{
    public float walkingSpeed = 5;
    
    Rigidbody playerRigidbody;
    
    Vector3 movement;


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");
        Move(h, v);

    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * walkingSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }


}
