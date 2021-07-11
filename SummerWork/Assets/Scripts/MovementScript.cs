using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private BoxCollider2D collider2D;
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
    }

    private void Update() {
        //TODO: Ramping velocity on the player
        Vector3 move = new Vector3(moveDirection.x, moveDirection.y, 0) * Time.deltaTime * speed;
        
        //dont flip if we just stopped moving
        if (move.x > 0){
            sprite.flipX = false;
        }
        else if (move.x < 0)
        {
            sprite.flipX = true;
        }

        
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, collider2D.size, 0, new Vector2(move.x, move.y), Mathf.Abs(move.magnitude), LayerMask.GetMask("Floor"));
    
        if (hit.collider == null){
            transform.Translate(move);
        };
    }


}