using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPhysics : MonoBehaviour
{
    public float Constant;

    public float Damping;

    public Vector3 localAmplitude;
    public Vector3 localSpeed;

    public Vector3 Velocity;

    public float lerp;

    // Update is called once per frame
    void Update()
    {
        Vector3 springPos = (-Constant * (transform.localPosition - Vector3.zero)) - Velocity;
        transform.localPosition += springPos;

        //Calculate the new velocity and value.
        // velocity = (velocity - value) * behaviour.Spring[i];
        // value += velocity * Time.deltaTime * behaviour.Damping[i];


        //Calculate a sine wave.
        // Velocity.x = Mathf.Sin(Time.time * localSpeed.x) * localAmplitude.x;
        float t = Mathf.Sin(Time.time * localSpeed.y) * localAmplitude.y;
        Velocity.y = Velocity.y > 0 ? Mathf.Ceil(t) : Mathf.Floor(t);
        // Velocity.z = Mathf.Sin(Time.time * localSpeed.z) * localAmplitude.z;
    }
}
