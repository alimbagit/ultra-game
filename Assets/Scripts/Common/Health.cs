using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Color m_HealthColor = Color.green;
    public Image m_FillImage;

    private float m_CurrentHealth;
    private bool m_Dead;
    protected Animator m_Animator;

    public struct Damage
    { 
        public float size_damage;
        public Vector3 point_damage;
    }
    
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_FillImage.color = m_HealthColor;
        m_Dead = false;

        SetHealthUI();
    }

    public void TakeDamage(Damage damage)
    {
        TakeDamageAnimation(damage);
        m_CurrentHealth -= damage.size_damage;
        SetHealthUI();
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeathAnimation(damage);
        }
    }

    protected virtual void TakeDamageAnimation(Damage damage)
    {

    }

    public void SetHealthUI()
    {
        m_Slider.value = m_CurrentHealth;
    }


    public virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }

    protected virtual void OnDeathAnimation(Damage damage)
    {
        m_Dead = true;
    }
}
