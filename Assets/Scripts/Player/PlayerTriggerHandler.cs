using UnityEngine;

[RequireComponent (typeof(Collider))]
public class PlayerTriggerHandler : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Wealth _wealth;

    public WealthLevel WealthLevel => _wealth.WealthLevel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.TryGetComponent(out IInteractable collectable))
        {
            collectable.Interact(this);
        }
    }

    public void AddWealth(int amount)
    {
        _wealth.AddWealth(amount);
    }

    public void RemoveWealth(int amount)
    {
        _wealth.RemoveWealth(amount);
    }
}
