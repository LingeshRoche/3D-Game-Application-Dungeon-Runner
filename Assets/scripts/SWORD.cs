using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWORD : MonoBehaviour
{
    public GameObject projectile;
   public float rateOfFire=1f;

    public float GetRateOffFire(){
        return rateOfFire;
    }
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.G))
        {
            // Instantiate the object at the current position and rotation of this GameObject
            Fire();

        }
    }
   public void Fire(){
    Instantiate(projectile, transform.position, transform.rotation);
   }
}
