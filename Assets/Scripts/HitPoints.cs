using System;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField] private float _maxHitPoints;
    [SerializeField] private HitZone _hitZone;

    private float _hitPoints;

    public event Action<float, float> HitPointsUpdate;

    public float MaxHitPoints => _maxHitPoints;

    private float PreviousHitPoints => _hitPoints / MaxHitPoints;

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

    private void Start()
    {
        _hitPoints = MaxHitPoints;
    }

    private void OnDamageDetected(float damage)
    {
        float previousHitPointsValue = PreviousHitPoints;
        _hitPoints -= damage;

        if (_hitPoints < 0)
            _hitPoints = 0;

        HitPointsUpdate?.Invoke(previousHitPointsValue, _hitPoints / MaxHitPoints);
    }

    private void OnMedPackDetected(float heal)
    {
        float previousHitPointsValue = PreviousHitPoints;
        _hitPoints += heal;

        if(_hitPoints > MaxHitPoints)
            _hitPoints = MaxHitPoints;

        HitPointsUpdate?.Invoke(previousHitPointsValue, _hitPoints / MaxHitPoints);
    }
}