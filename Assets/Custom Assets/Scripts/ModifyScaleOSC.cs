using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyScaleOSC : MonoBehaviour
{
    public OSCControllerFloat controller;
    public float min = 0.01f, max = 1f;

    // Update is called once per frame
    void Update()
    {
        float value = Mathf.Lerp(min, max, controller.receivedValue);
        transform.localScale = Vector3.one * value;
    }
}
