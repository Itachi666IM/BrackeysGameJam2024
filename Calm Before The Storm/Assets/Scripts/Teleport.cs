using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform teleportLocation;
    [SerializeField] Material buttonPushedMaterial;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonPushSound;
    [SerializeField] SpriteRenderer buttonSprite;

    private Material buttonDefaultMaterial;

    private void Awake()
    {
        buttonDefaultMaterial = buttonSprite.material;
    }

    void TeleportToLocation(GameObject player)
    {
        player.transform.position = teleportLocation.position;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(buttonPushSound);
        GameObject instance = collision.gameObject;
        TeleportToLocation(instance);
        buttonSprite.material = buttonPushedMaterial;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonSprite.material = buttonDefaultMaterial;
    }
}
