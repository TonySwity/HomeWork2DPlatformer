using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _minHealth = 0f;

    public float Health { get; private set; }
    public bool IsAlive { get; private set; }

    public delegate void HealthPlayerHandler(float newValueHealth, float damageOrHeal);
    public event HealthPlayerHandler HealthValueChanged;
    //public event UnityAction<float, float> HealthValueChanged;
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
        else
        {
            HealthValueChanged?.Invoke(Health, damage);
        }
        Debug.Log("TakeDamage");

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
        Debug.Log("TakeHeal");
    }
}
