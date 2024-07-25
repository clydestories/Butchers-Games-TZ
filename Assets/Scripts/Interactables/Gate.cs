using UnityEngine;

public class Gate : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;
    [SerializeField] private bool _isGood;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _goodSound;
    [SerializeField] private AudioClip _badSound;

    public void Interact(PlayerTriggerHandler player)
    {
        if (_isGood)
        {
            player.AddWealth(_value);
            _audio.PlayOneShot(_goodSound);
        }
        else
        {
            player.RemoveWealth(_value);
            _audio.PlayOneShot(_badSound);
        }
    }
}
