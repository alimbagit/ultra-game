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
    protected float m_Timer;
    protected float m_TimerAvailable = 0;

    protected List<GameObject> m_CurrentActiveEffectList=new List<GameObject>();
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

    protected virtual void FixedUpdate()
    {
        if (m_OnStart)
        {
            m_Timer += Time.deltaTime;
            if (m_DealayTime <= m_Timer)
            {
                OnEffects();
                m_Timer = 0f;
                m_OnStart = false;
                m_IsAvailable = false;
            }
        }
    }

    protected virtual void OnEffects()
    {
        m_CurrentActiveEffectList.Clear();
        for(int i = 0; i < m_EffectsList.Length; i++)
        {
            GameObject newEffect = Instantiate(m_EffectsList[i]) as GameObject;
            m_CurrentActiveEffectList.Add(newEffect);
            transform.parent.parent.gameObject.GetComponent<HumanEffectsController>().SetEffect(newEffect);
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
