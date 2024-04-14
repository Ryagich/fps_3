using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class AdsManager : MonoBehaviour
{
    [SerializeField, Min(0)] private int time_between = 5;
    private string ru = "Реклама через";
    private string tr = "Reklam aracılığıyla";
    private string en = "Ad through";

    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        text.gameObject.SetActive(false);
    }

    private IEnumerator Cooldown()
    {
        var s = YandexGame.savesData.AdsVariant == 1 ? 60 : 300;
        while (true)
        {
            yield return new WaitForSeconds(s);
            text.gameObject.SetActive(true);
            var t = time_between;
            while (t > 0)
            {
                var str = YandexGame.EnvironmentData.language == "ru" ? ru :
                    YandexGame.EnvironmentData.language == "tr" ? tr : en;
                text.text = str + " " + t;
                yield return new WaitForSeconds(1);
                t--;
            }

            text.gameObject.SetActive(false);
            YandexGame.FullscreenShow();
        }
    }
}