using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private protected Health Health;

    private protected void OnEnable()
    {
        Health.HealthUpdate += OnHealthUpdate;
    }

    private protected void OnDisable()
    {
        Health.HealthUpdate -= OnHealthUpdate;
    }

    private protected virtual void OnHealthUpdate() { }
}