using UnityEngine;

public abstract class VisualUpdate : MonoBehaviour
{
    [SerializeField] private protected HitPoints Health;

    private protected void OnEnable()
    {
        Health.HitPointsUpdate += OnHitPointsUpdate;
    }

    private protected void OnDisable()
    {
        Health.HitPointsUpdate -= OnHitPointsUpdate;
    }

    private protected virtual void OnHitPointsUpdate() { }
}