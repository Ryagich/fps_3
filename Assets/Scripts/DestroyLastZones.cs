using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeoFPS;

public class DestroyLastZones : MonoBehaviour
{
    [SerializeField] private List<GameObject> _zones = new();

    private void Awake()
    {
        var z = GetComponent<CharacterTriggerZone>();
        z.onTriggerEnter += c =>
        {
            foreach (var zone in _zones)
            {
                if (zone.gameObject)
                    Destroy(zone.gameObject);
            }
        };
    }
}