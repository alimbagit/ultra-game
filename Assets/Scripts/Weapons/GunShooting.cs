﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public int m_Damage = 15;
    public int m_CoutOfShells = 25;
    public float m_ShootingSpeed = 200f;
    public float m_ShootForce = 40f;
    public string m_ButtonAttack = "Fire1";
    public AudioSource m_ShootingAudio;
    public AudioClip m_FireAudioClip;
    public Rigidbody m_Shell;
    public Transform m_ShellSpawn;
    [HideInInspector] public int m_CurrentCountOfShells;
    private float m_Timer = 0;
    private float m_TimeOneShell;
    

    private void Awake()
    {
        CorrectSpeedAttack(0);
        m_CurrentCountOfShells = m_CoutOfShells;
    }
    public void CorrectSpeedAttack(float speed)
    {
        m_ShootingSpeed += speed;
        m_TimeOneShell = (1500 - m_ShootingSpeed) / 10000;
    }

    void FixedUpdate()
    {
        if (m_Timer < m_TimeOneShell) m_Timer += Time.deltaTime;
    }

    public void RealoadGun()
    {
        m_CurrentCountOfShells = m_CoutOfShells;
    }

    public int GetCurrentCountOfShells()
    {
        return m_CurrentCountOfShells;
    }

    public void Fire()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= m_TimeOneShell)
        {
            Rigidbody shellInstance = Instantiate(m_Shell, m_ShellSpawn.position, m_ShellSpawn.rotation) as Rigidbody;
            shellInstance.velocity = m_ShootForce * transform.forward;
            shellInstance.GetComponent<ShellHit>().SetPositionSpawn(m_ShellSpawn.position);
            m_ShootingAudio.clip = m_FireAudioClip;
            m_ShootingAudio.Play();
            m_Timer = 0;
            m_CurrentCountOfShells--;
        }
    }

    //public RaycastHit Shooting()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
    //    {
    //        hit.transform.gameObject.SendMessage("DamageHealth", m_Damage, SendMessageOptions.DontRequireReceiver);
    //    }

    //    return hit;
    //}
}
