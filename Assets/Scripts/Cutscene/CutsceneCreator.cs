using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCreator : MonoBehaviour
{
	public List<CutsceneAction> cutsceneActions = new List<CutsceneAction>();

	
	public void Play()
	{
		StartCoroutine(PlayActions());
	}

	private IEnumerator PlayActions()
	{
		foreach (var action in cutsceneActions)
		{
			action.start?.Invoke();
			
			yield return new WaitForSeconds(action.duration);
			
			action.end?.Invoke();
		}
	}
	
	
	public void AddNewAction()
	{
		cutsceneActions.Add(new CutsceneAction());
	}

	public bool RemoveAction(CutsceneAction cutsceneAction)
	{
		return cutsceneActions.Remove(cutsceneAction);
	}
}

