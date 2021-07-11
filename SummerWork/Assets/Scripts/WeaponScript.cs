using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public WeaponScriptableObject weaponValues;
    // Start is called before the first frame update
    private void OnValidate() {
        if (weaponValues){
            GetComponent<SpriteRenderer>().sprite = weaponValues.sprite;    
        }
    }
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = weaponValues.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
