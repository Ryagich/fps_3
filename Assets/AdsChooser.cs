using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AdsChooser : MonoBehaviour
{
    // 0 - not choose; 1 - 1min; 2 - 5 min
    // 80% - 1 min; 20 % - 5 min
    // private void Start()
    // {
    //     if (YG2.isSDKEnabled)
    //     {
    //         YG2.onGetSDKData += Init;
    //         Debug.Log("YG2.isSDKEnabled");
    //     }
    //     else
    //     {
    //         YG2.onGetSDKData += Init;
    //         Debug.Log("NOT YG2.isSDKEnabled");
    //     }
    // }
    //
    // private void Init()
    // {
    //     if (YG2.saves.AdsVariant != 0)
    //         return;
    //     var variant = Random.Range(0f, 1f);
    //     if (variant > .2f)
    //     {
    //         var value = $"Реклама каждую минуту";
    //         var eventParams = new Dictionary<string, string>
    //         {
    //             { "event", value }
    //         };
    //         YG2.MetricaSend("event", eventParams);
    //         YG2.saves.AdsVariant = 1;
    //     }
    //     else
    //     {
    //         var value = $"Реклама каждые 5 минут";
    //         var eventParams = new Dictionary<string, string>
    //         {
    //             { "event", value }
    //         };
    //         YG2.MetricaSend("event", eventParams);
    //         YG2.saves.AdsVariant = 2;
    //     }
    //
    //     YG2.SaveProgress();
    // }
}