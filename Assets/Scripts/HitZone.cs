using System;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public event Action<float> DamageDetected;
    public event Action<float> MedPackDetected;

    public void TakeDamage(float damage)
    {
        DamageDetected?.Invoke(damage);
    }

    public void TakeHeal(float heal)
    {
        MedPackDetected?.Invoke(heal);
    }
}