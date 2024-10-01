using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform puntoDisparo; // Punto desde donde se disparará el proyectil
    public float fuerzaDisparo = 20f; // Fuerza con la que el proyectil será disparado

    void Update()
    {
        // Detectar si se hace clic para disparar
        if (Input.GetButtonDown("Fire1")) // Fire1 es el botón izquierdo del mouse por defecto
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instanciar el proyectil en el punto de disparo
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Obtener el componente Rigidbody del proyectil para aplicar la fuerza
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
        }
    }
}
