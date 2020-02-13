using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyZergMovement : MonoBehaviour
{
    public float m_RangeAttack = 600f;
    public string m_TargetTag = "HeroHuman";

    private Transform m_Player;
    private ZergHealth m_PlayerHealth;
    private NavMeshAgent m_NavAgent;
    private bool m_IsAttack=false;
    private bool m_IsMove = true;

    void Awake()
    {
        m_RangeAttack = GetComponent<ZergAttack>().m_RangeAttack;
        // Set up the references.
        m_Player = GameObject.FindGameObjectWithTag(m_TargetTag).transform;
        //playerHealth = player.GetComponent<ZergHealth>();
        //enemyHealth = GetComponent<ZergHealth>();
        m_NavAgent = GetComponent<NavMeshAgent>();
    }
 
    void Update()
    {
        TargetRangeAttack();
        if (m_Player != null)
        {
            if (m_IsMove)
            {
                WalkingToTarget();
            }

            if (m_IsAttack)
            {
                Attack();
            }
        }
    }

    private void TargetRangeAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_RangeAttack);
        bool isHit = false;
        foreach (Collider hit in hits)
        {
            Debug.Log(hit.gameObject.name);
            if (m_TargetTag == hit.transform.tag)
            {
                Vector3 direction = hit.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.6)
                {
                    isHit = true;
                }
            }
        }
        if (isHit)
        {
            m_IsAttack = true;
            m_IsMove = false;
        }
        else
        {
            m_IsAttack = false;
            m_IsMove = true;
        }
    }

    private void Attack()
    {
        
    }

    private void WalkingToTarget()
    {
        m_NavAgent.SetDestination(m_Player.position);
    }
}