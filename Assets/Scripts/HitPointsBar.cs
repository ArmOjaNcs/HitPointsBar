using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsBar : MonoBehaviour, IVisualUpdate
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HitPoints _hitPoints;

    private readonly float _smoothDuration = 0.75f;

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
        SmoothDuration = _smoothDuration;
    }

    public IEnumerator UpdateVisual(float previousValue)
    {
        float elapsedTime = 0;

        while (elapsedTime < SmoothDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / SmoothDuration;
            _slider.value = Mathf.MoveTowards(previousValue, _hitPoints.CurrentValue / _hitPoints.MaxValue, normalizedPosition);

            yield return null;
        }
    }

    private void OnHitPointsUpdate(float previousValue)
    {       
        StartCoroutine(UpdateVisual(previousValue));
    }
}