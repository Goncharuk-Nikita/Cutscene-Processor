using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CutsceneAction
{
    public string actionName;

    [Space]
    public float duration;
    
    public CutsceneEvent start;
    public CutsceneEvent end;
}
