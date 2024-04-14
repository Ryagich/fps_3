using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeoFPS;
using NeoFPS.Constants;

public class TextCloseDoor : MonoBehaviour
{
    [TextArea] [SerializeField] private string _closeText;
    [TextArea] [SerializeField] private string _openText;
    [TextArea] [SerializeField] private string _closeTask;
    [TextArea] [SerializeField] private string _openTask;
    [SerializeField] private DoorBase _base;
    
    private bool isOpen = false;
    private void Awake()
    {
        var d = GetComponent<LockedDoorInteractiveObject>();
        d.onUsed += c =>
        {
            if(isOpen)
                return;
            var unlock = false;
            var inventory = c.GetComponent<IInventory>();
            var keyRing = inventory.GetItem(FpsInventoryKey.KeyRing) as IKeyRing;
            if (keyRing != null)
            {
                for (int i = 0; i < d.m_LockIds.Length; ++i)
                {
                    if (keyRing.ContainsKey(d.m_LockIds[i]))
                    {
                        unlock = true;
                        break;
                    }
                }
            }

            if (unlock)
            {
                SubsController.Instance.WriteText(_openText);
                TaskManager.Instance.ChangeTask(_openTask);
                isOpen = true;
            }
            else
            {
                SubsController.Instance.WriteText(_closeText);
                TaskManager.Instance.ChangeTask(_closeTask);
            }
        };
    }
}