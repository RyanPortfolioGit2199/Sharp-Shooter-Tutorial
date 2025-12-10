using StarterAssets;

using UnityEngine;

public class Weapon : MonoBehaviour
{
   

    [SerializeField] ParticleSystem muzzleFlash;
    

    // Update is called once per frame
    void Update()
    {
               
        
        
    }


   public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            
            Debug.Log(hit.collider.name);

            Instantiate(weaponSO.HitVFX, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            enemyHealth?.OnHitByWeapon(hit, weaponSO.Damage);
            /*if (enemyHealth != null) 
            {
                enemyHealth.OnHitByWeapon(hit, Damage);
            }
            */
        }
        
    }

}
