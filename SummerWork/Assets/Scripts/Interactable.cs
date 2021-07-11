using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class Interactable : MonoBehaviour
{   public UnityEvent interactAction;
    // Start is called before the first frame update
    
    public void OnInteract(InputAction.CallbackContext context){
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.7f, Vector2.one, 1, LayerMask.GetMask("Player"));
        if (context.ReadValueAsButton() && hit){    
            interactAction.Invoke();
        }
    }
}
