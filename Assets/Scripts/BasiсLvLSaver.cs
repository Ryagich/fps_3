using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class BasiсLvLSaver : MonoBehaviour
{
    [SerializeField] private int lvlId;

    public void Save()
    {
        if (YandexGame.savesData.openLevels.Length > lvlId + 1)
        {
            YandexGame.savesData.openLevels[lvlId + 1] = true;
            YandexGame.SaveProgress();
        }
    }
}