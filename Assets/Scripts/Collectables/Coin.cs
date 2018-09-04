using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{

	private Animator _animator;

#if UNITY_EDITOR
	private void OnValidate()
	{
		_animator = GetComponent<Animator>();
		if (_animator == null)
		{
			Debug.LogError("Animator component not found", this);
		}
	}
#endif

	public void PlayAnimation(string animationName)
	{
		_animator.Play(animationName);
	}
}
