using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public delegate void HealthPlayerHandler(float newValueHealth, float damageOrHeal);
    public event HealthPlayerHandler OnHealthValueChanged;
    public delegate void PlayerIsAliveHandler(bool isAlive);
    public event PlayerIsAliveHandler OnPlayerIsAliveValueChanged;

    [SerializeField] private float _maxHealth = 100f;

    private float _minHealth = 0f;

    public float Health { get; private set; }
    public bool IsAlive { get; private set; }

    private void Awake()
    {
        IsAlive = true;
        Health = _maxHealth;
    }


    public void TakeDamage(float damage)
    { 
        Health -= damage;

        if (Health <= _minHealth)
        {
            gameObject.SetActive(false);
            IsAlive = false;
            Debug.Log("Погиб");

            OnPlayerIsAliveValueChanged?.Invoke(IsAlive);
        }

        OnHealthValueChanged?.Invoke(Health, damage);
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

            OnHealthValueChanged?.Invoke(Health, heal);
        }
    }
}
