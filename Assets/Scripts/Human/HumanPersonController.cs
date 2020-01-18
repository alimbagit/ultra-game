using System;
using UnityEngine;

[RequireComponent(typeof (HumanWalking))]
public class HumanPersonController : MonoBehaviour
{
    public GameObject m_FirstWeapon;
    public GameObject m_SecondWeapon;
    public Transform m_WeaponSlot1;
    public Transform m_WeaponSlot2;

    private HumanWalking m_HumanWalking;
    private Vector3 m_Walking = new Vector3(0,0,0);              
    public enum m_NumberWeapons { first,second};
    
    private void Start()
    {
        m_HumanWalking = GetComponent<HumanWalking>();
        if(m_FirstWeapon) SetWeapon(m_FirstWeapon, m_NumberWeapons.first, m_WeaponSlot1);
        if (m_SecondWeapon) SetWeapon(m_SecondWeapon, m_NumberWeapons.second, m_WeaponSlot1);
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
        if (m_FirstWeapon  && Input.GetButton("Fire1"))
        {
            m_FirstWeapon.GetComponent<GunShooting>().Fire();
        }

        if (m_SecondWeapon && Input.GetButton("Fire2"))
        {
            m_SecondWeapon.GetComponent<GunShooting>().Fire();
        }
    }


    public void SetWeapon(GameObject weapon, m_NumberWeapons number, Transform weapon_slot)
    {
        if (number == m_NumberWeapons.first)
        {
            m_FirstWeapon = Instantiate(weapon, weapon_slot.position, weapon_slot.rotation,transform) as GameObject;
        } 
        else if(number == m_NumberWeapons.second)
        {
            m_SecondWeapon = Instantiate(weapon, weapon_slot.position, weapon_slot.rotation, transform) as GameObject;
        } 
    }
}

