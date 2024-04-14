using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceSaverObject : MonoBehaviour
{
    [SerializeField] private Transform place;

    public void Save()
    {
        PlayerPlaceSaver.Instance.Save(place.position.x, place.position.y, place.position.z);
    }
}