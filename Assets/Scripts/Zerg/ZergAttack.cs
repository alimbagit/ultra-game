using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZergAttack : MonoBehaviour
{
    public GameObject m_PointAttack;
    public bool m_Meele = true;
    public float m_Damage=10;
    public float m_SpeedAttack=100;
    public float m_RangeAttack=1;
    public GameObject m_SpawnShell;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (m_Meele)
        {
            Attack_Meele();
        }
        else
        {
            Attack_Shooting();
        }
    }

    private void Attack_Meele()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_RangeAttack);
        foreach (Collider hit in hits)
        {
            if (transform.parent.tag != hit.transform.tag)
            {
                Vector3 direction = hit.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.65)
                {
                    hit.gameObject.SendMessage("TakeDamage", m_Damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    private void Attack_Shooting()
    {
        
    }
}
