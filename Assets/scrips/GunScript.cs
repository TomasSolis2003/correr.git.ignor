/*using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int maxAmmo = 7;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    public float fireRate = 0.2f;  // Tiempo entre disparos (menor para la ametralladora)
    private float nextFireTime = 0f;

    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform firePoint;      // Lugar desde donde se disparará el proyectil
    public int poolSize = 10;        // Tamaño del pool
    private GameObject[] bulletPool; // Array para el pool de balas

    void Start()
    {
        // Inicializar la munición
        currentAmmo = maxAmmo;
        UpdateAmmoText();

        // Crear el pool de balas
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && Time.time >= nextFireTime)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        // Buscar una bala en el pool que esté inactiva
        GameObject bullet = GetInactiveBullet();
        if (bullet != null)
        {
            // Colocar la bala en el punto de disparo y activarla
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            currentAmmo--;
            nextFireTime = Time.time + fireRate;
            UpdateAmmoText();
        }
    }

    GameObject GetInactiveBullet()
    {
        // Buscar una bala inactiva en el pool
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + "/∞";
    }
}
*/
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int maxAmmo = 7;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    public float fireRate = 0.2f;  // Tiempo entre disparos (menor para la ametralladora)
    private float nextFireTime = 0f;

    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform firePoint;      // Lugar desde donde se disparará el proyectil
    public int poolSize = 10;        // Tamaño del pool
    private GameObject[] bulletPool; // Array para el pool de balas

    void Start()
    {
        // Inicializar la munición
        currentAmmo = maxAmmo;
        UpdateAmmoText();

        // Crear el pool de balas
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && Time.time >= nextFireTime)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        // Buscar una bala en el pool que esté inactiva
        GameObject bullet = GetInactiveBullet();
        if (bullet != null)
        {
            // Colocar la bala en el punto de disparo y activarla
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            currentAmmo--;
            nextFireTime = Time.time + fireRate;
            UpdateAmmoText();
        }
    }

    GameObject GetInactiveBullet()
    {
        // Buscar una bala inactiva en el pool
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + "/∞";
    }
}

/*using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int maxAmmo = 7;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    public float fireRate = 0.2f;  // Tiempo entre disparos (menor para la ametralladora)
    private float nextFireTime = 0f;

    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform firePoint;      // Lugar desde donde se disparará el proyectil
    public int poolSize = 10;        // Tamaño del pool
    private GameObject[] bulletPool; // Array para el pool de balas

    void Start()
    {
        // Inicializar la munición
        currentAmmo = maxAmmo;
        UpdateAmmoText();

        // Crear el pool de balas
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && Time.time >= nextFireTime)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        // Buscar una bala en el pool que esté inactiva
        GameObject bullet = GetInactiveBullet();
        if (bullet != null)
        {
            // Colocar la bala en el punto de disparo y activarla
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            currentAmmo--;
            nextFireTime = Time.time + fireRate;
            UpdateAmmoText();
        }
    }

    GameObject GetInactiveBullet()
    {
        // Buscar una bala inactiva en el pool
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + "/∞";
    }
}
*/
/*using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int maxAmmo = 7;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    public float fireRate = 0.2f;  // Tiempo entre disparos
    private float nextFireTime = 0f;

    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform firePoint;      // Lugar desde donde se disparará el proyectil
    public int poolSize = 10;        // Tamaño del pool
    private GameObject[] bulletPool; // Array para el pool de balas

    void Start()
    {
        // Inicializar la munición
        currentAmmo = maxAmmo;
        UpdateAmmoText();

        // Crear el pool de balas
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab);
            bulletPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && Time.time >= nextFireTime)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        // Buscar una bala en el pool que esté inactiva
        GameObject bullet = GetInactiveBullet();
        if (bullet != null)
        {
            // Colocar la bala en el punto de disparo y activarla
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            currentAmmo--;
            nextFireTime = Time.time + fireRate;
            UpdateAmmoText();
        }
    }

    GameObject GetInactiveBullet()
    {
        // Buscar una bala inactiva en el pool
        foreach (GameObject bullet in bulletPool)
        {
            if (bullet != null && !bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        // Si no hay balas inactivas, considerar crear una nueva si el pool lo permite
        if (bulletPool.Length < poolSize)
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.SetActive(false);
            bulletPool = AddToPool(bulletPool, newBullet);
            return newBullet;
        }

        return null; // No hay balas disponibles
    }

    GameObject[] AddToPool(GameObject[] pool, GameObject newBullet)
    {
        GameObject[] newPool = new GameObject[pool.Length + 1];
        for (int i = 0; i < pool.Length; i++)
        {
            newPool[i] = pool[i];
        }
        newPool[pool.Length] = newBullet;
        return newPool;
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + "/∞";
    }
}
*/