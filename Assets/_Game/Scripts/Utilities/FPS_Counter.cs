using UnityEngine;

public class FPS_Counter : MonoBehaviour
{
    int fps;

    private void Update()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
    }
}
