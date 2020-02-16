using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShellHit : MonoBehaviour
{
    public float m_SizeDamage = 15f;
    public float m_MaxLifeTime = 1.5f;

    private Health.Damage m_Damage;
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        m_Damage.size_damage = m_SizeDamage;
        m_Damage.point_damage = transform.position;
        other.gameObject.SendMessage("TakeDamage", m_Damage, SendMessageOptions.DontRequireReceiver);
        //Destroy(this.gameObject);
    }
}
