using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script keeps track of the shields integrity, as well as cueing soundeffects when it is hit and also replacing the shield with 
// the destroyed version after its integrity reaches 0
public class Shield : MonoBehaviour
{
    //shield integrity stats
    [Header("Shield Stats")]
    public int ShieldMaxHealth = 100;
    public int CurrentHealth;
    //UI
    public ShieldBar shieldBar;
    //instantiate broken shield on shield break
    [Header("Alternate Version")]
    public GameObject destroyedVersion;
    //sounds :D
    [Header("SFX")]
    public AudioSource source;
    public AudioClip[] soundEffects;
    public AudioClip brokenShieldSound;
    bool sfxHasPlayed = false;
    bool shieldBroken = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    //Sets shield health to max amount and randomizes first sh
    void Start()
    {
        CurrentHealth = ShieldMaxHealth;
        shieldBar.SetMaxValue(ShieldMaxHealth);
        source.clip = soundEffects[Random.Range(0, soundEffects.Length)];


    }

    //if shield health is zero, broken shield prefab replaces original shield
    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);            
        }
    }
    //detects collision with turret projectile and applies health reduction
    public void OnTriggerEnter(Collider SpyderBullet)
    {
        if (SpyderBullet.gameObject.tag == "Enemy")
        {
          //  Debug.Log("shield hit");
            TakeDamage(10);

            ShieldHit();

            //plays random audio clip once on entry
            if (sfxHasPlayed == false)
            {
                source.PlayOneShot(source.clip);
                sfxHasPlayed = true;
            }

        }

    }
    //tracks projectile leaving hitbox and resets random hit sfx 
    public void OnTriggerExit(Collider SpyderBullet)
    {
        if (SpyderBullet.gameObject.tag == "Enemy")
        {
            sfxHasPlayed = false;
        }


    }
    //reduces health and updates health bar
    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        shieldBar.SetStat(CurrentHealth);
    }

    //plays broken shield sound effect 
    void PlayBreakSFX()
    {
        if (CurrentHealth <= 0 && shieldBroken == true)
        {
            source.PlayOneShot(brokenShieldSound);
            shieldBroken = false;
        }
    }

    //randomizes the next hit sound effect everytime it is hit
    void ShieldHit()
    {
        source.clip = soundEffects[Random.Range(0, soundEffects.Length)];
    }

    private void OnCollision (Collider collider)
    {
        if (collider.gameObject.tag == "GameController")
        {
            Physics.IgnoreCollision(collider, GetComponent<Collider>());
        }
    }
        
    
}