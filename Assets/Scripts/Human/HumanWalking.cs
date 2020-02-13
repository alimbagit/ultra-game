using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class HumanWalking : MonoBehaviour
{
	[SerializeField] float m_MoveSpeed = 5f;
	[SerializeField] float m_RotateSpeed = 10;

	Rigidbody m_Rigidbody;
	Animator m_Animator;
	float m_TurnAmount;
	float m_WalkingAmount;
	float m_WalkingSide;
	bool m_OnWalkingForward;
	bool m_OnWalkingBack;
	float m_CamRayLength = 5000f;
	int m_FloorMask;
	float m_CorrectRotateSpeed=100f;

	void Start()
	{
		m_FloorMask = LayerMask.GetMask("Floor");
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();

		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}


	public void Walking(Vector3 walking)
	{
		if (walking.magnitude > 1f) walking.Normalize();

		m_OnWalkingForward= Vector3.Dot(transform.forward, walking) > 0.4;
		m_OnWalkingBack = Vector3.Dot(transform.forward, walking) < -0.3;
		m_WalkingSide = Vector3.Dot(transform.right, walking);
		m_WalkingAmount = walking.magnitude;

		if (!m_OnWalkingForward) walking *= 0.5f;
		//else walking *= 0.8f;
		walking = walking * m_MoveSpeed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + walking);
		Turning();
		UpdateAnimator();
	}
	
	void UpdateAnimator()
	{
		m_Animator.SetBool("OnWalkingBack", m_OnWalkingBack);
		m_Animator.SetFloat("Walking", m_WalkingAmount);
		m_Animator.SetFloat("Side", m_WalkingSide);

	}

	public void OnAnimatorMove()
	{
			//if (Time.deltaTime > 0)
			//{
			//	Debug.Log(m_Animator.deltaPosition);
			//	Vector3 v = (m_Animator.deltaPosition * m_MoveSpeed) / Time.deltaTime;
			//	v.y = m_Rigidbody.velocity.y;
			//	m_Rigidbody.velocity = v;
			//}
		}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, m_CamRayLength, m_FloorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			newRotation = Quaternion.Lerp(m_Rigidbody.rotation, newRotation, m_RotateSpeed / m_CorrectRotateSpeed);
			m_TurnAmount= Quaternion.Angle(m_Rigidbody.rotation, newRotation);
			m_Rigidbody.MoveRotation(newRotation);
		}
	}

	public float GetMoveSpeed()
	{
		return m_MoveSpeed;
	}
	public void SetMoveSpeed(float speed)
	{
		m_MoveSpeed = speed;
	}
}
