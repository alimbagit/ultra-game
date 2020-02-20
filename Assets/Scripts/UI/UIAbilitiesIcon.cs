using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilitiesIcon : MonoBehaviour
{
    public string m_HeroTag = "HeroHuman";

    private Text[] m_TextAbilitiesIcon;
    void Start()
    {
        m_TextAbilitiesIcon = new Text[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            m_TextAbilitiesIcon[i] = transform.GetChild(i).GetComponentInChildren<Text>();
        }
    }

    public void SetTextIconAbility(int index, string str)
    {
        m_TextAbilitiesIcon[index].text = str;
    }

    void Update()
    {

    }
}
