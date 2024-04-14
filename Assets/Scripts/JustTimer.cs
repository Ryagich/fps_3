using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class JustTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent _timeOut;
    [SerializeField, Min(.0f)] private float _time = 2;
    
    public void StartTimer()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        var timeLeft = TimeSpan.FromMinutes(_time);
        while (timeLeft.TotalSeconds > 0)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));

            yield return new WaitForSeconds(1);
        }

        _timeOut?.Invoke();
    }
}
