using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBoostRun : Ability
{
    private float m_Timer;
    public float m_SpeedBoost = 2f;
    private void FixedUpdate()
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
                Debug.Log(m_IsAvailable);
            }
        }
    }

    protected void OnEffects()
    {
        GameObject newEffect = Instantiate(m_EffectsList[0]) as GameObject;
        transform.parent.parent.gameObject.GetComponent<HumanEffectsController>().SetEffect(newEffect);
        newEffect.GetComponent<EffectSpeedChange>().StartEffect(m_SpeedBoost);
    }
}
