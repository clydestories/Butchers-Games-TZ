using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private const string Money = nameof(Money);

    private int _money;

    public event Action<int> AmountChanged;

    private void Start()
    {
        _money = PlayerPrefs.GetInt(Money, 0);
        AmountChanged?.Invoke(_money);
    }

    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't add negative amount of money");
        }

        _money += amount;
        PlayerPrefs.SetInt(Money, _money);
        AmountChanged?.Invoke(_money);
    }

    public void RemoveMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't remove negative amount of money");
        }

        _money -= amount;
        PlayerPrefs.SetInt(Money, _money);
        AmountChanged?.Invoke(_money);
    }
}
