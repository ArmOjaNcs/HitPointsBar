using System.Collections;
using UnityEngine;

public abstract class ViewSmoothedUpdate : ViewUpdate
{
    [SerializeField] private protected float CurrentSmoothDuration;

    private protected float SmoothDuration;
    private protected Coroutine Coroutine;

    private protected virtual IEnumerator UpdateView() 
    {
        yield return null;
    }

    private protected override void OnHealthUpdate()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(UpdateView());
    }
}