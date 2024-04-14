using NeoFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSpawner : MonoBehaviour
{
    [SerializeField, Min(0)] private int _enemyCount;
    [SerializeField] private Transform _spawnPoint;
    public List<Transform> _patrolPoints = new();

    private bool isUse = false;

    private void Awake()
    {
        GetComponent<CharacterTriggerZone>().onTriggerEnter += c =>
        {
            if (!isUse)
            {
                for (int i = 0; i < _enemyCount; i++)
                {
                    EnemyController.Instance.SpawnEnemy(_spawnPoint, _patrolPoints);
                }
                isUse = true;
            }
        };
    }
}
