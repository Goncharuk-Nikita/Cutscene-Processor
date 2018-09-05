using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CutscenePlayer))]
public class CutscenePlayerEditor : Editor
{
	private CutscenePlayer _cutscenePlayer;
	
	private void OnEnable()
	{
		_cutscenePlayer = (CutscenePlayer) target;
	}
	
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		DrawButtons();
	}


	private void DrawButtons()
	{
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();

		// Add button
		if (GUILayout.Button("Add Action", GUILayout.Height(32)))
		{
			_cutscenePlayer.AddNewAction();
		}
		
		// Save to xml button
		if (GUILayout.Button("Save to XML", GUILayout.Height(32)))
		{
			var path = EditorUtility.SaveFilePanel("Save Cutscene to XML", "", "Cutscene", ".xml");

			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			XmlConverter.SerializeAndSave(path, _cutscenePlayer.cutsceneActions);
		}
		
		EditorGUILayout.EndHorizontal();
	}
}
