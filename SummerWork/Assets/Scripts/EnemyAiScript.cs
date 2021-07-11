using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour
{ 

    private states state = states.wander;
    private MovementScript movementScript;
    private Vector3 origin;
    private Vector3 wanderDirection;
    public float awareness; 
    
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<MovementScript>();
        origin = transform.position;
    }

    private void Update() {
        switch(state){
            case states.wander:
                wander();
                if (canSeePlayer()){
                    state = states.attack;
                }
                break;
            case states.attack:
                attack();
                if (!canSeePlayer()){
                    state = states.wander;
                }
                break;
        }    
    }

    private bool canSeePlayer(){
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, awareness, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Player"));
        return hit.collider;
    }

    private void wander(){
        Debug.Log(this.name + " is idle");
        if ((origin - transform.position).magnitude < 0.5) {            
            origin = transform.position;
            wanderDirection = Random.insideUnitCircle;
        }
        movementScript.MoveDirection = wanderDirection;
    }

    private void attack(){
        Debug.Log(this.name + " is attack");

    }

    private enum states {
        wander,
        attack
    }    
}
