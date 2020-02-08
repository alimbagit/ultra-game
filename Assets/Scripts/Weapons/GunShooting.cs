using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public int m_Damage = 15;
    public float m_ShootingSpeed = 200f;
    public float m_ShootForce = 40f;
    public string m_ButtonAttack = "Fire1";
    public AudioSource m_ShootingAudio;
    public AudioClip m_FireClip;
    public Rigidbody m_Shell;
    public Transform m_ShellSpawn;

    private float m_Timer = 0;
    private float m_TimeOneShell;

    private void Awake()
    {
        CorrectSpeedAttack(0);
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

    public void Fire()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= m_TimeOneShell)
        {
            Rigidbody shellInstance = Instantiate(m_Shell, m_ShellSpawn.position, m_ShellSpawn.rotation) as Rigidbody;
            shellInstance.velocity = m_ShootForce * transform.forward;

            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
            m_Timer = 0;

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
