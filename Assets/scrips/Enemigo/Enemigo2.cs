using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    // Este método se llama cuando el objeto colisiona con otro
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Destruir el objeto enemigo
            Destroy(gameObject);
        }
    }
}
