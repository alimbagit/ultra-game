using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZergPersonController : MonoBehaviour
{
    private ZergAttacking m_Attack;
    void Start()
    {
        m_Attack = gameObject.GetComponent<ZergAttacking>();
        
    }

    void Update()
    {
        
    }

    public void Attacking()
    {
        m_Attack.AttackingStartAnimation();
    }
}
