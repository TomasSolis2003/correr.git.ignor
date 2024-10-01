
/*using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;
    public float lifeTime = 5f;
    private int recycleCount = 0;
    public int maxRecycleCount = 7;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Invoke("Recycle", lifeTime); // Desactivar la bala después de un tiempo
    }

    void OnCollisionEnter(Collision collision)
    {
        Recycle(); // Reutilizar la bala al colisionar con cualquier objeto
    }

    void Recycle()
    {
        if (recycleCount < maxRecycleCount)
        {
            recycleCount++;
            gameObject.SetActive(false); // Desactivar el proyectil para reutilizarlo
        }
        else
        {
            Destroy(gameObject); // Destruir el proyectil después de 7 usos
        }
    }

    void OnDisable()
    {
        CancelInvoke(); // Evitar que se llame a Recycle si ya fue desactivado
    }
}
*///salva vidas


using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;
    public float lifeTime = 5f;
    private int recycleCount = 0;
    public int maxRecycleCount = 7;
    public float damage = 1f; // Daño que inflige la bala

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Invoke("Recycle", lifeTime); // Desactivar la bala después de un tiempo
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el componente EnemigoVida
        EnemigoVida enemigo = collision.gameObject.GetComponent<EnemigoVida>();

        // Si colisiona con un enemigo
        if (enemigo != null)
        {
          //  enemigo.RecibirDaño(damage); // Aplicar el daño a la vida del enemigo
        }

        Recycle(); // Reutilizar la bala al colisionar
    }

    void Recycle()
    {
        if (recycleCount < maxRecycleCount)
        {
            recycleCount++;
            gameObject.SetActive(false); // Desactivar el proyectil para reutilizarlo
        }
        else
        {
            Destroy(gameObject); // Destruir el proyectil después de 7 usos
        }
    }

    void OnDisable()
    {
        CancelInvoke(); // Evitar que se llame a Recycle si ya fue desactivado
    }
}

/*using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;
    public float lifeTime = 5f;
    private int recycleCount = 0;
    public int maxRecycleCount = 7;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Invoke("Recycle", lifeTime); // Desactivar la bala después de un tiempo
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el componente EnemigoVida
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Destruir el objeto enemigo
            Destroy(collision.gameObject);
            Recycle(); // Reutilizar la bala al colisionar
            return; // Salir para evitar también llamar a Recycle
        }

        // Si colisiona con cualquier otro objeto, simplemente reciclar la bala
        Recycle();
    }

    void Recycle()
    {
        if (recycleCount < maxRecycleCount)
        {
            recycleCount++;
            gameObject.SetActive(false); // Desactivar el proyectil para reutilizarlo
        }
        else
        {
            Destroy(gameObject); // Destruir el proyectil después de 7 usos
        }
    }

    void OnDisable()
    {
        CancelInvoke(); // Evitar que se llame a Recycle si ya fue desactivado
    }
}
*/
/*using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;
    public float lifeTime = 5f;
    private int recycleCount = 0;
    public int maxRecycleCount = 7;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Invoke("Recycle", lifeTime); // Desactivar la bala después de un tiempo
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "enemigo"
        if (other.CompareTag("Enemigo"))
        {
            // Destruir el objeto enemigo
            Destroy(other.gameObject);
            Recycle(); // Reutilizar la bala al colisionar
            return; // Salir para evitar también llamar a Recycle
        }

        // Si colisiona con cualquier otro objeto, simplemente reciclar la bala
        Recycle();
    }

    void Recycle()
    {
        if (recycleCount < maxRecycleCount)
        {
            recycleCount++;
            gameObject.SetActive(false); // Desactivar el proyectil para reutilizarlo
        }
        else
        {
            Destroy(gameObject); // Destruir el proyectil después de 7 usos
        }
    }

    void OnDisable()
    {
        CancelInvoke(); // Evitar que se llame a Recycle si ya fue desactivado
    }
}
*/
/*using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;
    public float lifeTime = 5f;
    private int recycleCount = 0;
    public int maxRecycleCount = 7;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Invoke("Recycle", lifeTime); // Desactivar la bala después de un tiempo
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "enemigo"
        if (other.CompareTag("Enemigo"))
        {
            // Destruir el objeto enemigo
            Destroy(other.gameObject);
            Recycle(); // Reutilizar la bala al colisionar
            return; // Salir para evitar también llamar a Recycle
        }

        // Si colisiona con cualquier otro objeto, simplemente reciclar la bala
        Recycle();
    }

    void Recycle()
    {
        if (recycleCount < maxRecycleCount)
        {
            recycleCount++;
            gameObject.SetActive(false); // Desactivar el proyectil para reutilizarlo
        }
        else
        {
            Destroy(gameObject); // Destruir el proyectil después de 7 usos
        }
    }

    void OnDisable()
    {
        CancelInvoke(); // Evitar que se llame a Recycle si ya fue desactivado
    }
}
*/