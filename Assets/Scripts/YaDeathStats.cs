using System.Collections;
using System.Collections.Generic;
using NeoFPS;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class YaDeathStats : MonoBehaviour
{
    private void Start()
    {
        var z = GetComponent<BasicHealthManager>();
        z.onIsAliveChanged += alive =>
        {
            if (alive == false)
                Send();
        };
    }

    void Send()
    {
        var triggerValue = $"Scene:{SceneManager.GetActiveScene().name} Death";
        var eventParams = new Dictionary<string, string>
        {
            { "death", triggerValue }
        };
        YG2.MetricaSend("death", eventParams);
    }
}