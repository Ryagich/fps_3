using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeoFPS;

public class KeyTextPickUpReact : MonoBehaviour
{
    [TextArea] [SerializeField] private string _text;

    private void Awake()
    {
        GetComponent<InteractiveObject>().onUsed += c => { SubsController.Instance.WriteText(_text); };
    }
}