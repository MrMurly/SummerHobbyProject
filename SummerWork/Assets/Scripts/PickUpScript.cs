using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private float distance;
    private Transform currentWeapon;
    public Transform weaponPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one, 0, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("CanGrab"));
        if (hit && !currentWeapon){
            Pickup(hit.transform);
        }
    }

    private void Pickup(Transform weapon){
        currentWeapon = weapon;
        weapon.SetParent(weaponPos);
        weapon.position = weaponPos.position;
        weapon.rotation = weaponPos.rotation;
    }

    public void Drop(){
        weaponPos.DetachChildren();
    }
}
