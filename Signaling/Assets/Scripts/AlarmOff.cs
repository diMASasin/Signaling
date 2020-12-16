using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOff : Alarm
{
    protected override IEnumerator ChangeVolume()
    { 
        while (RunningTime > 0)
        {
            RunningTime -= Time.deltaTime;
            AudioSource.volume = RunningTime / Duration;
            yield return null;
        }
        AudioSource.Stop();
    }
}
