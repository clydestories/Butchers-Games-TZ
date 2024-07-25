using UnityEngine;

public class Money : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;

    public void Interact(PlayerTriggerHandler player)
    {
        player.AddWealth(_value);
        Destroy(gameObject);
    }
}
