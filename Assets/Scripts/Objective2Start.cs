using UnityEngine;
using UnityEngine.SceneManagement;

//replaces NAV SYSTEM with destroyed version and enables the final escape objective
public class Objective2Start : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject objective2;
    public GameObject objective2location;
    
  
    //detects collision of player projectile on turret and destroys turret
    public void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "PlayerProjectile")
        {
            DestroyEnemy();
            Instantiate(objective2, objective2location.transform.position, Quaternion.identity);
        }

    }

    public void DestroyEnemy()
    {
      
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);

    }


}