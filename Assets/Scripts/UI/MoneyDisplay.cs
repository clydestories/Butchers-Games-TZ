using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void OnEnable()
    {
        _wallet.AmountChanged += UpdateMoneyValue;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= UpdateMoneyValue;
    }

    private void UpdateMoneyValue(int value)
    {
        _moneyText.text = value.ToString();
    }
}
