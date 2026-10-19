using UnityEngine;
using UnityEngine.Events;
public class PlatformsController : MonoBehaviour
{
    public UnityEvent OnCollisionPlatform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionPlatform?.Invoke();
    }
}