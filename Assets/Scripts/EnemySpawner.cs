using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyAI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<StateController> _prefs;
    [SerializeField] private Transform _parent;

    public StateController SpawnEnemy(Transform spawnPoint)
    {
        var enemy = Instantiate(
            _prefs[Random.Range(0, _prefs.Count)],
            spawnPoint.position,
            spawnPoint.rotation);
        enemy.transform.SetParent(_parent);
        return enemy;
    }
}