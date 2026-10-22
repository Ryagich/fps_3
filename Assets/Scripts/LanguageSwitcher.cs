using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using YG;

public class LanguageSwitcher : MonoBehaviour
{
    private void Start()
    {
        if (YG2.isSDKEnabled)
        {
            YG2.onGetSDKData += () => StartCoroutine(WI());
            Debug.Log("YG2.isSDKEnabled");
        }
        else
        {
            YG2.onGetSDKData += () => StartCoroutine(WI());
            Debug.Log("NOT YG2.isSDKEnabled");
        }
    }

    private IEnumerator WI()
    {
        yield return new WaitForSeconds(2);
        Init();
    }
    private void Init()
    {
        LocalizationSettings.Instance.GetInitializationOperation();
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            Debug.Log($"{locale.Identifier.Code} == {YG2.envir.language}");
            Debug.Log(locale.Identifier.Code.Contains(YG2.envir.language));
            if (locale.Identifier.Code.Contains(YG2.envir.language))
            {
                LocalizationSettings.SelectedLocale = locale;
                Debug.Log($"Locale is {LocalizationSettings.SelectedLocale.Identifier.Code}");
            }
        }
    }
}