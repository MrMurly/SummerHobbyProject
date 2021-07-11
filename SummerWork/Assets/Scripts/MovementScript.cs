using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private BoxCollider2D collider2D;
    private Rigidbody2D rb;
    public SpriteRenderer sprite;
    
    private Vector2 moveDirection;
    public Vector2 MoveDirection {
        set {moveDirection = value;}
    }
    [SerializeField]
    private float speed;
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //dont flip if we just stopped moving
        if (moveDirection.x > 0){
            sprite.flipX = false;
        }
        else if (moveDirection.x < 0)
        {
            sprite.flipX = true;
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime * speed);
    }


}
