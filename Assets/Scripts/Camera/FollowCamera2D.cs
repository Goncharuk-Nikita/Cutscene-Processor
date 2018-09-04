using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera2D : MonoBehaviour
{
	
	public Transform target;

	public Vector3 offset;
	
	public float followSpeed = 20f;
	

	private Camera _camera;

	
	private void Awake()
	{
		_camera = GetComponent<Camera>();
	}

	
	
	private void LateUpdate()
	{
		var currentPosition = transform.position;
		var desiredPosition = target.position + offset;
		var smothedPosition = Vector3.Lerp(
			currentPosition, 
			desiredPosition, 
			followSpeed * Time.deltaTime);

		transform.position = smothedPosition;
	}


	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

	public void ChangeScaleSize(ScaleSizeParams parameters)
	{		
		_camera.DOOrthoSize(
			parameters.orthoSize, 
			parameters.duration);
	}
}

[CreateAssetMenu(fileName = "Scale Size Params", menuName = "Parameters/Camera/Scale Size Params")]
public class ScaleSizeParams : Param
{
	public float orthoSize;
	public float duration;
}


