using System;
using System.Collections.Generic;
using UnityEngine;

public class Wealth : MonoBehaviour
{
    private readonly List<WealthLevel> _wealthLevels = new List<WealthLevel>()
    {
        WealthLevel.Hobo,
        WealthLevel.Poor,
        WealthLevel.Decent,
        WealthLevel.Rich,
        WealthLevel.Millionaire
    };

    [SerializeField] private float _startingWealth;
    [SerializeField] private WealthLevel _startingWealthLevel;

    private WealthLevel _level;
    private float _wealth;
    private float _maxWealth = 100;

    public event Action<WealthLevel, float, float> WealthChanged;
    public event Action<WealthLevel> WealthLevelChanged;
    public event Action Lost;

    public WealthLevel WealthLevel => _level;
    
    public float Value
    {
        get { return _wealth; }
        set
        {
            _wealth = Mathf.Clamp(value, 0, _maxWealth);
        }
    }

    private void Start()
    {
        _level = _startingWealthLevel;
        _wealth = _startingWealth;
        UpdateLevel();
        WealthChanged?.Invoke(_level, Value, _maxWealth);
    }

    public void AddWealth(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't add negative amount of wealth");
        }

        Value += amount;
        UpdateLevel();
        WealthChanged?.Invoke(_level, Value, _maxWealth);
    }

    public void RemoveWealth(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't remove negative amount of wealth");
        }

        Value -= amount;

        if (Value <= 0)
        {
            Lose();
        } 

        UpdateLevel();
        WealthChanged?.Invoke(_level, Value, _maxWealth);
    }

    private void UpdateLevel()
    {
        if (_wealthLevels.IndexOf(_level) != 0 && Value < (int)_level)
        {
            _level = _wealthLevels[_wealthLevels.IndexOf(_level) - 1];
            WealthLevelChanged?.Invoke(_level);
        }

        if (_wealthLevels.IndexOf(_level) != _wealthLevels.Count - 1 && Value >= (int)_wealthLevels[_wealthLevels.IndexOf(_level) + 1])
        {
            _level = _wealthLevels[_wealthLevels.IndexOf(_level) + 1];
            WealthLevelChanged?.Invoke(_level);
        }
    }

    private void Lose()
    {
        Lost?.Invoke();
    }
}

public enum WealthLevel
{
    Hobo = 0,
    Poor = 10,
    Decent = 40,
    Rich = 75,
    Millionaire = 90
}
