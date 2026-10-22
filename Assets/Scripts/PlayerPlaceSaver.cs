using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerPlaceSaver : MonoBehaviour
{
    public static PlayerPlaceSaver Instance;

    [SerializeField] private Transform _playerSpawner;
    [SerializeField] private int id;

    private void Awake()
    {
        Instance = this;

        if (YG2.isSDKEnabled)
        {
            Init();
        }
        else
        {
            YG2.onGetSDKData += Init;
        }
    }

    private void Init()
    {
        if (YG2.saves.x[id] != 0)
        {
            _playerSpawner.transform.position = new
            (YG2.saves.x[id],
                YG2.saves.y[id],
                YG2.saves.z[id]);
        }
        YG2.onGetSDKData -= Init;
    }

    public void Save(float x, float y, float z)
    {
        YG2.saves.x[id] = x;
        YG2.saves.y[id] = y;
        YG2.saves.z[id] = z;
        YG2.SaveProgress();
    }
}