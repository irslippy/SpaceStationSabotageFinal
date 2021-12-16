using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script enables and disables different zones in the scene as the player moves 
//through the level so that unneccessary areas aren't being loaded in
public class Occluder : MonoBehaviour
{
    public static bool EnableZone;
    public GameObject Zone;

    private void Start() {
        Zone.SetActive(false);
    }

    public void disableZone() {
        if(Zone.activeSelf == true) {
            Zone.SetActive(false);
        }
    }

    public void enableZone() {
        if (Zone.activeSelf == false) {
            Zone.SetActive(true);
        }
    }

   
}
