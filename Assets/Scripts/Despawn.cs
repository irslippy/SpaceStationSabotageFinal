using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simple despawn script for turret parts after it is destroyed
public class Despawn : MonoBehaviour
{
    [Header("Time in seconds")]
    public float timeRemaining = 10; //implies a countdown of seconds until despawn

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
