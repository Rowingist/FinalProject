using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private EnemyWave _enemyWave;

    private float _timeTillSpawn;

    private void Update()
    {
        if (_timeTillSpawn <= 0)
            _timeTillSpawn = _enemyWave.Delay;

        _timeTillSpawn -= Time.deltaTime;
        _timer.text = Math.Round(_timeTillSpawn, 0).ToString();
    }
}
