using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Menu _menu;

    private int _currentHeath;
    private int _score;

    public event UnityAction<bool> HasHurt;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<bool> HasDied;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _currentHeath = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHeath -= damage;
        HealthChanged?.Invoke(_currentHeath, _health);
        HasHurt?.Invoke(true);

        if (_currentHeath <= 0)
        {
            _menu.OpenGameOverPannel(true);
            HasDied?.Invoke(true);
        }
    }

    public void EncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
