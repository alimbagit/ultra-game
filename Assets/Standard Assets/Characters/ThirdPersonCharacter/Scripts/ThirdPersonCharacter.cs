using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
		[SerializeField] float m_MoveSpeed = 5f;
		[SerializeField] float m_RotateSpeed = 10;

		Rigidbody m_Rigidbody;
		Animator m_Animator;
		float m_TurnAmount;
		float m_ForwardAmount;
		Vector3 m_GroundNormal;
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

			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
			if (walking.magnitude > 1f) walking.Normalize();
			//walking = transform.InverseTransformDirection(walking);
			//walking = Vector3.ProjectOnPlane(walking, m_GroundNormal);
			m_ForwardAmount = transform.InverseTransformDirection(walking).z;
			walking = walking * m_MoveSpeed * Time.deltaTime;
			m_Rigidbody.MovePosition(m_Rigidbody.position + walking);
			Turning();
			UpdateAnimator();
		}


		
		void UpdateAnimator()
		{
			// update the animator parameters
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
			m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);

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
	}
}
