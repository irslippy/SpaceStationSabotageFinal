using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Stats")]
    public int PlayerMaxHealth = 100;
    public int CurrentHealth;
    public HealthBar healthBar;
    public Transform playerCamera;


  

    public AudioSource source;
    public AudioClip deathSFX;
    bool isDead = false;

    //this script is attached to the player and it detects if the player was hit by a turret. If hit,
    //this script would update the remaining health of the player. This new value would then be used by the 
    //UI health bar script I made
    void Awake()
    {
        source.GetComponent<AudioSource>();
    }
    //Sets player health to max amount
    void Start()
    {
       

        CurrentHealth = PlayerMaxHealth;
        healthBar.SetMaxValue(PlayerMaxHealth);

        source.clip = deathSFX;

    }

    //if player health is zero, game is paused and Death UI appears
    private void Update()
    {
        if (CurrentHealth <= 0)
        { 
            //this pauses the game giving momentarily before going to death scene
            EndGame();
        }
    }
    //detects collision with turret projectile and applies health reduction
    public void OnTriggerEnter(Collider SpyderBullet)
    {
        if (SpyderBullet.gameObject.tag == "Enemy")
        {
            //Debug.Log("player hit");
            TakeDamage(20);
        }

    }

    void EndGame()
    {
        
        SceneManager.LoadScene(2);
        if (isDead == false)
        {
            source.PlayOneShot(deathSFX);
            isDead = true;
        }
    }
    //reduces health and updates health bar
    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetStat(CurrentHealth);
    }
}
