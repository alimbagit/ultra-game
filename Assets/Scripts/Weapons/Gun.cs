using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun: MonoBehaviour
{
    public int m_Damage = 15;
    public float m_AttackSpeed = 200f;
    public AudioSource m_AttackAudioSource;
    public AudioClip m_AttackAudioClip;
    public int m_CoutOfShells = 25;
    public float m_ShootForce = 40f;
    
    
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
        m_AttackSpeed += speed;
        m_TimeOneShell = (1500 - m_AttackSpeed) / 10000;
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
            m_AttackAudioSource.clip = m_AttackAudioClip;
            m_AttackAudioSource.Play();
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
