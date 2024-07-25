using System.Collections.Generic;
using UnityEngine;

public class PlayerModelChanger : MonoBehaviour
{
    [SerializeField] private GameObject _hoboModel;
    [SerializeField] private GameObject _poorModel;
    [SerializeField] private GameObject _decentModel;
    [SerializeField] private GameObject _richModel;
    [SerializeField] private GameObject _millionaireModel;

    private GameObject _currentModel;

    private Dictionary<WealthLevel, GameObject> _models;

    private void Awake()
    {
        _models = new Dictionary<WealthLevel, GameObject>()
        {
            { WealthLevel.Hobo, _hoboModel},
            { WealthLevel.Poor, _poorModel},
            { WealthLevel.Decent, _decentModel},
            { WealthLevel.Rich, _richModel},
            { WealthLevel.Millionaire, _millionaireModel}
        };
    }

    private void Start()
    {
        _currentModel = _models[WealthLevel.Poor];
    }

    public void ChangeModel(WealthLevel level)
    {
        _currentModel.SetActive(false);
        _currentModel = _models[level];
        _currentModel.SetActive(true);
    }
}
