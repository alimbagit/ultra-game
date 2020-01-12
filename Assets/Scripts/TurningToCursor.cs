using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningToCursor : MonoBehaviour
{
    public float m_RotateSpeed = 10;

    private float m_CorrectRotateSpeed = 100f;
    Rigidbody m_PlayerRigidbody;
    int m_FloorMask;
    float m_CamRayLength = 5000f;
    // Start is called before the first frame update
    void Awake()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();
        m_FloorMask = LayerMask.GetMask("Floor");
    }

    private void FixedUpdate()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, m_CamRayLength, m_FloorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            newRotation = Quaternion.Lerp(m_PlayerRigidbody.rotation, newRotation, m_RotateSpeed / m_CorrectRotateSpeed);
            m_PlayerRigidbody.MoveRotation(newRotation);
        }
    }
}
