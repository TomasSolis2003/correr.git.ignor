/*using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vidaMaxima = 10f; // Vida máxima del enemigo
    private float vidaActual; // Vida actual del enemigo

    void Start()
    {
        // Inicializar la vida del enemigo
        vidaActual = vidaMaxima;
    }

    // Método para recibir daño
    public void RecibirDano(float cantidad)
    {
        vidaActual -= cantidad;

        // Si la vida llega a 0, destruir el enemigo
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // Método para destruir el enemigo
    void Morir()
    {
        Destroy(gameObject);
    }
}
*/
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vidaMaxima = 10f; // Vida máxima del enemigo
    private float vidaActual; // Vida actual del enemigo
    private bool destruido = false; // Bandera para verificar si ya fue destruido

    void Start()
    {
        // Inicializar la vida del enemigo
        vidaActual = vidaMaxima;
    }

    // Método para recibir daño
    public void RecibirDano(float cantidad)
    {
        if (destruido) return; // Si el enemigo ya fue destruido, salir de la función

        vidaActual -= cantidad;

        // Si la vida llega a 0, destruir el enemigo
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // Método para destruir el enemigo
    void Morir()
    {
        destruido = true; // Marcar al enemigo como destruido
        Destroy(gameObject); // Destruir el objeto
    }
}
