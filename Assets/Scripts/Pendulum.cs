using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polumn : MonoBehaviour
{
    public Rigidbody2D body2d;
    public float leftPushRange=20f;
    public float rightPushRange=20f;
    public float velocityThreshold;
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }
    public void Push()
    {
        if(transform.rotation.z>0 
            && transform.rotation.z< rightPushRange
            && body2d.angularVelocity>0
            && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }    
        else if(transform.rotation.z < 0
            && transform.rotation.z > leftPushRange
            && body2d.angularVelocity < 0
            && body2d.angularVelocity > velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }    
    }    
}
