using UnityEngine;

public class Wine : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;

    public void Interact(PlayerTriggerHandler player)
    {
        player.RemoveWealth(_value);
        Destroy(gameObject);
    }
}
