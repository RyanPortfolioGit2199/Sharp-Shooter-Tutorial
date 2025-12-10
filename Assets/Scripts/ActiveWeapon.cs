using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    
    Animator animator;

    float timeSinceLastShot = 0f;

    [SerializeField] WeaponSO weaponSO;

    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        HandleShoot();

    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Picked Up " + weaponSO.name);
    }

    void HandleShoot()
    {
        

        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
        
        

    }

    

}
