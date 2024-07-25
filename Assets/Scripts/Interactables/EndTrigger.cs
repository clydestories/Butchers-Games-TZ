using UnityEngine;

public class EndTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private LevelEnder _ender;

    private int _endMulitiplier = 5;

    public void Interact(PlayerTriggerHandler player)
    {
        _ender.Win(_endMulitiplier);
    }
}
