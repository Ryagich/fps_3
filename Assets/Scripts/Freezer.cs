using System.Collections;
using System.Collections.Generic;
using NeoFPS;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public void Freeze()
    {
        NeoFpsTimeScale.FreezeTime();
    }
    
    public void UnFreeze()
    {
        NeoFpsTimeScale.ResumeTime();
    }
}
