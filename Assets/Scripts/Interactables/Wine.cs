using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Wine : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;
    [SerializeField] private GameObject _visual;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Interact(PlayerTriggerHandler player)
    {
        player.RemoveWealth(_value);
        StartCoroutine(PlaySoind());
        _visual.SetActive(false);
    }

    private IEnumerator PlaySoind()
    {
        _audio.Play();
        yield return new WaitWhile(() => _audio.isPlaying);
        Destroy(gameObject);
    }
}
