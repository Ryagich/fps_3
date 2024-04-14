using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEvent _timeOut;
    [SerializeField, Min(.0f)] private float _time;
    [SerializeField] private string HangOn = "Hang On";
    [SerializeField] private string  Left= "Left";
    [SerializeField] private string  Minute= "minute";

    public void StartTimer()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        var timeLeft = TimeSpan.FromMinutes(_time);
        while (timeLeft.TotalSeconds > 0)
        {
            var str = $"{HangOn} {_time} {Minute}\n" +
                      $"{Left}: {timeLeft:mm\\:ss}";
            TaskManager.Instance.ChangeAndUpdateTask(str);
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));

            yield return new WaitForSeconds(1);
        }

        _timeOut?.Invoke();
    }
}