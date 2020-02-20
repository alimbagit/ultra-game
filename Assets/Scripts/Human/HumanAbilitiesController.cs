using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanAbilitiesController : MonoBehaviour
{
    public GameObject m_SlotAbilities;
    public GameObject[] m_Abilities;
    public UIAbilitiesIcon m_UICanvasAbilities;

    private Config.OneAxis[] m_AxesAbilities;
    private Dictionary<string, GameObject> m_ButtonAbilities = new Dictionary<string, GameObject>();   

    void Awake()
    {

    }
    void Start()
    {
        m_AxesAbilities = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().axes.abilities;
        for (int i=0;i<m_Abilities.Length;i++)
        {
            GameObject ability = Instantiate(m_Abilities[i]) as GameObject;
            ability.transform.parent = m_SlotAbilities.transform;
            ability.transform.position = m_SlotAbilities.transform.position;
            m_ButtonAbilities.Add(m_AxesAbilities[i].name,ability);
        }
        FillSlotAbilities();
    }

    void Update()
    {
        foreach(KeyValuePair<string, GameObject> ability in m_ButtonAbilities)
        {
            if (Input.GetButtonDown(ability.Key))
            {
                ability.Value.GetComponent<Ability>().StartAbility();
            }
        }

        FillSlotAbilities();
    }

    private void FillSlotAbilities()
    {
        for (int i = 0; i < m_AxesAbilities.Length; i++)
        {
            if (m_ButtonAbilities.Count>i)
            {
                if (m_ButtonAbilities[m_AxesAbilities[i].name].GetComponent<Ability>().GetIsAvailable())
                {
                    m_UICanvasAbilities.SetTextIconAbility(i, m_AxesAbilities[i].positive);
                }
                else
                {
                    m_UICanvasAbilities.SetTextIconAbility(i, m_ButtonAbilities[m_AxesAbilities[i].name].GetComponent<Ability>().GetTimer().ToString());
                }
            }
            else
            {
                m_UICanvasAbilities.SetTextIconAbility(i, m_AxesAbilities[i].positive);
            }
        }
    }
}
