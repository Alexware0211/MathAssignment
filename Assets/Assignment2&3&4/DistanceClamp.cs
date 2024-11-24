using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceClamp : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;

    const float MAX_DISTANCE = 75;

    void Update()
    {
        float distanceApart = getSqrDistance(obj1.transform.position, obj2.transform.position);
        //UnityEngine.Debug.Log(getSqrDistance(obj1.transform.position, obj2.transform.position));

        float lerp = mapValue(distanceApart, 0, MAX_DISTANCE, 0f, 1f);

        if (lerp > 0.08)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
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

