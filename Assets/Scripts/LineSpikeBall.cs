using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpikeBall : MonoBehaviour
{
    LineRenderer line;
    public Transform entryendpoint;
    public Transform exitendpoint;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0,entryendpoint.position);
        line.SetPosition(1, exitendpoint.position);
    }
}
