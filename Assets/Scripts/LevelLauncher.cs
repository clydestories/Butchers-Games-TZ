using System;
using UnityEngine;

public class LevelLauncher : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action Started;

    private void OnEnable()
    {
        _inputReader.Clicked += StartLevel;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= StartLevel;
    }

    private void StartLevel(float _)
    {
        Started?.Invoke();
        enabled = false;
    }
}
