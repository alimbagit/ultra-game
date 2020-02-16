using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZergHealth : Health
{
    protected override void OnDeathAnimation( Damage damage)
    {
        base.OnDeathAnimation(damage);
        Vector3 direction = transform.position - damage.point_damage;
        float dot = Vector3.Dot(transform.forward, direction);
        if (dot > 0.4)
        {
            m_Animator.SetTrigger("OnDeathForward");
            Debug.Log("OnDeathForward");
        }
        else if(dot < -0.4)
        {
            m_Animator.SetTrigger("OnDeathBack");
            Debug.Log("OnDeathBack");
        }
        else
        {
            m_Animator.SetTrigger("OnDeath");
            Debug.Log("OnDeath");
        }

    }

    protected override void TakeDamageAnimation(Damage damage)
    {
        Vector3 direction = transform.position - damage.point_damage;
        float dot = Vector3.Dot(transform.right, direction);
        //Debug.Log(dot);
        if ( dot> 0.5)
        {
            m_Animator.SetTrigger("OnTakeDamageRight");
        }
        else if(dot < -0.5)
        {
            m_Animator.SetTrigger("OnTakeDamageLeft");
        }
    }


}
