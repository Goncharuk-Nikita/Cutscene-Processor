using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
	private Rigidbody2D _body;

#if UNITY_EDITOR
	private void OnValidate()
	{
		_body = GetComponent<Rigidbody2D>();	
		if (_body == null)
		{
			Debug.LogError("Rigidbody2D component not found", this);
		}
	}
#endif

	public void Jump(float force)
	{
		_body.AddForce(Vector2.up * force, ForceMode2D.Impulse);		
	}
}
