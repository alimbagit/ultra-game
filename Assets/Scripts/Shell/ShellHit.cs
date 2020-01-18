using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShellHit : MonoBehaviour
{
    public float m_Damage = 15f;
    public float m_MaxLifeTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("TakeDamage", m_Damage, SendMessageOptions.DontRequireReceiver);
        //Destroy(this.gameObject);
    }
}
