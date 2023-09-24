using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int _bulletShootDelay = 0;
    [SerializeField] private int _rocketShootDelay = 0;

    public GameObject bullet;
    public GameObject rocket;

    public GameObject bulletSpawnPoint;

    public static bool canShootBullet;
    public static bool canShootRocket;
    void Start()
    {
        bulletSpawnPoint = transform.Find("BulletSpawnPoint").gameObject;
    }

    void Update()
    {
        CanShoot();
        if (Input.GetKey(KeyCode.Mouse0) && _bulletShootDelay > 300)
        {
            BulletShoot();
        }
        if (Input.GetKey(KeyCode.Mouse1) && _rocketShootDelay > 600)
        {
            RocketShoot();
        }
        _rocketShootDelay++;
        _bulletShootDelay++;
    }

    private void BulletShoot()
    {
        if (canShootBullet == true)
        {
            _bulletShootDelay = 0;
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    private void RocketShoot()
    {
        if (canShootRocket == true)
        {
            _rocketShootDelay = 0;
            Instantiate(rocket, bulletSpawnPoint.transform.position, Quaternion.identity);
        }
    }
    private void CanShoot()
    {
        if (GunSlot.isEquiped && Time.deltaTime != 0f)
        {
            canShootBullet = true;
        }
        else
        {
            canShootBullet = false;
        }
        if (RocketSlot.isEquiped && Time.deltaTime != 0f)
        {
            canShootRocket = true;
        }
        else
        {
            canShootRocket = false;
        }
    }
}
