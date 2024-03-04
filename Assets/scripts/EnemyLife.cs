using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Animator animator;
  void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            Die();
            animator.SetBool("isDeath", true);
            Destroy(collision.gameObject);
            Destroy(gameObject,3f);
        }
        else{
             animator.SetBool("isDeath", false);
        }
    }
     void Die()
     {
        GetComponent<WayPointFollower>().enabled = false;
     }
}
