using UnityEngine;

public class Chechpoint : MonoBehaviour, IInteractable
{
    private readonly int StandUp = Animator.StringToHash(nameof(StandUp));

    [SerializeField] private Animator _animator;

    public void Interact(PlayerTriggerHandler player)
    {
        _animator.SetTrigger(StandUp);
    }
}
