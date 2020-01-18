using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform m_Target;           
    public float m_Smoothing = 7f;       
    public float m_CorrectDistance=2f;

    private Vector3 m_Offset;
    private int m_FloorMask;
    private float m_CamRayLength = 5000f;

    void Start()
    {
        m_FloorMask = LayerMask.GetMask("Floor");
        RaycastHit floorHit;
        if (Physics.Raycast(transform.position, transform.forward, out floorHit, m_CamRayLength, m_FloorMask))
        {
            m_Offset = transform.position-floorHit.point;
            transform.position = m_Target.position + m_Offset;
        }
        else
        {
            Debug.Log("Camera Follow in Error: Not find Floor!");
        }
        
    }

    void FixedUpdate()
    {
        if (m_Target)
        {
            Vector3 targetCamPos = m_Offset + m_Target.transform.TransformPoint(0, 0, m_CorrectDistance);
            transform.position = Vector3.Lerp(transform.position, targetCamPos, m_Smoothing * Time.deltaTime);
        }
    }
}