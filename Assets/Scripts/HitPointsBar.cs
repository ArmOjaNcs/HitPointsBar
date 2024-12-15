using UnityEngine;
using UnityEngine.UI;

public class HitPointsBar : VisualUpdate
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = Health.CurrentValue / Health.MaxValue;
    }

    private protected override void OnHitPointsUpdate()
    {
        _slider.value = Health.CurrentValue / Health.MaxValue;
    }
}