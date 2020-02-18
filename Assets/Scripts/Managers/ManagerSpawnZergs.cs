using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawnZergs : MonoBehaviour
{
    public GameObject m_ZergQueen;
    public float m_TimeSpawnOneQueen = 3;
    private float m_CurrentTimer=0;


    // Update is called once per frame
    void Update()
    {
        if (m_CurrentTimer > m_TimeSpawnOneQueen)
        {
            Instantiate(m_ZergQueen, transform.position, transform.rotation);
            m_CurrentTimer = 0;
        }
        else
        {
            m_CurrentTimer += Time.deltaTime;
        }
    }
}
