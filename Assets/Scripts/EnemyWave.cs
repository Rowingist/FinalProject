using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private int _quantity;
    [SerializeField] private float _delay;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _delayReducer;

    public float Delay { get; private set; }
    public int Quantity => _quantity;

    private void OnEnable()
    {
        _spawner.NewWaveSpawned += OnReduceDelay;
    }

    private void Start()
    {
        Delay = _delay;
    }

    private void OnDisable()
    {
        _spawner.NewWaveSpawned -= OnReduceDelay;
    }

    private void OnReduceDelay()
    {
        Delay -= _delayReducer;
    }

    public GameObject GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, _enemyTemplates.Length);
        return _enemyTemplates[randomIndex];
    }
}
