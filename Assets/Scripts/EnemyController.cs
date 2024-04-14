using System;
using EnemyAI;
using System.Collections;
using System.Collections.Generic;
using NeoFPS;
using NeoFPS.CharacterMotion;
using UnityEngine;
using UnityEngine.Serialization;
using Action = System.Action;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;
    [SerializeField] private List<StateController> _defaultEnemies;
    [SerializeField] private Transform _target;
    [SerializeField, Min(.0f)] private float _fightView = 50;
    [SerializeField, Min(.0f)] private float _fightAngle = 60;
    [SerializeField, Min(.0f)] private float _fightR = 20;
    [SerializeField] private int _max = 20;
    [SerializeField] private List<Transform> _spawnPoints1;
    [SerializeField] private List<Transform> _spawnPoints2;
    [SerializeField] private List<Transform> _patrolPoints1;
    [SerializeField] private List<Transform> _patrolPoints2;
    [SerializeField] private float _spawnCooldown = 2f;

    private readonly List<StateController> enemies = new();
    private EnemySpawner spawner;

    private void Awake()
    {
        Instance = this;
        spawner = GetComponent<EnemySpawner>();
    }

    public void SetEnemiesSecondState()
    {
        foreach (var e in enemies)
        {
            e.SetPatrolPoints(_patrolPoints2);
        }
    }

    private void Start()
    {
        foreach (var e in _defaultEnemies)
        {
            ChangeSceneState(e);
            enemies.Add(e);
            e.GetComponent<BasicHealthManager>().onIsAliveChanged += b => enemies.Remove(e);
        }

        StartCoroutine(TrySpawn());
        SceneStateController.StateChange += () =>
        {
            foreach (var e in enemies)
            {
                if (e)
                {
                    e.SetFightStates(_fightView, _fightAngle, _fightR);
                }
            }
        };
    }

    public void ChangeMax(int newMax)
    {
        _max = newMax;
    }

    [Header("Stats Many enemies")] 
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _delay;
    [SerializeField] private int _startDelay;

    public void Spawn5Enemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_startDelay);
            for (int i = 0; i < _enemyCount; i++)
            {
                var isF = SceneStateController.Instance.IsFirstStage;
                var spawnPoint = isF
                    ? _spawnPoints1[Random.Range(0, _spawnPoints1.Count - 1)]
                    : _spawnPoints2[Random.Range(0, _spawnPoints2.Count - 1)];
                if (isF)
                {
                    var pp = new List<Transform>();
                    foreach (var t in _patrolPoints1)
                    {
                        if (Random.Range(0f, 1f) > .5)
                        {
                            pp.Add(t);
                        }
                    }

                    SpawnEnemy(spawnPoint, pp, true);
                }
                else
                {
                    SpawnEnemy(spawnPoint, _patrolPoints2);
                }
            }

            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator TrySpawn()
    {
        while (true)
        {
            var isF = SceneStateController.Instance.IsFirstStage;
            if (enemies.Count < _max)
            {
                var spawnPoint = isF
                    ? _spawnPoints1[Random.Range(0, _spawnPoints1.Count - 1)]
                    : _spawnPoints2[Random.Range(0, _spawnPoints2.Count - 1)];
                if (isF)
                {
                    var pp = new List<Transform>();
                    foreach (var t in _patrolPoints1)
                    {
                        if (Random.Range(0f, 1f) > .5)
                        {
                            pp.Add(t);
                        }
                    }

                    SpawnEnemy(spawnPoint, pp, true);
                }
                else
                {
                    SpawnEnemy(spawnPoint, _patrolPoints2);
                }
            }

            yield return new WaitForSeconds(isF
                ? _spawnCooldown + enemies.Count * .05f
                : _spawnCooldown / 2 + enemies.Count * .02f);
        }
    }

    private void SetTarget()
    {
        foreach (var e in _defaultEnemies)
        {
            if (e)
            {
                e.SetAimTarget(_target);
            }
        }
    }

    public void SpawnEnemy(Transform spawnPoint, List<Transform> patrolPoints = null, bool canChangeSceneState = false)
    {
        var enemy = spawner.SpawnEnemy(spawnPoint);
        enemy.SetAimTarget(_target);
        if (patrolPoints != null)
        {
            enemy.SetPatrolPoints(patrolPoints);
        }

        if (SceneStateController.SceneState == SceneStates.Action)
        {
            enemy.SetFightStates(_fightView, _fightAngle, _fightR);
        }
        else if (canChangeSceneState)
        {
            ChangeSceneState(enemy);
        }

        enemies.Add(enemy);
        enemy.GetComponent<BasicHealthManager>().onIsAliveChanged += b => { enemies.Remove(enemy); };
    }

    private void ChangeSceneState(StateController enemy)
    {
        enemy.GetComponent<BasicHealthManager>().onHealthChanged += (from, to, critical, source) =>
        {
            if (SceneStateController.SceneState == SceneStates.Idle)
            {
                SceneStateController.Instance.ChangeState();
            }
        };
    }

    public void OnPlayerSpawn()
    {
        if (_target)
            Destroy(_target.gameObject);
        _target = null;

        _target = GameObject.FindGameObjectWithTag("Target").transform;
        if (_target)
            SetTarget();
    }
}