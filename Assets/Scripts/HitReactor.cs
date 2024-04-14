using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HitReactor : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Reaction()
    {
        source.pitch = 1 + Random.Range(-0.1f, 0.1f);
        source.PlayOneShot(_clip, .35f);
    }
}