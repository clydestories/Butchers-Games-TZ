using UnityEngine;

public class Gate : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;
    [SerializeField] private bool _isGood;

    public void Interact(PlayerTriggerHandler player)
    {
        if (_isGood)
        {
            player.AddWealth(_value);
        }
        else
        {
            player.RemoveWealth(_value);
        }
    }
}
