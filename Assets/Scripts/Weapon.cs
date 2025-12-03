using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   StarterAssetsInputs starterAssetsInputs;

    [SerializeField] int Damage;

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

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.name);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            enemyHealth?.OnHitByWeapon(hit, Damage);
            /*if (enemyHealth != null) 
            {
                enemyHealth.OnHitByWeapon(hit, Damage);
            }
            */
        }
        starterAssetsInputs.ShootInput(false);
    }

}
