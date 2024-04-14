using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    [SerializeField] private TMP_Text _text;
    private string str;

    private void Awake()
    {
        str = _text.text;
        Instance = this;
        SubsController.Instance.EndWrite += TryUpdateTask;
    }

    private void TryUpdateTask()
    {
        if (_text.text != str)
        {
            _text.text = str;
        }
    }

    public void ChangeAndUpdateTask(string text)
    {
        if (text == "")
            return;
        str = text;
        TryUpdateTask();
    }

    public void ChangeTask(string text)
    {
        str = text;
    }
}