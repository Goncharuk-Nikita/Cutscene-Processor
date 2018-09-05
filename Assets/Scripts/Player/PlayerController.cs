using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
	private Animator _animator;

	private BodyPart _mainBody;
	private List<BodyPart> _bodyParts;
 
	
#if UNITY_EDITOR
	private void OnValidate()
	{
		_animator = GetComponent<Animator>();
		
		_mainBody = GetComponent<BodyPart>();
		_bodyParts = new List<BodyPart>(GetComponentsInChildren<BodyPart>());
		
		if (_animator == null)
		{
			Debug.LogError("Animator component not found", this);
		}
		
		if (_mainBody == null)
		{
			Debug.LogError("BodyParts component not found", this);
		}

		_bodyParts.Remove(_mainBody);
	}
#endif

	private void Awake()
	{
		DisableBodyParts();
	}


	public void Die()
	{
		_mainBody.DisableBodyPart();

		foreach (var bodyPart in _bodyParts)
		{
			bodyPart.EnableBodyPart();
			bodyPart.AddImpulse(4f);
		}
	}

	private void DisableBodyParts()
	{
		foreach (var bodyPart in _bodyParts)
		{
			bodyPart.DisableBodyPart();
		}
	}
}
