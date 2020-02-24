using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBoostRun : Ability
{
    
    public float m_SpeedBoost = 2f;


    protected override void OnEffects()
    {
        base.OnEffects();
        m_CurrentActiveEffectList[0].GetComponent<EffectSpeedChange>().StartEffect(m_SpeedBoost);
    }
}
