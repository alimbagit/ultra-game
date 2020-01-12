using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character;
        private Vector3 m_Walking = new Vector3(0,0,0);              

        
        private void Start()
        {
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            m_Walking.x = h;
            m_Walking.z = v;
            m_Character.Walking(m_Walking);
        }
    }
}
