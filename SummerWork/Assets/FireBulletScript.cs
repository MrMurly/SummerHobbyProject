using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBulletScript : MonoBehaviour
{
    public Transform bullet;
    private Vector3 mousePosition;
    private bool mouseDown;
    public float rotateSpeed;
    public Transform target;
    public float delayAmount = 3f;
    private float delay;
    public float moveSpeed;
    public float aliveTime;
    [Range(0, 1)]
    public float inaccuracy;

    private void Start() {
        delay = delayAmount;
    }
    private void Update() {
        Vector3 world_position = Camera.main.ScreenToWorldPoint(mousePosition);
        world_position.z = 0;
        
        rotateFirePos();

        if(mouseDown && delay < 0){
            Transform _bullet = Instantiate<Transform>(bullet, transform.position, Quaternion.identity);
            
            //Introduce a bit of fire spread    
            Vector3 bulletDirection = transform.localPosition;
            Vector2 randomSpread = Random.insideUnitCircle * inaccuracy;
            bulletDirection += new Vector3(randomSpread.x, randomSpread.y, 0);
            _bullet.GetComponent<BulletScript>().setValues(bulletDirection, moveSpeed, aliveTime);
            
            delay = delayAmount;

        }
        delay-=Time.deltaTime;

    }

private void rotateFirePos(){
    Vector3 targetScreenPos = Camera.main.WorldToScreenPoint (target.position);
    targetScreenPos.z = 0;
    Vector3 targetToMouseDir = mousePosition - targetScreenPos;
    
    Vector3 targetToMe = transform.position - target.position;
    targetToMe.z = 0;
    
    Vector3 newTargetToMe = Vector3.RotateTowards(targetToMe, targetToMouseDir, rotateSpeed, 0f);
    
    transform.position = target.position + newTargetToMe.normalized;
    
    }

    public void onFire(InputAction.CallbackContext context) {
        mouseDown = context.ReadValueAsButton();
    }
    
    public void MousePosition(InputAction.CallbackContext context){
        mousePosition = context.ReadValue<Vector2>();
        
    }
}
