using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private Rigidbody rb;
    private float previousYVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousYVelocity = rb.velocity.y;
    }


    void FixedUpdate()
    {
        float currentYVelocity = rb.velocity.y;

        // Check if the Y velocity changes from negative to zero
        if (previousYVelocity < -2 && currentYVelocity >= -Mathf.Epsilon)
        {
            this.GetComponent<InterpolarHealthbar>().RemoveHealth();
        }

        // Update the previous Y velocity for the next frame
        previousYVelocity = currentYVelocity;
    }

}
