using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHpLineTurnCamera : MonoBehaviour
{

    void FixedUpdate()
    {

		Quaternion newRotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
		transform.rotation = newRotation;
	}
}
