using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _target;
    
    public void ChangePlace()
    {
        _transform.position = _target.position;
    }
}
