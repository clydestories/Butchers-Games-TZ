using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;

    public event Action<int> AmountChanged;

    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't add negative amount of money");
        }

        _money += amount;
        AmountChanged?.Invoke(_money);
    }

    public void RemoveMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't remove negative amount of money");
        }

        _money -= amount;
        AmountChanged?.Invoke(_money);
    }
}
