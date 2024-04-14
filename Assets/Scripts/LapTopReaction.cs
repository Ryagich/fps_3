using NeoFPS;
using UnityEngine;

public class LapTopReaction : MonoBehaviour
{
    [TextArea] [SerializeField] private string _LvLEndText;
    [TextArea] [SerializeField] private string _LvLEndTask;
    
    private void Awake()
    {
        var i = GetComponent<InteractiveObject>();
        i.onUsed += c =>
        {
            i.enabled = false;
            TaskManager.Instance.ChangeAndUpdateTask(_LvLEndTask);
            SubsController.Instance.WriteText(_LvLEndText);
        };
    }
}
