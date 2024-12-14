using System.Collections;
using TMPro;
using UnityEngine;

public class HitPointsText : MonoBehaviour, IVisualUpdate
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private HitPoints _hitPoints;

    private readonly float _smoothDuration = 0.3f;

    public float SmoothDuration { get; set; }

    private void OnEnable()
    {
        _hitPoints.HitPointsUpdate += OnHitPointsUpdate;
    }

    private void OnDisable()
    {
        _hitPoints.HitPointsUpdate += OnHitPointsUpdate; 
    }

    private void Start()
    {
        _text.text = _hitPoints.CurrentValue + "/" + _hitPoints.MaxValue;
        SmoothDuration = _smoothDuration;
    }

    public IEnumerator UpdateVisual(float previousValue)
    {
        float elapsedTime = 0;

        while (elapsedTime < SmoothDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / SmoothDuration;
            float currentValue = Mathf.Lerp(previousValue, _hitPoints.CurrentValue / _hitPoints.MaxValue, normalizedPosition);
            _text.text = (Mathf.Round(currentValue * _hitPoints.MaxValue)).ToString() + "/" + _hitPoints.MaxValue;

            yield return null;
        }
    }

    private void OnHitPointsUpdate(float previousValue)
    {
        StartCoroutine(UpdateVisual(previousValue));
    }
}