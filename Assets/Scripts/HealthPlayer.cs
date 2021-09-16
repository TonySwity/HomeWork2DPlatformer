using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _minHealth = 0f;

    public float Health { get; private set; }
    public bool IsAlive { get; private set; }

    public delegate void HealthPlayerHandler(float newValueHealth, float damageOrHeal);
    public event HealthPlayerHandler HealthValueChanged;
    public delegate void PlayerIsAliveHandler();
    public event PlayerIsAliveHandler Died;

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

            Died?.Invoke();
        }

        HealthValueChanged?.Invoke(Health, damage);
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

            HealthValueChanged?.Invoke(Health, heal);
        }
    }
}
