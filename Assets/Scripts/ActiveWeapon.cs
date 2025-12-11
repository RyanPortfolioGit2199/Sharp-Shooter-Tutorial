using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

   
    
    Animator animator;

    float timeSinceLastShot = 0f;

    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] Image zoomVignitte;

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
        

        HandleShoot();

        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO; // this.weaponSO is the weaponSO variable declared at the begining of the script. ///// the other weaponSO is the on I declared at the start of the SwitchWeapon Method
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

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

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            Debug.Log("Zooming In");
            playerCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignitte.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Can't Zoom In");
            playerCamera.m_Lens.FieldOfView = weaponSO.defaultFOV;
            zoomVignitte.gameObject.SetActive(false);
        }
    }

}
