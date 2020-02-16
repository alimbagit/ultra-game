using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HumanHealth : Health
{
    public GameObject m_ExplosionPrefab;

    private ParticleSystem m_ExplosionParticles;
    private AudioSource m_ExplosionAudio;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }

    protected override void OnDeathAnimation(Damage damage)
    {
        base.OnDeathAnimation(damage);
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        base.OnDeath();
    }
}
