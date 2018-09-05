using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CutsceneCreator))]
public class CutsceneCreatorEdtor : Editor 
{
	private CutsceneCreator _cutsceneCreator;
	
	private void OnEnable()
	{
		_cutsceneCreator = (CutsceneCreator) target;
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		DrawActions();
		DrawButtons();
	}

	private void DrawActions()
	{
		for (int i = 0; i < _cutsceneCreator.dialogMessages.Count; i++)
		{
			var dialogMessage = _cutsceneCreator.dialogMessages[i];

			DrawAction(dialogMessage);
		}
	}

	private void DrawAction(DialogMessage dialogMessage)
	{
		EditorGUILayout.BeginVertical("box");

		// Remove button
		if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
		{
			_cutsceneCreator.RemoveDialogMessage(dialogMessage);
		}

		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Dialog Message:");
		dialogMessage.message = EditorGUILayout.TextArea(
			dialogMessage.message);

		dialogMessage.animationSeconds = EditorGUILayout.FloatField(
			"Animation Seconds:", dialogMessage.animationSeconds);
		
		EditorGUILayout.Space();
		dialogMessage.duration = EditorGUILayout.FloatField(
			"Action Duration:", dialogMessage.duration);
			
		EditorGUILayout.EndVertical();
	}

	private void DrawButtons()
	{
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();

		// Add button
		if (GUILayout.Button("Add Action", GUILayout.Height(32)))
		{
			_cutsceneCreator.AddNewDialogMessage();
		}
		
		// Save to xml button
		if (GUILayout.Button("Save to XML", GUILayout.Height(32)))
		{
			var path = EditorUtility.SaveFilePanel("Save Cutscene to XML", "", "Cutscene", ".xml");

			if (!string.IsNullOrEmpty(path))
			{
				_cutsceneCreator.SaveToXml(path);
			}
		}
		
		EditorGUILayout.EndHorizontal();
	}
}
