using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float m_EffectDurationTime=4f;

    [HideInInspector] public bool m_OnEffect;
    [HideInInspector] public float m_Timer = 0;
    public void StartEffect()
    {
        m_OnEffect = true;
    }
    public void DeleteEffect()
    {
        transform.parent.parent.GetComponent<HumanEffectsController>().DeleteEffect(gameObject);
    }
}
