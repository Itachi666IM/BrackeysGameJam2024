using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    private LineRenderer laserLine;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {

        laserLine.SetPosition(0, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector2.down, out hit))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(1, transform.position * 100f);
        }
       
    }
}
