using NeoFPS;
using UnityEngine;

public class TextContinue : MonoBehaviour
{
    [SerializeField] private TriggerText _triggerText;
    [SerializeField] private string _text;

    private SubsController subs;

    private void Awake()
    {
        var z = GetComponent<CharacterTriggerZone>();
        z.onTriggerEnter += c =>
        {
            subs = SubsController.Instance;
            subs.EndWrite += PlayNextStep;
            subs.CantEndedWrite -= PlayNextStep;
            subs.CantEndedHide -= PlayNextStep;
        };
    }

    private void PlayNextStep()
    {
        SubsController.Instance.WriteText(_text);
        subs.EndWrite -= PlayNextStep;
    }
}
