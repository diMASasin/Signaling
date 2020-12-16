using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOff : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;
    [SerializeField] private AlarmOn _alarmOn;

    public Coroutine VolumeDecreaseCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player) && _audioSource.isPlaying)
        {
             if (_alarmOn.VolumeIncreaseCoroutine != null)
                 StopCoroutine(_alarmOn.VolumeIncreaseCoroutine);
             VolumeDecreaseCoroutine = StartCoroutine(VolumeDecrease());
        }
    }

    private IEnumerator VolumeDecrease()
    { 
        for (float _runningTime = _audioSource.volume; _runningTime > 0; _runningTime -= Time.deltaTime)
        {
            _audioSource.volume = _runningTime / _duration;
            yield return null;
        }
        _audioSource.Stop();
    }
}
