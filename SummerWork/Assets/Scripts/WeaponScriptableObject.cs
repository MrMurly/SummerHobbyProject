using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObjects/Weapon", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{   
    public Animation attack1;
    public Sprite sprite;
    public float damage;
    public float fireSpeed;

}
