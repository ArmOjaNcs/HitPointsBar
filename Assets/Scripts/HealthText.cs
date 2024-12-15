using TMPro;
using UnityEngine;

public class HealthText : ViewUpdate
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = Health.CurrentValue + "/" + Health.MaxValue;
    }

    private protected override void OnHealthUpdate()
    {
        _text.text = Health.CurrentValue + "/" + Health.MaxValue;
    }
}