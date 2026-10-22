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
        if (YG2.isSDKEnabled)
        {
            Init();
        }
        else
        {
            YG2.onGetSDKData += Init;
        }
    }

    public void Init()
    {
        if (YG2.saves.BossAlive )
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
        YG2.saves.BossAlive = false;
        YG2.SaveProgress();
    }
    
    public void RespawnBoss()
    {
        YG2.saves.BossAlive = true;
        YG2.SaveProgress();
    }
}