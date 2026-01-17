using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _healthFill;


    public void SetMaxHealth(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;

        _healthFill.color = _gradient.Evaluate(maxHealth);
    }

    public void SetHealth(int health)
    {
        _healthBar.value = health;
        _healthFill.color = _gradient.Evaluate(_healthBar.normalizedValue);
    }

    public void SetNewMaxHealth(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthFill.color = _gradient.Evaluate(_healthBar.normalizedValue);
    }
}
