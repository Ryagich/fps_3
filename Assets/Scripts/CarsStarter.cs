using NeoFPS;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CarsStarter : MonoBehaviour
{
    [SerializeField] private List<Transform> _cars = new();

    [SerializeField] private List<Vector3> _targets = new();
    [SerializeField, Min(.0f)] private float _speed = 70;
    [SerializeField, Min(.0f)] private float _time = .5f;
    [SerializeField] private AudioClip _clip;

    private CharacterTriggerZone zone;

    private void Start()
    {
        zone = GetComponent<CharacterTriggerZone>();
        zone.onTriggerEnter += StartCars;
    }

    private void StartCars(ICharacter c)
    {
        Destroy(zone);
        StartCoroutine(MoveCars());
    }

    private IEnumerator MoveCars()
    {
        for (int i = 0; i < _cars.Count; i++)
        {
            StartCoroutine(MoveCar(_cars[i], _targets[i]));
            _cars[i].GetComponent<AudioSource>().PlayOneShot(_clip);
            yield return new WaitForSeconds(_time);
        }
    }

    private IEnumerator MoveCar(Transform car, Vector3 target)
    {
        while (Vector3.Distance(car.position, target) > .1f)
        {
            car.position = Vector3.MoveTowards(car.position, target, _speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}