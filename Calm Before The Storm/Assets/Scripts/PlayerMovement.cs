using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 myMovement;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    [SerializeField] float moveSpeed = 1000f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        myMovement = value.Get<Vector2>();
    }

    void Walk()
    {
        myRigidbody.velocity = myMovement * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Walk();
        AnimationState();
        FlipSprite();
    }

    void AnimationState()
    {
        if((Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon) || (Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon))
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x)*0.1f, 0.1f);
        }
    }
}
