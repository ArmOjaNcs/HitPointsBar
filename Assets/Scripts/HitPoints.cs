using System;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private HitZone _hitZone;

    public event Action<float> HitPointsUpdate;

    public float MaxValue => _maxValue;
    public float CurrentValue { get; private set; }

    private float PreviousValue => CurrentValue / MaxValue;

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    private void OnEnable()
    {
        _hitZone.DamageDetected += OnDamageDetected;
        _hitZone.MedPackDetected += OnMedPackDetected;
    }

    private void OnDisable()
    {
        _hitZone.DamageDetected -= OnDamageDetected;
        _hitZone.MedPackDetected -= OnMedPackDetected;
    }

    private void OnDamageDetected(float damage)
    {
        float previousValue = PreviousValue;
        CurrentValue -= damage;

        if (CurrentValue < 0)
            CurrentValue = 0;

        HitPointsUpdate?.Invoke(previousValue);
    }

    private void OnMedPackDetected(float heal)
    {
        float previousValue = PreviousValue;
        CurrentValue += heal;

        if(CurrentValue > MaxValue)
            CurrentValue = MaxValue;

        HitPointsUpdate?.Invoke(previousValue);
    }
}