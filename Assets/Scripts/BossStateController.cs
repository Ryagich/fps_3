using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class BossStateController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onInit;
    [SerializeField] private float _time = 0.2f;

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
        {
            Init();
        }
        else
        {
            YandexGame.GetDataEvent += Init;
        }
    }

    public void Init()
    {
        if (YandexGame.savesData.BossAlive )
            return;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_time);
        _onInit?.Invoke();

    }
    public void BossDeath()
    {
        YandexGame.savesData.BossAlive = false;
        YandexGame.SaveProgress();
    }
    
    public void RespawnBoss()
    {
        YandexGame.savesData.BossAlive = true;
        YandexGame.SaveProgress();
    }
}