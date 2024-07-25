using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WealthDisplay : MonoBehaviour
{
    [SerializeField] private Wealth _wealth;
    [SerializeField] private Slider _wealthBar;
    [SerializeField] private TextMeshProUGUI _wealthLevelText;
    [SerializeField] private TextMeshProUGUI _wealthAmountText;
    [SerializeField] private Color _hoboColor;
    [SerializeField] private Color _poorColor;
    [SerializeField] private Color _decentColor;
    [SerializeField] private Color _richColor;
    [SerializeField] private Color _millionaireColor;

    private Dictionary<WealthLevel, Color> _wealthColors;

    private void Awake()
    {
        _wealthColors = new Dictionary<WealthLevel, Color>()
        {
            { WealthLevel.Hobo, _hoboColor},
            { WealthLevel.Poor, _poorColor},
            { WealthLevel.Decent, _decentColor},
            { WealthLevel.Rich, _richColor},
            { WealthLevel.Millionaire, _millionaireColor}
        };
    }

    private void OnEnable()
    {
        _wealth.WealthChanged += UpdateWealth;
    }

    private void OnDisable()
    {
        _wealth.WealthChanged -= UpdateWealth;
    }

    private void UpdateWealth(WealthLevel level, float currentAmount, float maxAmount)
    {
        _wealthLevelText.text = level.ToString();
        _wealthLevelText.color = _wealthColors[level];
        _wealthAmountText.text = currentAmount.ToString();
        _wealthBar.value = currentAmount / maxAmount;
    }
}
