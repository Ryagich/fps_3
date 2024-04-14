using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeoFPS;

public class TriggerIdleText : TriggerText
{
    [TextArea]
    [SerializeField] private string _actionText;

    private void Awake()
    {
        var z = GetComponent<CharacterTriggerZone>();
        z.onTriggerEnter += c =>
        {
            if (SceneStateController.SceneState == SceneStates.Idle)
            {
                SubsController.Instance.WriteText(_text);
                Destroy(z);
            }
            else if (SceneStateController.SceneState == SceneStates.Action)
            {
                SubsController.Instance.WriteText(_actionText);
                Destroy(z);
            }
        };
    }
}