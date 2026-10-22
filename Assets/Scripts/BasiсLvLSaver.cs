using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class BasiсLvLSaver : MonoBehaviour
{
    [SerializeField] private int lvlId;

    public void Save()
    {
        if (YG2.saves.openLevels.Length > lvlId + 1)
        {
            YG2.saves.openLevels[lvlId + 1] = true;
            YG2.SaveProgress();
        }
    }
}