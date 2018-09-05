using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BodyPart : MonoBehaviour
{
	[SerializeField] private Collider2D _collider;
	
	private Rigidbody2D _body;

#if UNITY_EDITOR
	private void OnValidate()
	{
		_body = GetComponent<Rigidbody2D>();
		if (_body == null)
		{
			Debug.LogError("Rigidbody2D component not found", this);
		}
		
		_collider = GetComponent<Collider2D>();
		if (_collider == null)
		{
			Debug.LogError("Collider2D component not found", this);
		}
	}
#endif


	public virtual void DisableBodyPart()
	{
		_body.simulated = _collider.enabled = false;
	}
	
	public virtual void EnableBodyPart()
	{
		_body.simulated = _collider.enabled = true;
	}

	public virtual void AddImpulse(float strength)
	{
		_body.AddForce(Random.insideUnitCircle * strength, ForceMode2D.Impulse);
	}
}
