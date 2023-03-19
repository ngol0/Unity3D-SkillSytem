using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StopParticleSystem : MonoBehaviour
{
    private Action onComplete;
    void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    public void SetAction(Action finished)
    {
        onComplete = finished;
    }

    void OnParticleSystemStopped()
    {
        Destroy(this.gameObject);
        if (onComplete != null) onComplete();
        Debug.Log(":::Particle system has stopped!");
    }
}
