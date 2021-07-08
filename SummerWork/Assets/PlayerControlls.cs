using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControlls : MonoBehaviour
{

    private MovementScript movementScript;
    private Vector2 rawInputData;
    public Transform sprite;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<MovementScript>();
    }

    public void Move(InputAction.CallbackContext context) {
        rawInputData = context.ReadValue<Vector2>();
        movementScript.MoveDirection = rawInputData;

        Vector3 targetLookAt = new Vector3(rawInputData.x,  rawInputData.y, 0) + transform.position;
        
        look2D(targetLookAt);
    }

    private void look2D(Vector3 target) {
        sprite.up = target - sprite.position;
    }
}
