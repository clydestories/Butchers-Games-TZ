using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private float _audioDelay;
    [SerializeField] private List<AudioClip> _stepAudio;

    private AudioSource _audioSource;
    private Coroutine _steps;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartPlayingSteps()
    {
        _steps = StartCoroutine(PlaySteps());
    }

    public void StopPlayingSteps()
    {
        if (_steps != null)
        {
            StopCoroutine(_steps);
        }
    }

    private IEnumerator PlaySteps()
    {
        while (enabled)
        {
            _audioSource.clip = _stepAudio[Random.Range(0, _stepAudio.Count)];
            _audioSource.Play();
            yield return new WaitForSeconds(_audioDelay);
        }
    }
}
