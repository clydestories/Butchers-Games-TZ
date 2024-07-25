using ButchersGames;
using System;
using UnityEngine;

public class LevelLauncher : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Canvas _startUI;
    [SerializeField] private Canvas _ingameStatsUI;

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
        _startUI.enabled = false;
        _ingameStatsUI.enabled = true;
        enabled = false;
    }
}
