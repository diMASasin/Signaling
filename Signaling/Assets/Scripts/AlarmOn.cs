using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOn : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;

    private float _runningTime;
    private float _normalizedRunningTime;
    private bool _volumeIsNotFull = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player))
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
                _volumeIsNotFull = true;
            }
        }
    }

    private void Update()
    {
        if (_audioSource.isPlaying && _volumeIsNotFull)
        {
            _runningTime += Time.deltaTime;
            _normalizedRunningTime = _runningTime / _duration;
            _audioSource.volume = _normalizedRunningTime;

            if(_audioSource.volume == 1)
            {
                _volumeIsNotFull = false;
                _runningTime = 0;
                _normalizedRunningTime = 0;
            }
        }
    }
}
