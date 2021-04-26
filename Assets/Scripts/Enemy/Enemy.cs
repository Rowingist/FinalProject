using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private int _currentHealth;

    private Player _target;

    public Player Target => _target;

    public event UnityAction<bool> HasHurt;
    public event UnityAction<bool> ReachedTarget;
    public event UnityAction<Enemy> HasDied;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if (_currentHealth <= 0)
        {
            HasDied?.Invoke(this);
            _target.EncreaseScore();
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, _target.transform.position) <= 1)
            ReachedTarget?.Invoke(true);
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void ApplyDamage(int damage)
    {
        HasHurt?.Invoke(true);
        _currentHealth -= damage;
    }

    public void Attack(Player target)
    {
        target.ApplyDamage(_damage);
    }
}
