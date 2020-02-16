using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyZergMovement : MonoBehaviour
{
    public string m_TargetTag = "HeroHuman";

    private Transform m_Player;
    private NavMeshAgent m_NavAgent;
    private bool m_IsAttacking = false;
    private bool m_IsMove = true;
    private float m_RangeAttack;
    private ZergAttacking m_ZergAttacking;
    private ZergHealth m_PlayerHealth;
    private Vector3 m_TargetPosition;
    private Animator m_Animator;

    void Awake()
    {
        m_Animator=GetComponent<Animator>();
        m_ZergAttacking = GetComponent<ZergAttacking>();
        m_RangeAttack = m_ZergAttacking.m_RangeAttack;
        // Set up the references.
        m_Player = GameObject.FindGameObjectWithTag(m_TargetTag).transform;
        //playerHealth = player.GetComponent<ZergHealth>();
        //enemyHealth = GetComponent<ZergHealth>();
        m_NavAgent = GetComponent<NavMeshAgent>();
    }
 
    void FixedUpdate()
    {
        //Debug.Log(m_Player.name);
        if (m_Player != null)
        {
            FindTargetToRangeAttack();
            if (m_IsMove)
            {
                WalkingToTarget();
            }

            if (m_IsAttacking)
            {
                Attacking();
            }
        }
        else
        {   
            Idle();
        }
    }

    private void FindTargetToRangeAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_RangeAttack);
        bool isHit = false;
        foreach (Collider hit in hits)
        {
            if (m_TargetTag == hit.transform.tag)
            {
                Vector3 direction = hit.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.65)
                {
                    isHit = true;
                    m_TargetPosition = hit.transform.position;
                }
            }
        }
        if (isHit)
        {
            m_IsAttacking = true;
            m_IsMove = false;
        }
        else
        {
            m_IsAttacking = false;
            m_IsMove = true;
        }
    }

    private void Attacking()
    {
        m_ZergAttacking.AttackingStartAnimation(m_TargetPosition);
    }

    private void WalkingToTarget()
    {
        m_Animator.SetTrigger("OnMoveForward");
        m_NavAgent.SetDestination(m_Player.position);
        m_ZergAttacking.AttackingStopAnimation();

    }

    private void Idle()
    {
        m_ZergAttacking.AttackingStopAnimation();
        m_Animator.SetTrigger("OnIdle");
    }
}