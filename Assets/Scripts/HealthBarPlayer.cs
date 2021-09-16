using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private HealthPlayer _healthPlayer;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Button _boardHealth;
    [SerializeField] private Text _boarfHealthText;

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
        _healthPlayer.OnHealthValueChanged += OnHealthValueChanged;
        _healthPlayer.OnPlayerIsAliveValueChanged += OnPlayerIsAliveValueChanged;
    }

    private void OnPlayerIsAliveValueChanged(bool isAlive)
    {
        if (!isAlive)
        {
            _boardHealth.image.color = Color.red;
            _boarfHealthText.text = "Погиб";
        }
    }

    private void OnDisable()
    {
        _healthPlayer.OnHealthValueChanged -= OnHealthValueChanged;
    }

    public void OnHealthValueChanged(float newValueHealth, float damageOrHeal)
    {   
        if (_setHealth != null)
        {
            StopCoroutine(_setHealth);
        }
        else
        {
            _setHealth = StartCoroutine(SetHealth(newValueHealth, damageOrHeal));
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
    }

}
