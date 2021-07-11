using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScript : MonoBehaviour
{
    private bool shouldMove = false; 
    public bool ShouldMove {
        set {shouldMove = value;}
   }
    public Transform targetPos;
    public float moveSpeed;
    // Update is called once per frame
    void Update(){
        if(shouldMove){
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, moveSpeed*Time.deltaTime);
        }
    }
}
