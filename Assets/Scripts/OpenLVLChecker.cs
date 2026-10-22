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
        if (YG2.isSDKEnabled)
        {
            InitInit();
        }
        else
        {
            YG2.onGetSDKData += InitInit;
        }
        
    }

    private void InitInit()
    {
        for (int i = 0; i < YG2.saves.openLevels.Length; i++)
        {
            menu.m_Entries[i].interactable = YG2.saves.openLevels[i];
        }
    }
}
