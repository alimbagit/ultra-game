using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float m_EffectDurationTime=4f;

    protected bool m_OnEffect;
    protected float m_Timer = 0;
    public virtual void StartEffect()
    {
        m_OnEffect = true;
    }

    protected virtual void FixedUpdate()
    {
        if (m_OnEffect)
        {
            if (m_Timer == 0) ApplyEffect();

            m_Timer += Time.deltaTime;
            if (m_Timer >= m_EffectDurationTime)
            {
                CancelEffect();
                m_OnEffect = false;
                m_Timer = 0f;
            }
        }
    }

    protected virtual void ApplyEffect()
    {

    }

    protected virtual void CancelEffect()
    {
        DeleteEffect();
    }

    protected void DeleteEffect()
    {
        transform.parent.parent.GetComponent<HumanEffectsController>().DeleteEffect(gameObject);
    }
}
