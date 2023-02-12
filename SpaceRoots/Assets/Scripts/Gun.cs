using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 1;
    public float range = 100f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    private AudioSource sound;

    [SerializeField]
    private HealthBar ammo;
    public int maxAmmo = 2;
    public int currentAmmo;
    public bool haveAmmo = true;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        currentAmmo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && haveAmmo)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        sound.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        UseAmmo();
    }

    void UseAmmo()
    {
        currentAmmo -= 1;
        ammo.SetHealth(currentAmmo);
        if (currentAmmo <= 0)
        {
            OutOfAmmo();
        }
    }

    void OutOfAmmo()
    {
        haveAmmo = false;
    }

    public void AddAmmo()
    {
        currentAmmo += 1;
        ammo.SetHealth(currentAmmo);
        haveAmmo = true;
    }
}
