using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectJerk : Effect
{
    private Vector3 m_ForceDirection;

    public void StartEffect(Vector3 force_direction)
    {
        m_ForceDirection = force_direction;
        base.StartEffect();
    }
    protected override void ApplyEffect()
    {
        transform.parent.parent.GetComponent<Rigidbody>().AddForce(m_ForceDirection, ForceMode.Impulse);
    }

    protected override void CancelEffect()
    {
        base.CancelEffect();
    }
}
