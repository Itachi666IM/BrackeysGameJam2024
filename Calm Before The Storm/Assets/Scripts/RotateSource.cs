using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSource : MonoBehaviour
{
    public GameObject player;
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, player.transform.position) <= 2f)
        {
            transform.Rotate(new Vector3(0, 0, 45f));
        }
    }
}
