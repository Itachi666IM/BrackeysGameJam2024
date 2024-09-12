using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Material rotatorPushedMaterial;
    [SerializeField] SpriteRenderer rotatorSprite;
    [SerializeField] AudioClip rotationSound;
    [SerializeField] AudioSource audioSource;
    private Material rotatorDefaultMaterial;

    private void Awake()
    {
        rotatorDefaultMaterial = rotatorSprite.material;
    }

    void ChangeButtonMaterial()
    {
        rotatorSprite.material = rotatorPushedMaterial;
    }

    void RotateDoor()
    {
        door.transform.Rotate(0, 0, 30);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(LayerMask.GetMask("Interactables")))
        {
            ChangeButtonMaterial();
            RotateDoor();
            audioSource.PlayOneShot(rotationSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rotatorSprite.material = rotatorDefaultMaterial;
    }
}
