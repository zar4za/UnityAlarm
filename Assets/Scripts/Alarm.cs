using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField]
    private float _volumeChangePerTick = 0.1f;
    [SerializeField]
    private float _startVolume = 0f;
    [SerializeField]
    private float _targetVolume = 1f;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _startVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            _audioSource.Play();
            StartCoroutine(ChangeVolume(_targetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            StartCoroutine(ChangeVolume(_startVolume, _audioSource.Stop));
        }
    }

    private IEnumerator ChangeVolume(float target, Action callback = null)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeChangePerTick);
            yield return null;
        }

        callback?.Invoke();
    }
}
