using StarterAssets;
using UnityEditor.PackageManager;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   StarterAssetsInputs starterAssetsInputs;

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitVFX;


    [SerializeField] int Damage;

    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
               
        HandleShoot();
        
    }


   void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;
        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            
            Debug.Log(hit.collider.name);

            Instantiate(hitVFX, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            enemyHealth?.OnHitByWeapon(hit, Damage);
            /*if (enemyHealth != null) 
            {
                enemyHealth.OnHitByWeapon(hit, Damage);
            }
            */
        }
        
    }

}
