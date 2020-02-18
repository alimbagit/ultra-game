using System;
using UnityEngine;

[RequireComponent(typeof (HumanWalking))]
public class HumanPersonController : MonoBehaviour
{
    public GameObject m_FirstWeapon;
    public GameObject m_SecondWeapon;
    public Transform m_WeaponSlot1;
    public Transform m_WeaponSlot2;

    private Animator m_Animator;
    private float m_FireTime = 0;
    private HumanWalking m_HumanWalking;
    private Vector3 m_Walking = new Vector3(0,0,0);
    private Config.Axes m_ConfigAxes;
    public enum m_NumberWeapons { first,second};
    
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_HumanWalking = GetComponent<HumanWalking>();
        if(m_FirstWeapon) SetWeapon(m_FirstWeapon, m_NumberWeapons.first, m_WeaponSlot1);
        if (m_SecondWeapon) SetWeapon(m_SecondWeapon, m_NumberWeapons.second, m_WeaponSlot2);
        m_ConfigAxes = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().axes;
    }

    private void Update()
    {
        RealoadGunAnimation(m_FirstWeapon);
    }

    private void FixedUpdate()
    {
        Walking();
        Fire();
    }

    private void Walking()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        m_Walking.x = h;
        m_Walking.z = v;
        m_HumanWalking.Walking(m_Walking);
    }


    private void Fire()
    {
        if (m_FirstWeapon && Input.GetButton("Fire1"))
        {
            if (m_FirstWeapon.GetComponent<GunShooting>().GetCurrentCountOfShells() > 0)
            {
                m_FirstWeapon.GetComponent<GunShooting>().Fire();
                m_FireTime += Time.deltaTime;
                m_Animator.SetFloat("Shooting", m_FireTime);
            }

            else
            {
                Debug.Log("reaload gun");
            }
        }
        else
        {
            m_FireTime = 0f;
            m_Animator.SetFloat("Shooting", m_FireTime);
        }

        if (m_SecondWeapon && Input.GetButton("Fire2"))
        {
            m_SecondWeapon.GetComponent<GunShooting>().Fire();
        }
    }

    private void RealoadGunAnimation(GameObject gun)
    {
        if (Input.GetButtonDown(m_ConfigAxes.reload_weapon))
        {
            m_Animator.SetTrigger("OnReaload");
        }
    }
    public void ReloadGun()
    {
        Debug.Log("ReloadGun");
        m_FirstWeapon.GetComponent<GunShooting>().RealoadGun();
    }

    public void SetWeapon(GameObject weapon, m_NumberWeapons number, Transform weapon_slot)
    {
        if (weapon.scene.name == this.gameObject.scene.name)
        {
            if (number == m_NumberWeapons.first)
            {
                m_FirstWeapon = weapon;
                m_FirstWeapon.transform.position = weapon_slot.position;
            }
            else if (number == m_NumberWeapons.second)
            {
                m_SecondWeapon = weapon;
                m_SecondWeapon.transform.position = weapon_slot.position;
            }
        }
        else
        {
            if (number == m_NumberWeapons.first)
            {
                m_FirstWeapon = Instantiate(weapon, weapon_slot.position, weapon_slot.rotation, transform) as GameObject;
            }
            else if (number == m_NumberWeapons.second)
            {
                m_SecondWeapon = Instantiate(weapon, weapon_slot.position, weapon_slot.rotation, transform) as GameObject;
            }
        }
    }
}

