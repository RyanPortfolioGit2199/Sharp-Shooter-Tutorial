using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] int currentHealth;

    private int PlayerGunDamage;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void OnHitByWeapon(RaycastHit hitInfo, int GunDamage)
    {
        Debug.Log("Enemy says, AAAHHHHH!!!! PLAYER SHOT ME!!!, OOOOCCCCHHHHIIIIEEEE!!!!!!!!!!!!!!!!!!!");

        PlayerGunDamage = GunDamage;

        TakeDamage();
    }

    public void TakeDamage()
    {
        currentHealth -= PlayerGunDamage;
    }

    public void Die()
    {
        if (currentHealth <= 0)
        { 

            Destroy(gameObject);

        }
    }
}
