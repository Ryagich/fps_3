using System;
using System.Collections;
using System.Collections.Generic;
using NeoFPS;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TextHolder : MonoBehaviour
{
    [TextArea] [SerializeField] private string _text;
    [TextArea] [SerializeField] private string _task;

    public void ChangeTask()
    {
        TaskManager.Instance.ChangeAndUpdateTask(_task);
    }
    
    public void ChangeQuest()
    {
        SubsController.Instance.WriteText(_text);
    }
}