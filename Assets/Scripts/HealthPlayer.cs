using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    public delegate void HealthPlayerHandler(float newValueHealth, float damageOrHeal);
    public event HealthPlayerHandler OnHealthValueChangedEvent;

    [SerializeField] private float _maxHealth = 100f;

    private float _minHealth = 0f;

    public float Health { get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
    }

    private void Update()
    {
        Die();
    }

    public void TakeDamage(float damage)
    { 
        Health -= damage;

        OnHealthValueChangedEvent?.Invoke(Health, damage);
    }

    public void TakeHeal(float heal)
    {
        if (Health >= _maxHealth)
        {
            Health = _maxHealth;
        }
        else
        {
            Health += heal;

            OnHealthValueChangedEvent?.Invoke(Health, heal);
        }
    }

    private void Die()
    {
        if (Health <= _minHealth)
        {
            gameObject.SetActive(false);
        }
    }
}
