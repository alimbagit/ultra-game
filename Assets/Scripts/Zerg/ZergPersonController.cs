using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZergPersonController : MonoBehaviour
{
    private ZergAttack m_Attack;
    void Start()
    {
        m_Attack = gameObject.GetComponent<ZergAttack>();
        
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        m_Attack.Attack();
    }
}
