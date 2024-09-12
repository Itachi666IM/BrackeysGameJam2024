using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    private LineRenderer laserLine;
    public int reflections;
    public LayerMask layerDetection;
    public float maxRayDistance;
    public GameObject lightDoor;
 
    void Awake()
    {
        Physics2D.queriesStartInColliders = false;
        laserLine = GetComponent<LineRenderer>();
  
    }

    void Update()
    {

        laserLine.positionCount = 1;
        laserLine.SetPosition(0, transform.position);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, maxRayDistance, layerDetection);
        // Ray
        Ray2D ray = new Ray2D(transform.position, transform.up);

        bool isMirror = false;
        Vector2 mirrorHitPoint = Vector2.zero;
        Vector2 mirrorHitNormal = Vector2.zero;


        for (int i = 0; i < reflections; i++)
        {
            laserLine.positionCount += 1;

            if (hitInfo.collider != null)
            {
                laserLine.SetPosition(laserLine.positionCount - 1, hitInfo.point - ray.direction * -0.1f);

                isMirror = false;
                if (hitInfo.collider.CompareTag("Mirror"))
                {
                    mirrorHitPoint = (Vector2)hitInfo.point;
                    mirrorHitNormal = (Vector2)hitInfo.normal;
                    hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * -0.1f, Vector2.Reflect(hitInfo.point - ray.direction * -0.1f, hitInfo.normal), maxRayDistance, layerDetection);
                    isMirror = true;
                }
                else if (hitInfo.collider.CompareTag("Button"))
                {
                    Destroy(lightDoor.gameObject);
                }
                else
                    break;
                   
            }
            else
            {
                if (isMirror)
                {
                    laserLine.SetPosition(laserLine.positionCount - 1, mirrorHitPoint + Vector2.Reflect(mirrorHitPoint, mirrorHitNormal) * maxRayDistance);
                    break;
                }
                else
                {
                    laserLine.SetPosition(laserLine.positionCount - 1, transform.position + transform.up * maxRayDistance);
                    break;
                }
            }
        }



    }
}
