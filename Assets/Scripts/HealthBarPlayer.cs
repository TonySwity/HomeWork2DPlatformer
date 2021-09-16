using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private HealthPlayer _healthPlayer;
    [SerializeField] private Slider _healthSlider;

    private Coroutine _setHealth;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _healthPlayer.Health;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _maxHealth;    
    }

    private void OnEnable()
    {
        _healthPlayer.OnHealthValueChangedEvent += OnHealthValueChanged;
    }

    private void OnDisable()
    {
        _healthPlayer.OnHealthValueChangedEvent -= OnHealthValueChanged;
    }

    public void OnHealthValueChanged(float newValueHealth, float damageOrHeal)
    {
        if (_setHealth == null)
        {
            _setHealth = StartCoroutine(SetHealth(newValueHealth, damageOrHeal));
        }
        else if (_setHealth != null)
        {
            StopCoroutine(_setHealth);
            _setHealth = null;
        }
    }


    private IEnumerator SetHealth(float newValue, float duration)
    {
       
        while (_healthSlider.value != newValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, newValue, duration * Time.deltaTime);

            yield return null;
        }

        _setHealth = null;
    }

}
