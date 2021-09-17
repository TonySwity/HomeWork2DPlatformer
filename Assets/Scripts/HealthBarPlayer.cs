using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private HealthPlayer _healthPlayer;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Button _boardHealth;
    [SerializeField] private Text _boarfHealthText;

    private float _maxHealth;

    private Coroutine _setHealth;

    private void Start()
    {
        _maxHealth = _healthPlayer.Health;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _maxHealth;    
    }

    private void OnEnable()
    {
        _healthPlayer.HealthValueChanged += OnHealthValueChanged;
        _healthPlayer.Died += OnDied;
    }

    private void OnDisable()
    {
        _healthPlayer.HealthValueChanged -= OnHealthValueChanged;
        _healthPlayer.Died -= OnDied;
    }

    private void OnHealthValueChanged(float newValueHealth, float damageOrHeal)
    {   
        if (_setHealth != null)
        {
            StopCoroutine(_setHealth);
            _setHealth = null;
        }
        else
        {
            _setHealth = StartCoroutine(SetHealth(newValueHealth, damageOrHeal));
        }
    }

    private IEnumerator SetHealth(float newValue, float duration)
    {
        while (_healthSlider.value != newValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, newValue, duration * Time.deltaTime);

            yield return null;
        }
    }

    private void OnDied()
    {
            _boardHealth.image.color = Color.red;
            _boarfHealthText.text = "Погиб";
    }
}
