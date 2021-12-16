using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the main attack function of the turrets
public class AttackPlayer : MonoBehaviour
{
    //the interval of frames in the update funtion that run code, currently set to every other frame
    private int interval = 2;

    //detects player within attack zone
    bool detected;
    public GameObject target;
   

    //point of which the turret rotates around
    public Transform pivotPoint;

    //turret bullet
    public GameObject turretProjectile;

    //location of spawnpoint for bullet
    public Transform projectileSpawner;

    // turret bullet variables
    public float timeBetweenShots = 1.3f;
    float originalTime;
    public Vector3 currentRotation;

    //sounds
    [Header("SFX")]
    public AudioSource source;
    public AudioClip[] voiceLines;
    
    private bool sfxHasPlayed = false;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    //resets timeBetweenShots to desired value
    private void Start()
    {
        source.clip = voiceLines[Random.Range(0, voiceLines.Length)]; 
        originalTime = timeBetweenShots;
        Physics.IgnoreLayerCollision(7, 6);
    }

    // turret rotates to face player once player is in range every ___ frames rather than every single frame because
    // this function is taxing on the processor
    void Update()
    {
        if (Time.frameCount % interval == 0 && detected)
        {

            pivotPoint.LookAt(target.transform);
            currentRotation = new Vector3(currentRotation.x, currentRotation.y, currentRotation.z % 360f);
            this.transform.eulerAngles = currentRotation;

            timeBetweenShots -= Time.deltaTime;

            if (timeBetweenShots < 0)
            {
                ShootPlayer();
                timeBetweenShots = originalTime;
            }

        }     
    }
    //detects if player is within range of turret [engage attack mode]
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            detected = true;
            target = other.gameObject;

            //plays random voiceline once on entry
            if (sfxHasPlayed == false)
            {
                source.PlayOneShot(source.clip);
                sfxHasPlayed = true;
            }
        }
    }

    //detects if player has left range [engage passive mode]
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
        {
            detected = false;
            target = other.gameObject;          
        }
    }

    // spawns turret bullet
    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(turretProjectile, projectileSpawner.position, projectileSpawner.rotation);
        
    }

    
}
