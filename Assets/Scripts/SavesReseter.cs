using System;
using UnityEngine;
using YG;

public class SavesReseter : MonoBehaviour
{
    [SerializeField] private bool reset = false;
    private void Awake()
    {
    }

    private void Init()
    {
    }

    private void Reset()
    {
        YG2.SetDefaultSaves();
        YG2.SaveProgress();
    }

    private void Update()
    {
        if (reset)
        {
            reset = false;
            Reset();
        }
    }
}
