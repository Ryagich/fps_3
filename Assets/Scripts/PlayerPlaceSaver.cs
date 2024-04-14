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

        if (YandexGame.SDKEnabled)
        {
            Init();
        }
        else
        {
            YandexGame.GetDataEvent += Init;
        }
    }

    private void Init()
    {
        if (YandexGame.savesData.x[id] != 0)
        {
            _playerSpawner.transform.position = new
            (YandexGame.savesData.x[id],
                YandexGame.savesData.y[id],
                YandexGame.savesData.z[id]);
        }
        YandexGame.GetDataEvent -= Init;
    }

    public void Save(float x, float y, float z)
    {
        YandexGame.savesData.x[id] = x;
        YandexGame.savesData.y[id] = y;
        YandexGame.savesData.z[id] = z;
        YandexGame.SaveProgress();
    }
}