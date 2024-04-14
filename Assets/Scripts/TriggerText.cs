using NeoFPS;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    [TextArea]
    [SerializeField] protected string _text;
    [SerializeField] protected string _task;

    private void Awake()
    {
        var z = GetComponent<CharacterTriggerZone>();
        z.onTriggerEnter += c =>
        {
            SubsController.Instance.WriteText(_text);
            if (_task != "")
            {
                TaskManager.Instance.ChangeTask(_task);
            }
            Destroy(z);
        };
    }
}
