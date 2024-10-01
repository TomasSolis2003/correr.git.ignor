using UnityEngine;

public class GiantEnemy : MonoBehaviour
{
    public float moveSpeed = 1f; // Velocidad lenta del enemigo
    public float shootInterval = 10f; // Tiempo entre disparos
    public GameObject projectilePrefab; // Prefab del objeto que disparará
    public Transform firePoint; // Punto desde donde se disparará el proyectil
    private Transform player; // Referencia al jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Jugador").transform; // Encontrar al jugador por su tag
        InvokeRepeating("ShootAtPlayer", shootInterval, shootInterval); // Disparar cada 10 segundos
    }

    void Update()
    {
        MoveTowardsPlayer(); // Moverse hacia el jugador lentamente
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Moverse lentamente hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void ShootAtPlayer()
    {
        if (player != null)
        {
            // Crear el proyectil y dispararlo hacia el jugador
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            Vector3 shootDirection = (player.position - firePoint.position).normalized;
            rb.velocity = shootDirection * 10f; // Velocidad del proyectil
        }
    }
}
