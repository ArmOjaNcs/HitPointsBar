using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsBar : MonoBehaviour, IVisualUpdate
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HitPoints _hitPoints;

    public float SmoothDuration { get; set; }

    private void OnEnable()
    {
        _hitPoints.HitPointsUpdate += OnHitPointsUpdate;
    }

    private void OnDisable()
    {
        _hitPoints.HitPointsUpdate -= OnHitPointsUpdate;
    }

    private void Start()
    {
        SmoothDuration = 0.75f;
    }

    public IEnumerator UpdateVisual(float previousHitPointsValue)
    {
        float elapsedTime = 0;

        while (elapsedTime < SmoothDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / SmoothDuration;
            _slider.value = Mathf.MoveTowards(previousHitPointsValue, _hitPoints.CurrentHitPoints / _hitPoints.MaxHitPoints, normalizedPosition);

            yield return null;
        }
    }

    private void OnHitPointsUpdate(float previousHitPointsValue)
    {       
        StartCoroutine(UpdateVisual(previousHitPointsValue));
    }
}