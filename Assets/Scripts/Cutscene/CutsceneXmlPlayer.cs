using System.Collections;
using System.Xml;
using UnityEngine;

public class CutsceneXmlPlayer : MonoBehaviour
{
	[Header("Cutscene XML Asset:")]
	[SerializeField] private TextAsset cutsceneXml;

	[Space]
	[Header("Player Components")]
	[SerializeField] private FollowCamera2D followCamera2D;
	[SerializeField] private DialogController dialogController;


#if UNITY_EDITOR
	private void OnValidate()
	{
		followCamera2D = FindObjectOfType<FollowCamera2D>();
		dialogController = FindObjectOfType<DialogController>();
	}
#endif

	private Transform _previousCameraFocus;
	private Cutscene _cutscene;

	private readonly WaitForSeconds _cameraFocusDuration = new WaitForSeconds(1f);
	
	private void Start()
	{
		if (cutsceneXml == null)
		{
			return;
		}
		SetCutscene(cutsceneXml);
	}



	public void SetCutscene(TextAsset xmlAsset)
	{
		_cutscene = xmlAsset.text
			.DeserializeFromXml<Cutscene>();
	}
	
	
	
	public void Play()
	{
		if (_cutscene == null)
		{
			Debug.LogError("You need to set cutscene first");
		}

		_previousCameraFocus = this.transform;
		StartCoroutine(PlayCutscene());
	}

	private IEnumerator PlayCutscene()
	{
		var cameraFocusObject = GameObject.Find(_cutscene.cameraFocusObjectPath.fullPath);
		yield return SetCameraFocus(cameraFocusObject.transform, 
			orthoSize: 3f, 
			duration: 1f);

		dialogController.ShowDialog();
		
		foreach (var dialogMessage in _cutscene.dialogMessages)
		{
			yield return WriteMessage(dialogMessage);
		}
		
		dialogController.HideDialog();
		yield return SetCameraFocus(_previousCameraFocus, 
			orthoSize: 8f, 
			duration: 0.5f);
	}
	
	private IEnumerator SetCameraFocus(Transform targetTransform, 
		float orthoSize, float duration)
	{
		followCamera2D.SetTarget(targetTransform);
		followCamera2D.ChangeScaleSize(orthoSize, duration);
		
		yield return _cameraFocusDuration;
	}

	private IEnumerator WriteMessage(DialogMessage dialogMessage)
	{
		dialogController.WriteText(dialogMessage.message, dialogMessage.animationSeconds);
		
		yield return new WaitForSeconds(dialogMessage.duration);
	}
}
