using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private HitPoints _hitPoints;

    private float _smoothDuration = 0.75f;

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
        _text.text = _hitPoints.MaxHitPoints + "/" + _hitPoints.MaxHitPoints;
    }

    private void OnHitPointsUpdate(float currentValue, float targetValue)
    {       
        StartCoroutine(UpdateBar(currentValue, targetValue));
    }

    private IEnumerator UpdateBar(float currentValue, float targetValue)
    {
        float elapsedTime = 0;

        while (elapsedTime < _smoothDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothDuration;
            _slider.value = Mathf.MoveTowards(currentValue, targetValue, normalizedPosition);
            _text.text = (Mathf.Round(_slider.value * _hitPoints.MaxHitPoints)).ToString() + "/" + _hitPoints.MaxHitPoints;
            yield return null;
        }
    }
}