using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
	[SerializeField] private UIController dialogController;

	[SerializeField] private Text dialogTextBox;


	private TextSettings baseTextSettings;

	private void Start()
	{
		baseTextSettings = new TextSettings
		{
			fontColor = dialogTextBox.color,
			fontSize = dialogTextBox.fontSize,
			alignment = dialogTextBox.alignment
		};
	}


	public void ShowDialog()
	{
		dialogController.ShowAsync();
	}

	public void HideDialog()
	{
		dialogController.Hide();
	}


	public void WriteText(WriteTextParams parameters)
	{
		ChangeTextParams(parameters.textSettings);
		
		WriteText(parameters.text, parameters.duration);
	}

	public void WriteText(string text, float duration)
	{
		dialogTextBox.DOText(
			text,
			duration);
	}

	public void ClearText()
	{
		dialogTextBox.DOText(
			string.Empty,
			0.1f)
			.OnComplete(ResetTextParams);
	}
	
	private void ResetTextParams()
	{
		ChangeTextParams(baseTextSettings);
	}
	
	private void ChangeTextParams(TextSettings settings)
	{
		dialogTextBox.fontSize = settings.fontSize;
		dialogTextBox.color = settings.fontColor;
		dialogTextBox.alignment = settings.alignment;
	}
}

[CreateAssetMenu(fileName = "Write Text Params", menuName = "Parameters/Dialog/Write Text Params")]
public class WriteTextParams : Param
{
	[TextArea]
	public string text;
	public float duration;

	[Header("Text Settings")]
	public TextSettings textSettings;
}

[Serializable]
public class TextSettings
{
	public int fontSize = 26;
	public Color fontColor = Color.white;
	public TextAnchor alignment = TextAnchor.UpperLeft;
}