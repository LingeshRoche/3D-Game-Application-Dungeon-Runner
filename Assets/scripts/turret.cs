using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public Transform parttorotate;
    private gun currentgun;
    private float firerate;
    private float fireratedelta;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        currentgun = GetComponentInChildren<gun>();
        firerate = currentgun.GetRateOffFire();
    }

    void UpdateTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
       
            float playerDistance = Vector3.Distance(transform.position, player.transform.position);
            if (playerDistance < shortestDistance)
            {
                shortestDistance = playerDistance;
                nearestPlayer = player;
            }
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
            {
                return;
            }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        parttorotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        fireratedelta-= Time.deltaTime;
        if(fireratedelta<=0){
            currentgun.Fire();
            fireratedelta = firerate;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
