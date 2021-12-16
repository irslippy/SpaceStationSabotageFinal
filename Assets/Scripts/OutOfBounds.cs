using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is attached to a trigger underneath the map so that if I clipped out of bounds
//while bugfixing I would just teleport to death scene
public class OutOfBounds : MonoBehaviour
{
    private string player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            SceneManager.LoadScene(2);
        }
    }



}
