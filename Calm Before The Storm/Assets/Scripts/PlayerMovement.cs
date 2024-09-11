using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 myMovement;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    public bool canMove = true;
    public bool hasPressed = false;

    [SerializeField] float moveSpeed = 5f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        if(!canMove)
        { return; }
        myMovement = value.Get<Vector2>();
    }

    void OnPick(InputValue value)
    {
        if (!canMove)
        { return; }
        if (value.isPressed)
        {
            hasPressed = true;
        }
    }

    void Walk()
    {
        if (!canMove)
        { return; }
        myRigidbody.velocity = myMovement * moveSpeed * Time.deltaTime * 500f;
    }

    private void Update()
    {
        if (!canMove)
        { return; }
        Walk();
        AnimationState();
        FlipSprite();
    }

    void AnimationState()
    {
        if (!canMove)
        { return; }
        if ((Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon) || (Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon))
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
        if (!canMove)
        { return; }
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x)*0.1f, 0.1f);
        }
    }
}
