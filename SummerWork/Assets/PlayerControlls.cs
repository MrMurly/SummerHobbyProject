using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControlls : MonoBehaviour
{

    private MovementScript movementScript;
    private Vector2 rawInputData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(InputAction.CallbackContext context) {
        rawInputData = context.ReadValue<Vector2>();
    }
}
