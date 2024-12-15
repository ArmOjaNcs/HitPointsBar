using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = Health.CurrentValue / Health.MaxValue;
    }

    private protected override void OnHealthUpdate()
    {
        _slider.value = Health.CurrentValue / Health.MaxValue;
    }
}