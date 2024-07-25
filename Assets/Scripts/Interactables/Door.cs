using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private readonly int Open = Animator.StringToHash(nameof(Open));

    [SerializeField] private WealthLevel _levelToPass;
    [SerializeField] private int _multiplier;
    [SerializeField] private Animator _animator;
    [SerializeField] private LevelEnder _ender;
    [SerializeField] private AudioSource _audio;

    public void Interact(PlayerTriggerHandler player) 
    {
        if (player.WealthLevel >= _levelToPass)
        {
            OpenDoor();
        }
        else
        {
            EndLevel();
        }
    }

    private void OpenDoor()
    {
        _animator.SetTrigger(Open);
        _audio.Play();
    }

    private void EndLevel()
    {
        _ender.Win(_multiplier);
    }
}
