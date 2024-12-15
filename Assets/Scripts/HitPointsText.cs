using TMPro;
using UnityEngine;

public class HitPointsText : VisualUpdate
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = Health.CurrentValue + "/" + Health.MaxValue;
    }

    private protected override void OnHitPointsUpdate()
    {
        _text.text = Health.CurrentValue + "/" + Health.MaxValue;
    }
}