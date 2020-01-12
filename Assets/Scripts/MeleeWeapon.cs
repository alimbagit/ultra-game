using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damage = 10;
    public float attack_speed = 100;
    public string button_attack = "Fire2";
    public float attack_range = 3f;

    private float timer = 0;
    private float real_speed;
    private bool isAttack = false;
    private void Awake()
    {
        CorrrectSpeedAttack(0);
    }

    void FixedUpdate()
    {
        if (isAttack) {
            timer += Time.deltaTime;
            if (timer >= real_speed)
            {
                Attack();
                timer = 0;
                isAttack = false;
            }
        }

        if (Input.GetButtonDown(button_attack)) isAttack=true;
    }

    void Attack()
    {
        Collider[] hits= Physics.OverlapSphere(transform.position, attack_range);
        foreach (Collider hit in hits)
        {
            if (transform.parent.tag != hit.transform.tag)
            {
                Vector3 direction = hit.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.65)
                {
                    hit.gameObject.SendMessage("DamageHealth", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
    public void CorrrectSpeedAttack(float _speed)
    {
        attack_speed += _speed;
        real_speed = (1500 - attack_speed) / 1000;
    }
}
