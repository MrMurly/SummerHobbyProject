using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public ParticleSystem explosion;
    private BoxCollider2D col;
    private Vector3 direction;
    private float moveSpeed;
    
    private void Start() {
        col = GetComponent<BoxCollider2D>();
    }
    public void setValues(Vector3 direction, float moveSpeed, float aliveTime){
        this.moveSpeed = moveSpeed;
        this.direction = direction;

        Destroy(gameObject, aliveTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void Update() {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, col.size, 0, Vector2.zero, 0, LayerMask.GetMask("Floor"));
        if(hit){
            Destroy(gameObject);
        }
        transform.position += direction * moveSpeed * Time.deltaTime;

    }
    private void OnDestroy() {
        CinemachineShake.Instance.ShakeCamera(5f, .1f);
        Instantiate<ParticleSystem>(explosion, transform.position, Quaternion.identity);
    }
}
