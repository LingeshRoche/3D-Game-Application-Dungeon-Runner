using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
     public GameObject[] waypoints;
    int currentwaypointindex = 0;
    public float speed = 1f;
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[currentwaypointindex].transform.position) < .1f)
        {
            currentwaypointindex++;
            if (currentwaypointindex >= waypoints.Length)
            {
                currentwaypointindex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentwaypointindex].transform.position, speed * Time.deltaTime);
    }
}
