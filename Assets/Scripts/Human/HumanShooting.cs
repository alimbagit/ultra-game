using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanShooting : MonoBehaviour
{
    public UICountCurrentOfShells m_UICanvasCountOfShells;

    private float m_FireTime = 0;
    private Animator m_Animator;
    private GameObject m_Gun;
    private Config.Axes m_ConfigAxes;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_ConfigAxes = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().axes;
    }

    public void SetGun(GameObject gun)
    {
        m_Gun = gun;
    }

    public GameObject GetGun()
    {
        return m_Gun;
    }

    private void Update()
    {
        RealoadGunAnimation();
    }

    public void Fire(string button_name)
    {
        if (m_Gun && Input.GetButton(button_name))
        {
            if (m_Gun.GetComponent<Gun>().GetCurrentCountOfShells() > 0)
            {
                m_Gun.GetComponent<Gun>().Fire();
                m_FireTime += Time.deltaTime;
                m_Animator.SetFloat("Shooting", m_FireTime);
            }

            //else
            //{
            //    m_UICanvasCountOfShells.AnimateUICountOfShells();
            //}
        }
        else
        {
            m_FireTime = 0f;
            m_Animator.SetFloat("Shooting", m_FireTime);
        }
    }

    private void RealoadGunAnimation()
    {
        if (Input.GetButtonDown(m_ConfigAxes.reload_weapon.name))
        {
            m_Animator.SetTrigger("OnReaload");
        }
    }
    public void ReloadGun()
    {
        m_Gun.GetComponent<Gun>().RealoadGun();
    }
}
