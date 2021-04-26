using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnValueChanged;
        _spawner.NewWaveSpawned += OnBarReset;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
        _spawner.NewWaveSpawned -= OnBarReset;
    }

    private void OnBarReset()
    {
        Slider.value = 0;
    }
}
