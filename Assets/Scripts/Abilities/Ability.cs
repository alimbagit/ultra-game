using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float m_CoolDownAbility=10f;
    public GameObject[] m_EffectsList;
    public float m_DealayTime = 0f;

    protected bool m_OnStart=false;
    protected bool m_IsAvailable= true;

    public float m_TimerAvailable = 0;
    public virtual void StartAbility()
    {
        if (m_IsAvailable)
        {
            m_OnStart = true;
        }
    }

    private void Update()
    {
        if (!m_IsAvailable)
        {
            m_TimerAvailable += Time.deltaTime;
            if (m_CoolDownAbility < m_TimerAvailable)
            {
                m_TimerAvailable = 0f;
                m_IsAvailable = true;
            }
        }
    }

    public bool GetIsAvailable()
    {
        return m_IsAvailable;
    }

    public float GetTimer()
    {
        
        return m_CoolDownAbility - m_TimerAvailable;
    }
}
