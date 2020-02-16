using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZergAttacking : MonoBehaviour
{
    public GameObject m_PointAttack;
    public bool m_Meele = true;
    public float m_SizeDamage=10;
    public float m_SpeedAttack=100;
    public float m_RangeAttack=2;
    public GameObject m_SpawnShell;

    private Animator m_Animator;
    private Health.Damage m_Damage;
    //private bool m_OnAttackingLeft=false;
    //private bool m_OnAttackingRight = false;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackingStartAnimation()
    {

    }
    public void AttackingStartAnimation(Vector3 target_position)
    {
        if (m_Meele)
        {
            Vector3 direction = target_position - transform.position;
            if (Vector3.Dot(transform.right, direction) > 0)
            {
                //m_Animator.SetTrigger("OnAttackingRight");
                m_Animator.SetBool("OnAttackingLeft", false);
                m_Animator.SetBool("OnAttackingRight", true);
            }
            else
            {
               // m_Animator.SetTrigger("OnAttackingLeft");
                m_Animator.SetBool("OnAttackingRight", false);
                m_Animator.SetBool("OnAttackingLeft", true);
            }
        }

        else
        {
            //Attacking_Shooting();
        }
    }

    public void AttackingStopAnimation()
    {
        if (m_Meele)
        {
            m_Animator.SetBool("OnAttackingRight", false);
            m_Animator.SetBool("OnAttackingLeft", false);
            //m_Animator.SetTrigger("OnIdle");
        }
    }

    private void AttackingMeele()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_RangeAttack);
        foreach (Collider hit in hits)
        {
            if (transform.tag != hit.transform.tag)
            {
                Vector3 direction = hit.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.65)
                {
                    m_Damage.size_damage = m_SizeDamage;
                    m_Damage.point_damage = transform.position;
                    hit.gameObject.SendMessage("TakeDamage", m_Damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    private void Attacking_Shooting()
    {
        
    }
}
