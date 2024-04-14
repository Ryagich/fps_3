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
    //     if (YandexGame.SDKEnabled)
    //     {
    //         YandexGame.GetDataEvent += Init;
    //         Debug.Log("YandexGame.SDKEnabled");
    //     }
    //     else
    //     {
    //         YandexGame.GetDataEvent += Init;
    //         Debug.Log("NOT YandexGame.SDKEnabled");
    //     }
    // }
    //
    // private void Init()
    // {
    //     if (YandexGame.savesData.AdsVariant != 0)
    //         return;
    //     var variant = Random.Range(0f, 1f);
    //     if (variant > .2f)
    //     {
    //         var value = $"Реклама каждую минуту";
    //         var eventParams = new Dictionary<string, string>
    //         {
    //             { "event", value }
    //         };
    //         YandexMetrica.Send("event", eventParams);
    //         YandexGame.savesData.AdsVariant = 1;
    //     }
    //     else
    //     {
    //         var value = $"Реклама каждые 5 минут";
    //         var eventParams = new Dictionary<string, string>
    //         {
    //             { "event", value }
    //         };
    //         YandexMetrica.Send("event", eventParams);
    //         YandexGame.savesData.AdsVariant = 2;
    //     }
    //
    //     YandexGame.SaveProgress();
    // }
}