using UnityEngine;
//this script wasnt used and was replaced by "PropelShot"
public class SpawnPlayerBullet : MonoBehaviour
{
    public GameObject LiveProjectile;
   
   public void SpawnBullet()
    {
        Destroy(gameObject);
        Instantiate(LiveProjectile, gameObject.transform.position, gameObject.transform.rotation);

    }
}
