using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpeedChange: Effect
{
    private float m_ChangeSpeed;
    private void FixedUpdate()
    {
        if (m_OnEffect)
        {
            if(m_Timer==0) ApplyEffect();

            m_Timer += Time.deltaTime;
            if (m_Timer >= m_EffectDurationTime)
            {
                CancelEffect();
                m_OnEffect = false;
                m_Timer = 0f;
            }
        }
    }

    public void StartEffect(float change_speed)
    {
        m_ChangeSpeed = change_speed;
        m_OnEffect = true;
    }

    private void ApplyEffect()
    {
        float move_speed = transform.parent.parent.GetComponent<HumanWalking>().GetMoveSpeed();
        move_speed *= m_ChangeSpeed;
        transform.parent.parent.GetComponent<HumanWalking>().SetMoveSpeed(move_speed);
    }

    private void CancelEffect()
    {
        float move_speed = transform.parent.parent.GetComponent<HumanWalking>().GetMoveSpeed();
        move_speed /= m_ChangeSpeed;
        transform.parent.parent.GetComponent<HumanWalking>().SetMoveSpeed(move_speed);
        DeleteEffect();
    }
}
