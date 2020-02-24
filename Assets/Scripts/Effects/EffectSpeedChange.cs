using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpeedChange: Effect
{
    private float m_ChangeSpeed;

    public void StartEffect(float change_speed)
    {
        m_ChangeSpeed = change_speed;
        base.StartEffect();
    }

    protected override void ApplyEffect()
    {
        float move_speed = transform.parent.parent.GetComponent<HumanWalking>().GetMoveSpeed();
        move_speed *= m_ChangeSpeed;
        transform.parent.parent.GetComponent<HumanWalking>().SetMoveSpeed(move_speed);
    }

    protected override void CancelEffect()
    {
        float move_speed = transform.parent.parent.GetComponent<HumanWalking>().GetMoveSpeed();
        move_speed /= m_ChangeSpeed;
        transform.parent.parent.GetComponent<HumanWalking>().SetMoveSpeed(move_speed);
        base.CancelEffect();
    }
}
