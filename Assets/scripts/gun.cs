using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
   public GameObject projectile;
   public float rateOfFire=1f;

    public float GetRateOffFire(){
        return rateOfFire;
    }
   public void Fire(){
    Instantiate(projectile, transform.position, transform.rotation);
   }
}
