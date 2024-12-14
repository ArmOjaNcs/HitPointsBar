using System.Collections;

public interface IVisualUpdate
{
    public float SmoothDuration { get; set; }
    public IEnumerator UpdateVisual(float previousValue);
}