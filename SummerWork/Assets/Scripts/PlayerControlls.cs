using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControlls : MonoBehaviour
{

    private MovementScript movementScript;
    private Vector2 rawInputData;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<MovementScript>();
    }

    public void Move(InputAction.CallbackContext context) {
        rawInputData = context.ReadValue<Vector2>();
        movementScript.MoveDirection = rawInputData;
        animator.SetFloat("Speed", rawInputData.magnitude);
    }

}
