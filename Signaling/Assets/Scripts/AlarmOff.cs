using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOff : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;

    private float _runningTime;
    private float _normalizedRunningTime;
    private bool _needToOff = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) && _audioSource.isPlaying)
        {
            _needToOff = true;
        }
    }

    public void Update()
    {
        if(_audioSource.isPlaying && _needToOff)
        {
            _runningTime += Time.deltaTime;
            _normalizedRunningTime = _runningTime / _duration;
            _audioSource.volume = 1 - _normalizedRunningTime;

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
                _runningTime = 0;
                _normalizedRunningTime = 0;
                _needToOff = false;
            }
        }
    }
}
