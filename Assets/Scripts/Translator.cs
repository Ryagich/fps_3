using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Translator : MonoBehaviour
{
    [SerializeField, Multiline] private string _translations;
    [SerializeField] private Transform _canvas;
    
    private void Start()
    {
        var oldTexts = _canvas.GetComponentsInChildren<Text>();
        var texts = _canvas.GetComponentsInChildren<TMP_Text>();

        for (int t = 0; t < oldTexts.Length; t++)
        {
            
        }
    }
}
