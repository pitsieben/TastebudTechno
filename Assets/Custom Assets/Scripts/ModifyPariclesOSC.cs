using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyPariclesOSC : MonoBehaviour
{
    public OSCControllerFloat controller;
    public float min = 0.01f, max = 1f;
    private ParticleSystem particles;

    public enum Mode {
        EmissionRateOverTime,
        StartSize
    }
    public Mode mode;

    void Start(){
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float value = Mathf.Lerp(min, max, controller.receivedValue);
        if (mode == Mode.EmissionRateOverTime){
            var em = particles.emission;
            em.enabled = true;
            em.rateOverTime = value;
        } else if (mode == Mode.StartSize){
            var main = particles.main;
            main.startSize = value;
        }
    }
}