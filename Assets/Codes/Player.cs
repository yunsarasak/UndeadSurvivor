using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Vector2 inputVector;
    new Rigidbody2D rigidbody;
    public float moveSpeed;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVector * moveSpeed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + nextVec);

    }

    private void LateUpdate()
    {
        if(inputVector.x != 0)
        {
            spriteRenderer.flipX = (inputVector.x < 0) ? true : false;
        }
        anim.SetFloat("Speed", inputVector.magnitude);
    }
}
