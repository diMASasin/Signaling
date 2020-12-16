using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOn : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;
    [SerializeField] private AlarmOff _alarmOff;

    public Coroutine VolumeIncreaseCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player))
        {
             if (_alarmOff.VolumeDecreaseCoroutine != null)
                 StopCoroutine(_alarmOff.VolumeDecreaseCoroutine);
             VolumeIncreaseCoroutine = StartCoroutine(VolumeIncrease());       
        }
    }

    private IEnumerator VolumeIncrease()
    {
        _audioSource.Play();

        for (float _runningTime = _audioSource.volume; _runningTime < _duration; _runningTime += Time.deltaTime)
        {
            _audioSource.volume = _runningTime / _duration;
            yield return null;
        }
    }
}
