using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountCurrentOfShells : MonoBehaviour
{
    public string m_TagHeroName="HeroHuman";

    private HumanShooting m_Hero;
    private Text m_Text;
    private float m_TimerLightColorShellIcon = 0.3f;
    private float m_Timer = 0;
    private Image m_Image;
    void Start()
    {
        m_Text = GetComponentInChildren<Text>();
        m_Image = GetComponentInChildren<Image>();
        m_Hero = GameObject.FindGameObjectWithTag(m_TagHeroName).GetComponent<HumanShooting>();
    }


    void Update()
    {
        if (m_Hero)
        {
            m_Text.text = m_Hero.GetGun().GetComponent<Gun>().GetCurrentCountOfShells().ToString();

            if (m_Hero.GetGun().GetComponent<Gun>().GetCurrentCountOfShells() <= 0)
            {
                m_Timer += Time.deltaTime;
                if (m_Timer > m_TimerLightColorShellIcon)
                {
                    m_Timer = 0;
                    m_Text.color = m_Text.color == Color.red ? Color.black : Color.red;
                    m_Image.color = m_Image.color == Color.red ? Color.black : Color.red;
                }
            }
            else
            {
                m_Text.color = Color.black;
                m_Image.color = Color.black;
            }
        }
    }
}
