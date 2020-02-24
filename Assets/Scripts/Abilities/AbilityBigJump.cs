using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBigJump : Ability
{
    public float m_ForceJump=10f;

    protected override void OnEffects()
    {
        base.OnEffects();
        Transform t_parent = transform.parent.parent;
        m_CurrentActiveEffectList[0].GetComponent<EffectJerk>().StartEffect((t_parent.up + t_parent.forward)*m_ForceJump);
    }
}
