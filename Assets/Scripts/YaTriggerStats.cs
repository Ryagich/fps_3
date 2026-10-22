using System;
using System.Collections;
using System.Collections.Generic;
using NeoFPS;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using YG;

public class YaTriggerStats : MonoBehaviour
{
    [SerializeField] private string _triggerText;
    
    private void Start()
    {
        var z = GetComponent<CharacterTriggerZone>();
        z.onTriggerEnter += c => { Send(); };
    }

    void Send()
    {
        var triggerValue = $"Scene:{SceneManager.GetActiveScene().name} Trigger:{_triggerText}";
        var eventParams = new Dictionary<string, string>
        {
            { "triggers", triggerValue }
        };
        YG2.MetricaSend("triggers", eventParams);
    }
}