using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceChecker : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;

    Color near = Color.green;
    Color far = Color.red;
    const float MAX_DISTANCE = 200;

    void Update()
    {
        float distanceApart = getSqrDistance(obj1.transform.position, obj2.transform.position);
        UnityEngine.Debug.Log(getSqrDistance(obj1.transform.position, obj2.transform.position));

        float lerp = mapValue(distanceApart, 0, MAX_DISTANCE, 0f, 1f);

        Color lerpColor = Color.Lerp(near, far, lerp);
        obj1.GetComponent<Renderer>().material.color = lerpColor;
    }

    public float getSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }

    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
}