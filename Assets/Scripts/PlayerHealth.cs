using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Button _boardHealth;
    [SerializeField] private Text _boardText;

    private float _health;
    private float _minHealth = 0f;
    private float _damage = -10f;
    private float _heal = 10f;
    private Coroutine _setHealth;


    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _healthSlider.value = _health / _maxHealth;
        Die();
    }

    public void DamageCharacter()
    {
        StopCoroutineSetHealth();

        if (_health <= _minHealth)
        {
            _health = _minHealth;
        }
        else
        {
            StartCoroutineSetHealth(_damage);
        }
    }

    public void HealCharacter()
    {
        StopCoroutineSetHealth();

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            StartCoroutineSetHealth(_heal);
        }
    }

    private IEnumerator SetHealth(float damageOrHeal)
    {
        var targetHealth = _health + damageOrHeal;

        while (_health != targetHealth)
        {
            _health = Mathf.MoveTowards(_health, targetHealth, Mathf.Abs(damageOrHeal) * Time.deltaTime);

            yield return null;
        }
    }

    private void StartCoroutineSetHealth(float damageOrHeal)
    {
        if (_setHealth == null)
        {
            _setHealth = StartCoroutine(SetHealth(damageOrHeal));
        }
    }

    private void StopCoroutineSetHealth()
    {
        if (_setHealth != null)
        {
            StopCoroutine(_setHealth);
            _setHealth = null;
        }
    }

    private void Die()
    {
        if (_health <= _minHealth)
        {
            gameObject.SetActive(false);
            _boardHealth.image.color = Color.red;
            _boardText.text = "Погиб";
    
        }   
    }

    public void TakeDamage(float damage)
    {
        StopCoroutineSetHealth();

        if (_health <= _minHealth)
        {
            _health = _minHealth;
        }
        else
        {
            StartCoroutineSetHealth(damage);
        }
    }
}
