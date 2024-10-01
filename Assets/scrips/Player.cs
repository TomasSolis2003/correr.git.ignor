using UnityEngine;

public class Jugador : MonoBehaviour
{
    // M�todo para manejar la colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si colisiona con un objeto que tenga el tag "Enemigo"
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Destruimos al jugador
            Destroy(gameObject);
        }
    }
}
