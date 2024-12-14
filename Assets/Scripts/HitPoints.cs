using System;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField] private float _maxHitPoints;
    [SerializeField] private HitZone _hitZone;

    public event Action<float> HitPointsUpdate;

    public float MaxHitPoints => _maxHitPoints;
    public float CurrentHitPoints { get; private set; }

    private float PreviousHitPoints => CurrentHitPoints / MaxHitPoints;

    private void Awake()
    {
        CurrentHitPoints = MaxHitPoints;
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
        float previousHitPointsValue = PreviousHitPoints;
        CurrentHitPoints -= damage;

        if (CurrentHitPoints < 0)
            CurrentHitPoints = 0;

        HitPointsUpdate?.Invoke(previousHitPointsValue);
    }

    private void OnMedPackDetected(float heal)
    {
        float previousHitPointsValue = PreviousHitPoints;
        CurrentHitPoints += heal;

        if(CurrentHitPoints > MaxHitPoints)
            CurrentHitPoints = MaxHitPoints;

        HitPointsUpdate?.Invoke(previousHitPointsValue);
    }
}