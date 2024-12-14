using System.Collections;
using TMPro;
using UnityEngine;

public class HitPointsText : MonoBehaviour, IVisualUpdate
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private HitPoints _hitPoints;
    
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
        _text.text = _hitPoints.CurrentHitPoints + "/" + _hitPoints.MaxHitPoints;
        SmoothDuration = 0.3f;
    }

    public IEnumerator UpdateVisual(float previousHitPointsValue)
    {
        float elapsedTime = 0;

        while (elapsedTime < SmoothDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / SmoothDuration;
            float currentValue = Mathf.Lerp(previousHitPointsValue, _hitPoints.CurrentHitPoints / _hitPoints.MaxHitPoints, normalizedPosition);
            _text.text = (Mathf.Round(currentValue * _hitPoints.MaxHitPoints)).ToString() + "/" + _hitPoints.MaxHitPoints;

            yield return null;
        }
    }

    private void OnHitPointsUpdate(float previousHitPointsValue)
    {
        StartCoroutine(UpdateVisual(previousHitPointsValue));
    }
}