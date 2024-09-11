using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private CapsuleCollider2D myCollider;
    [SerializeField] AudioClip nextLevelAudio;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float loadDelay = 0.5f;
    private void Awake()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.PlayOneShot(nextLevelAudio);
            Invoke(nameof(LoadNextLevel), loadDelay);
        }
    }

    void LoadNextLevel()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int nextBuildIndex = currentBuildIndex + 1;
        if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextBuildIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
