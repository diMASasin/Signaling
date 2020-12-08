using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOn : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;

    private float _runningTime;
    private float _normalizedRunningTime;
    private bool _VolumeIsNotFull = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
                _VolumeIsNotFull = true;
            }
        }
    }

    private void Update()
    {
        if (_audioSource.isPlaying && _VolumeIsNotFull)
        {
            _runningTime += Time.deltaTime;
            _normalizedRunningTime = _runningTime / _duration;
            _audioSource.volume = _normalizedRunningTime;

            if(_audioSource.volume == 1)
            {
                _VolumeIsNotFull = false;
                _runningTime = 0;
                _normalizedRunningTime = 0;
            }
        }
    }
}
