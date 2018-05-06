﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetPosition;
    public Transform targetLookAt;


	public Transform target;
	public Transform targetRotation;

	public float smoothSpeed = 0.125f;
	public float smoothLookSpeed = 0.125f;

	public float minY, maxY;
	public Vector3 offset;
	Vector3 m_targetPosition = Vector3.zero;

	void LateUpdate ()
	{

        transform.position = targetPosition.position;
        Quaternion rot = transform.rotation;
        transform.LookAt(targetLookAt);
        transform.rotation = Quaternion.Lerp(rot, transform.rotation, Time.deltaTime*4);
        return;

//		Vector3 desiredPosition = target.position + offset;
//
//		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
//
//		if (smoothedPosition.y < minY)
//			smoothedPosition.y = minY;
//		transform.position = smoothedPosition;
//
//		Quaternion targetRot = targetRotation.localRotation;
//		transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRot, smoothLookSpeed * Time.deltaTime);
//

		// Get the inverse of the players velocity
		Vector3 direction = -(target.transform.GetComponent<Rigidbody> ().velocity.normalized);

		//  Set the position of the camera relative to the player, with some distance and height
		m_targetPosition = target.transform.position + (direction * offset.z) + (Vector3.up * offset.y);



		// Set camera position                
		transform.position = m_targetPosition;

		// Let the camera look at the player                    
//		SmoothLookAt (target.position, smoothLookSpeed);
		transform.LookAt (target.transform);

	}




	void SmoothLookAt (Vector3 target, float smooth)
	{
		Vector3 dir = target - transform.position + transform.up;
		Quaternion targetRotation = Quaternion.LookRotation (dir);
		targetRotation.x = 0;
		targetRotation.y = 0;
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * smooth);
	}
}