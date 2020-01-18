using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEffectsController : MonoBehaviour
{
    public GameObject m_SlotEffects;

    private ArrayList m_EffectsList = new ArrayList();
    void Start()
    {
        
    }

    public void SetEffect(GameObject effect)
    {
        m_EffectsList.Add(effect);
        effect.transform.position = m_SlotEffects.transform.position;
        effect.transform.parent = m_SlotEffects.transform;
    }

    public void DeleteEffect(GameObject effect)
    {
        m_EffectsList.Remove(effect);
        Destroy(effect);
    }
}
