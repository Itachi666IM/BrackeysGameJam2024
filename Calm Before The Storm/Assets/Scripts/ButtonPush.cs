using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    [Header("Button Variables")]
    [SerializeField] SpriteRenderer buttonSprite;
    [SerializeField] Material buttonPushed;

    [Header("Door Variables")]
    [SerializeField] GameObject door;
    [SerializeField] Vector2 doorOffset;

    private Material buttonDefaultMaterial;
    private Vector2 doorDefaultPosition;
    private void Start()
    {
        buttonDefaultMaterial = buttonSprite.material;
        doorDefaultPosition = door.transform.position;
    }
    void ChangeButtonMaterial()
    {
        buttonSprite.material = buttonPushed;
    }

    void OpenDoor()
    {
        door.transform.position = doorOffset;
    }

    void CloseDoor()
    {
        door.transform.position = doorDefaultPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChangeButtonMaterial();
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            buttonSprite.material = buttonDefaultMaterial;
            CloseDoor();
        }
    }
}
