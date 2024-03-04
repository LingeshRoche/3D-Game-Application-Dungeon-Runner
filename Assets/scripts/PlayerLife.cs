using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
     
     private Animator animator;
      void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
             animator.SetBool("isDeath", true);
            Die();
        }
         else{
             animator.SetBool("isDeath", false);
              GetComponent<MeshCollider>().enabled = true;
        }
    }
    void Die()
    {
         Transform debuffObject = transform.Find("Debuff"); // Find the Debuff object by name
    if (debuffObject != null)
    {
        debuffObject.gameObject.SetActive(true); // Enable the Debuff object if found
    }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
         GetComponent<MeshCollider>().enabled = false;
        Invoke(nameof(ReloadLevel),4f);
        
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
