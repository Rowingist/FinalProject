using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWave> _enemyWaves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private EnemyWave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _quantityKilledEnemies;

    public EnemyWave CurrentWave => _currentWave;

    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction NewWaveSpawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);
        InstantiateEnemy();
        _spawned++;
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn > _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Quantity <= _spawned)
            _currentWave = null;

        if (_quantityKilledEnemies % _spawnPoints.Length == 0)
        {
            _quantityKilledEnemies = 0;
            EnemyCountChanged?.Invoke(_quantityKilledEnemies, _spawnPoints.Length);
        }
    }

    private void InstantiateEnemy()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Enemy enemy = Instantiate(_currentWave.GetRandomEnemy(), _spawnPoints[i].position, _spawnPoints[i].rotation, _spawnPoints[i]).GetComponent<Enemy>();
            enemy.Init(_player);
            enemy.HasDied += OnEnemyDead;
        }

        NewWaveSpawned?.Invoke();
    }

    private void SetWave(int waveNumber)
    {
        _currentWave = _enemyWaves[waveNumber];
    }

    private void OnEnemyDead(Enemy enemy)
    {
        _quantityKilledEnemies++;
        EnemyCountChanged?.Invoke(_quantityKilledEnemies, _spawnPoints.Length);
        enemy.HasDied -= OnEnemyDead;
    }
}
