using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public static EnemyShoot Instance;

    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    public int damage = 1;

    public float fireRate;

    private void Awake()
    {
        bulletSpawnPoint = transform.Find("BulletSpawnPoint").gameObject;
    }

    void Start()
    {
        Instance = this;
        InvokeRepeating("Shoot", fireRate, fireRate);
    }
    private void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
        temp.GetComponent<EnemyBullet>();
    }

    public void AddDamage(int wave)
    {
        if (wave == 1)
        {
            damage = 2;
        }
        if (wave == 2)
        {
            damage = 4;
        }
        if (wave == 3)
        {
            damage = 6;
        }
        if (wave == 4)
        {
            damage = 8;
        }
    }
}
