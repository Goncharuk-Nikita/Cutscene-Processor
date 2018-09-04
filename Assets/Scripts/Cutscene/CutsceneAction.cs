using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CutsceneAction
{
    public string actionName;

    [Space]
    public float duration;
    
    public UnityEvent start;
    public UnityEvent end;
}
