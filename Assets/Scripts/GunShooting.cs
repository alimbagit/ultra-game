using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public int damage = 15;
    public float shooting_speed = 30;
    public string button_attack = "Fire1";

    private float timer=0;
    private float real_speed;
    private void Awake()
    {
        CorrrectSpeedAttack(0);
    }

    
    void FixedUpdate()
    {

        if(timer<real_speed) timer += Time.deltaTime;
        if (Input.GetButton(button_attack))
        {
            timer += Time.deltaTime;
            if (timer >= real_speed)
            {
                Shooting();
                timer = 0;
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    }

    public RaycastHit Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow,3f);
            hit.transform.gameObject.SendMessage( "DamageHealth", damage, SendMessageOptions.DontRequireReceiver);
        }

        return hit;
    }

    public void CorrrectSpeedAttack(float _speed)
    {
        shooting_speed += _speed;
        real_speed = (1500 - shooting_speed) / 1000;
    }
}
