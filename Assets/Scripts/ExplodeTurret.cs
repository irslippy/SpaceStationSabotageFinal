using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is attached to the powercell of the DESTROYED versio of the turret. It 
//detects all of the rigidbodies/colliders within a sphere around the turret and applies an explode
//effect to it.
public class ExplodeTurret : MonoBehaviour
{
    public GameObject TurretPowerCell;
    [Header("Visual effect")]
    public GameObject explosionEffect;
    [Header("Explosion Variables")]
    public float blastRadius;
    public float explosionForce = 700f;
    public float upForce = 1.0f;
    [Header("Sound Effects")]
    public AudioSource source;
    public AudioClip explosionSFX;
    private bool hasExploded = false;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        //detonate called in start because object containing Detonate() function
        //is instantiated at the precise moment that the player's projectile connects with 
        //turrets hitbox. Also ensures that the turret
        //wont repeadately explode by using hasExploded bool.
        if (TurretPowerCell == enabled && hasExploded == false)
        {
            Detonate();
            
        }

        source.clip = explosionSFX;
        
    }
    
    void Detonate()
    {
        //defines location of explosion
        Vector3 explosionPosition = TurretPowerCell.transform.position;

        //creates an array that populates with colliders within explosion radius
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, blastRadius);
        //applies explosion effect to all objects within radius that are rigidbodies
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPosition, blastRadius, upForce, ForceMode.Impulse);

            }
        }
        Destroy(gameObject);
        //plays explosion sfx once
        if (hasExploded == false)
        {
            source.PlayOneShot(explosionSFX);
            hasExploded = true;
        }
    }

}
