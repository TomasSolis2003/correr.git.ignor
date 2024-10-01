/*using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
*/

/*using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float fuerzaEmpuje = 10f; // Fuerza con la que el enemigo empuja al jugador
    public float porcentajeDano = 0.2f; // Porcentaje de vida que el jugador pierde al ser golpeado

    private void Update()
    {
        // El enemigo se mueve hacia el jugador
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si colisiona con el jugador (suponemos que el jugador tiene el tag "Jugador")
        if (collision.gameObject.CompareTag("Jugador"))
        {
            // Aplicamos el daño al jugador (suponemos que el jugador tiene el script VidaJugador)
            VidaJugador vidaJugador = collision.gameObject.GetComponent<VidaJugador>();
            if (vidaJugador != null)
            {
                vidaJugador.PerderVida(vidaJugador.vidaMaxima * porcentajeDano);
            }

            // Empujamos al jugador lejos del enemigo
            Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
                // Calculamos la dirección de empuje (desde el enemigo hacia el jugador)
                Vector3 direccionEmpuje = collision.transform.position - transform.position;
                direccionEmpuje.y = 0; // Evitamos empujarlo hacia arriba
                direccionEmpuje.Normalize();

                // Aplicamos la fuerza de empuje al jugador
                rbJugador.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
            }
        }
    }
}
*/
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float fuerzaEmpuje = 10f; // Fuerza con la que el enemigo empuja al jugador
    public float porcentajeDano = 0.2f; // Porcentaje de vida que el jugador pierde al ser golpeado

    private void Update()
    {
        // El enemigo se mueve hacia el jugador
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si colisiona con el jugador (suponemos que el jugador tiene el tag "Jugador")
        if (collision.gameObject.CompareTag("Jugador"))
        {
            // Aplicamos el daño al jugador (suponemos que el jugador tiene el script VidaJugador)
            VidaJugador vidaJugador = collision.gameObject.GetComponent<VidaJugador>();
            if (vidaJugador != null)
            {
                vidaJugador.PerderVida(vidaJugador.vidaMaxima * porcentajeDano); // Reduce solo el 20%
            }

            // Empujamos al jugador lejos del enemigo
            Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
                // Calculamos la dirección de empuje (desde el enemigo hacia el jugador)
                Vector3 direccionEmpuje = collision.transform.position - transform.position;
                direccionEmpuje.y = 0; // Evitamos empujarlo hacia arriba
                direccionEmpuje.Normalize();

                // Aplicamos la fuerza de empuje al jugador
                rbJugador.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
            }
        }
    }
}
