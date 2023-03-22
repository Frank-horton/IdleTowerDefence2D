using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        TowerHealth.OnDamageTaken += UpdateHealthbar;
    }

    private void OnDisable()
    {
        TowerHealth.OnDamageTaken -= UpdateHealthbar;
    }

    private void UpdateHealthbar(int health)
    {
        float newHealth = (float)health;
        _slider.value = newHealth / 100;
    }
}