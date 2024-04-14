using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeoFPS.Samples;
using YG;

public class OpenLVLChecker : MonoBehaviour
{
    [SerializeField] private SpMenuLevelSelect menu;

    private void Awake()
    {
        if (menu.LvlCreated)
        {
            Init();
        }
        else
        {
            menu.OnEndCreateLvls += Init;
        }
    }

    private void Init()
    {
        if (YandexGame.SDKEnabled)
        {
            InitInit();
        }
        else
        {
            YandexGame.GetDataEvent += InitInit;
        }
        
    }

    private void InitInit()
    {
        for (int i = 0; i < YandexGame.savesData.openLevels.Length; i++)
        {
            menu.m_Entries[i].interactable = YandexGame.savesData.openLevels[i];
        }
    }
}
