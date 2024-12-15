using System.Collections;
using UnityEngine;

public abstract class SmoothVisualUpdate : VisualUpdate
{
    [SerializeField] private protected float CurrentSmoothDuration;

    private protected float SmoothDuration;
    private protected Coroutine Coroutine;

    private protected virtual IEnumerator UpdateVisual() 
    {
        yield return null;
    }

    private protected override void OnHitPointsUpdate()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(UpdateVisual());
    }
}