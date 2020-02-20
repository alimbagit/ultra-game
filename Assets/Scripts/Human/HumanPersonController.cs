using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (HumanWalking))]
public class HumanPersonController : MonoBehaviour
{
    public Transform m_WeaponSlot;
    public GameObject[] m_Weapons;

    private int m_CurrentWeaponIndex=0;
    //private Animator m_Animator;
    private HumanWalking m_HumanWalking;
    private Vector3 m_Walking = new Vector3(0,0,0);
    private Config.Axes m_ConfigAxes;
    private HumanShooting m_HumanShooting;
    
    private void Start()
    {
        m_HumanShooting = GetComponent<HumanShooting>();
        //m_Animator = GetComponent<Animator>();
        m_HumanWalking = GetComponent<HumanWalking>();

        InitializeWeapons();

        m_ConfigAxes = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().axes;
    }

    private void FixedUpdate()
    {
        Walking();
        m_HumanShooting.Fire(m_ConfigAxes.fire1.name);
    }

    private void Walking()
    {
        float h = Input.GetAxis(m_ConfigAxes.horizontal.name);
        float v = Input.GetAxis(m_ConfigAxes.vertical.name);

        m_Walking.x = h;
        m_Walking.z = v;
        m_HumanWalking.Walking(m_Walking);
    }

    private void InitializeWeapons()
    {
        if (m_Weapons.Length > 0)
        {
            SetWeapon(m_CurrentWeaponIndex);
        }
    }

    public void SetWeapon(int index)
    {
        m_CurrentWeaponIndex = index;
        for (int i = 0; i < m_Weapons.Length; i++)
        {
            m_Weapons[i].SetActive(false);
        }
        if (m_Weapons[index].scene.name == this.gameObject.scene.name)
        {

            m_Weapons[index].SetActive(true);
            //m_Weapons[index].transform.parent = m_WeaponSlot.parent;
            //m_Weapons[index].transform.position = m_WeaponSlot.position;
        }
        else
        {
            m_Weapons[index] = Instantiate(m_Weapons[index], m_WeaponSlot.position, m_WeaponSlot.rotation, m_WeaponSlot.parent);
        }
        if (m_Weapons[index].GetComponent<Gun>())
        {
            GetComponent<HumanShooting>().SetGun(m_Weapons[index]);
        }
        else if (m_Weapons[index].GetComponent<MeleeWeapon>())
        {
            Debug.Log("This is meele weapon");
        }
    }

    public GameObject GetCurrentActiveWeapon()
    {
        return m_Weapons[m_CurrentWeaponIndex];
    }
}

