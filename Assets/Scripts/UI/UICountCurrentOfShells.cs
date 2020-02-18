using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountCurrentOfShells : MonoBehaviour
{
    public HumanPersonController m_Hero;

    private Text m_Text;
    private GunShooting m_Gun;
    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<Text>();
        m_Gun = m_Hero.m_FirstWeapon.GetComponent<GunShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = m_Gun.GetCurrentCountOfShells().ToString();
    }
}
