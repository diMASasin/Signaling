using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOn : Alarm
{
    protected override IEnumerator ChangeVolume()
    {
        AudioSource.Play();
        while (RunningTime < Duration)
        {
            RunningTime += Time.deltaTime;
            AudioSource.volume = RunningTime / Duration;
            yield return null;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player) && !AudioSource.isPlaying)
        {
            AnotherAlarm.StopChangeVolumeCoroutine();
            ChangeVolumeCoroutine = StartCoroutine(ChangeVolume());
        }
    }
}
