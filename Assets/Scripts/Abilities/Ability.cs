using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public GameObject[] m_EffectsList;
    public float m_DealayTime = 0f;

    [HideInInspector]public bool m_OnStart=false;
    [HideInInspector]public float m_Timer=0;
    public void StartAbility()
    {
        m_OnStart = true;
    }

}
