using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] protected float Duration;
    [SerializeField] protected Alarm AnotherAlarm;

    protected AudioSource AudioSource;
    protected static float RunningTime;

    public Coroutine ChangeVolumeCoroutine;

    public void Start()
    {
        AudioSource = GetComponentInParent<AudioSource>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player))
        {
            AnotherAlarm.StopChangeVolumeCoroutine();
            ChangeVolumeCoroutine = StartCoroutine(ChangeVolume());
        }
    }

    protected virtual IEnumerator ChangeVolume()
    {
        yield return null;
    }

    public void StopChangeVolumeCoroutine()
    {
        if (ChangeVolumeCoroutine != null)
            StopCoroutine(ChangeVolumeCoroutine);
    }
}
