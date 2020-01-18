using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBoostRun : Ability
{
    public float m_SpeedBoost = 2f;
    void FixedUpdate()
    {
        if (m_OnStart) 
        {
            if (m_DealayTime <= m_Timer)
            {
                OnEffects();
                m_Timer = 0f;
                m_OnStart = false;
            }
            else
            {
                m_Timer += Time.deltaTime;
            }
        }
    }

    private void OnEffects()
    {
        GameObject newEffect = Instantiate(m_EffectsList[0]) as GameObject;
        transform.parent.parent.gameObject.GetComponent<HumanEffectsController>().SetEffect(newEffect);
        newEffect.GetComponent<EffectSpeedChange>().StartEffect(m_SpeedBoost);
    }
}
