using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<float> Clicked;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float halfScreen = Screen.width / 2;
            float percentOffsetX = (Input.mousePosition.x - halfScreen) / halfScreen;
            Clicked?.Invoke(percentOffsetX);
        }
    }
}
