using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private Transform transform;
    private BoxCollider2D collider2D;
    private Vector2 rawInputData;
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        transform = GetComponent<Transform>();
    }

    private void Update() {

        //TODO: Ramping velocity on the player
        //TODO: Seperate input and collision
        Vector3 move = new Vector3(rawInputData.x, rawInputData.y, 0) * Time.deltaTime * speed;
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, collider2D.size, 0, new Vector2(0, move.y), Mathf.Abs(move.y), LayerMask.GetMask("Floor"));
    
        if (hit.collider == null){
            transform.Translate(move);
        };
    }

    public void Move(InputAction.CallbackContext context) {
        rawInputData = context.ReadValue<Vector2>();
    }
}
