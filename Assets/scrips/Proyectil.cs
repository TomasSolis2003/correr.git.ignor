/*using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoVida = 5f; // Tiempo de vida del proyectil antes de que se autodestruya
    public float dano = 5f; // Daño que inflige el proyectil al enemigo

    void Start()
    {
        // Destruir el proyectil después de un tiempo si no colisiona con nada
        Destroy(gameObject, tiempoVida);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el proyectil colisiona con un enemigo (tag "Enemigo")
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Obtener el script de vida del enemigo
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();

            if (enemigo != null)
            {
                // Aplicar daño al enemigo
                enemigo.RecibirDano(dano);
            }

            // Destruir el proyectil después de impactar
            Destroy(gameObject);
        }
        else
        {
            // Destruir el proyectil al colisionar con cualquier cosa
            Destroy(gameObject);
        }
    }
}
*/
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoVida = 5f; // Tiempo de vida del proyectil antes de que se autodestruya
    public float dano = 5f; // Daño que inflige el proyectil al enemigo

    void Start()
    {
        // Destruir el proyectil después de un tiempo si no colisiona con nada
        Destroy(gameObject, tiempoVida);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el proyectil colisiona con un enemigo (tag "Enemigo")
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Obtener el script de vida del enemigo
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();

            // Asegurarse de que el enemigo no haya sido destruido previamente
            if (enemigo != null)
            {
                // Aplicar daño al enemigo
                enemigo.RecibirDano(dano);
            }

            // Destruir el proyectil después de impactar
            Destroy(gameObject);
        }
        else
        {
            // Destruir el proyectil al colisionar con cualquier cosa
            Destroy(gameObject);
        }
    }
}
