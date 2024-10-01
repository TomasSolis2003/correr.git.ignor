/*using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Salud máxima del enemigo
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar salud
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud

        if (currentHealth <= 0)
        {
            Die(); // Si la salud es 0 o menor, el enemigo muere
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destruir al enemigo
    }
}
*/
/*using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Salud máxima del enemigo
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar salud
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud

        if (currentHealth <= 0)
        {
            Die(); // Si la salud es 0 o menor, el enemigo muere
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destruir al enemigo
    }
}
*/
/*using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Salud máxima del enemigo
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud actual
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud

        if (currentHealth <= 0)
        {
            Die(); // Si la salud llega a 0, destruir al enemigo
        }
    }

    // Método para destruir al enemigo
    void Die()
    {
        Destroy(gameObject); // Destruir el objeto del enemigo
    }
}
*/
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Salud máxima del enemigo
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud actual
    }

    // Método que se llama cuando el enemigo colisiona con otro objeto
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado tiene el tag "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // Aplicar 1 punto de daño
        }
    }

    // Método para reducir la salud del enemigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud

        if (currentHealth <= 0)
        {
            Die(); // Si la salud llega a 0, destruir al enemigo
        }
    }

    // Método para destruir al enemigo
    void Die()
    {
        Destroy(gameObject); // Destruir el objeto del enemigo
    }
}
