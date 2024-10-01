/*using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    public int vida = 5;  // Puntos de vida del enemigo

    // Método para manejar la colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si colisiona con un objeto que tenga el tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Restamos un punto de vida
            vida--;

            // Destruimos la bala al colisionar
            Destroy(collision.gameObject);

            // Si la vida del enemigo llega a 0, destruimos al enemigo
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
*/
/*using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    public float vida = 5f;  // Puntos de vida del enemigo

    // Método para recibir daño
    public void RecibirDaño(float cantidadDeDaño)
    {
        vida -= cantidadDeDaño; // Restar la cantidad de daño de la vida

        // Si la vida llega a 0 o menos, destruimos al enemigo
        if (vida <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
*/
using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    public int vida = 5;  // Puntos de vida del enemigo

    // Método para manejar la colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si colisiona con un objeto que tenga el tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Restamos un punto de vida
            vida--;

            // Destruimos la bala al colisionar
            Destroy(collision.gameObject);

            // Si la vida del enemigo llega a 0 o menos, destruimos al enemigo
            if (vida <= 0)
            {
                Destroy(gameObject); // Destruir el enemigo
            }
        }
    }
}
