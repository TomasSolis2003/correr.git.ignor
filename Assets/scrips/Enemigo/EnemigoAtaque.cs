using UnityEngine;

public class EnemigoAtaque : MonoBehaviour
{
    public float fuerzaEmpuje = 10f; // Fuerza con la que el enemigo empuja al jugador
    public float porcentajeDano = 0.2f; // Porcentaje de vida que el jugador pierde al ser golpeado

    // M�todo para manejar la colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si colisiona con el jugador (suponemos que el jugador tiene el tag "Jugador")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplicamos el da�o al jugador (suponemos que el jugador tiene el script VidaJugador)
            VidaJugador vidaJugador = collision.gameObject.GetComponent<VidaJugador>();
            if (vidaJugador != null)
            {
                vidaJugador.PerderVida(vidaJugador.vidaMaxima * porcentajeDano);
            }

            // Empujamos al jugador lejos del enemigo
            Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
                // Calculamos la direcci�n de empuje (desde el enemigo hacia el jugador)
                Vector3 direccionEmpuje = collision.transform.position - transform.position;
                direccionEmpuje.y = 0; // Evitamos empujarlo hacia arriba
                direccionEmpuje.Normalize();

                // Aplicamos la fuerza de empuje al jugador
                rbJugador.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
            }
        }
    }
}
