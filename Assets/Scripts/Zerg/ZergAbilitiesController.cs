using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZergAbilitiesController : MonoBehaviour
{
    public GameObject m_SlotAbilities;
    public string[] m_Buttons = { "q", "e", "r", "x", "c", "v" };
    public GameObject[] m_Abilities;

    private Dictionary<string, GameObject> m_ButtonAbilities = new Dictionary<string, GameObject>();
    void Start()
    {
        for (int i = 0; i < m_Abilities.Length; i++)
        {
            GameObject ability = Instantiate(m_Abilities[i]) as GameObject;
            ability.transform.parent = m_SlotAbilities.transform;
            ability.transform.position = m_SlotAbilities.transform.position;
            m_ButtonAbilities.Add(m_Buttons[i], ability);
        }
    }

    void Update()
    {
        foreach (KeyValuePair<string, GameObject> ability in m_ButtonAbilities)
        {
            if (Input.GetButtonDown(ability.Key))
            {
                ability.Value.GetComponent<Ability>().StartAbility();
            }
        }
    }
}
