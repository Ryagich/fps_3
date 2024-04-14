using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateController : MonoBehaviour
{
    public static event Action StateChange;
    public static SceneStates SceneState = SceneStates.Idle;
    public static SceneStateController Instance;
    public bool IsFirstStage = true;
    
    public void Awake()
    {
        Instance = this;
        //TODO: брать состояние сцены из сохранения
    }

    public void ChangeState()
    {
        SceneState = SceneStates.Action;
        //TODO: сохраниться
        StateChange?.Invoke();
    }
}

public enum SceneStates
{
    Idle = 0,
    Action = 1
}
