using System;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCreator : MonoBehaviour
{
    [SerializeField] public Transform cameraFocus;
    
    public List<DialogMessage> dialogMessages { get; }
        = new List<DialogMessage>();

    
    public void AddNewDialogMessage()
    {
        dialogMessages.Add(new DialogMessage());
    }

    public void RemoveDialogMessage(DialogMessage dialogMessage)
    {
        dialogMessages.Remove(dialogMessage);
    }
    
    
    public void SaveToXml(string path)
    {
        var cutscene = new Cutscene
        {
            cameraFocusObjectPath = TransformPath.GetPath(cameraFocus.transform),
            dialogMessages = dialogMessages,
        };
        
        XmlConverter.SerializeAndSave(path, cutscene);
    }
}



