using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanAbilitiesController : MonoBehaviour
{
    public GameObject m_SlotAbilities;
    public GameObject[] m_Abilities;
    public GameObject m_UICanvasAbilities;

    private string[] m_AxesAbilities;
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
            m_ButtonAbilities.Add(m_AxesAbilities[i],ability);
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
    }

    private void FillSlotAbilities()
    {
        for(int i = 0; i < m_AxesAbilities.Length; i++)
        {
            m_UICanvasAbilities.transform.GetChild(i).gameObject.GetComponentInChildren<Text>().text=m_AxesAbilities[i];
        }
    }
}
