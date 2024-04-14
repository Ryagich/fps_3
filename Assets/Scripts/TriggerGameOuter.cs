using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NeoFPS;

public class TriggerGameOuter : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggered;
    private void Awake()
    {
        var z = GetComponent<CharacterTriggerZone>();
        z.onTriggerEnter += c =>
        {
            _triggered?.Invoke();
        };
    }
}
