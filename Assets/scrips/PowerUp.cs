using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration = 10f;  // Duración del power-up en segundos
    public GunScript gunScript;          // Referencia al script de la pistola
    private float originalFireRate;      // Guardar el fireRate original de la pistola

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePowerUp();
            gameObject.SetActive(false); // Desactivar el power-up después de recogerlo
        }
    }

    void ActivatePowerUp()
    {
        // Guardar la tasa de disparo original
        originalFireRate = gunScript.fireRate;

        // Cambiar a modo ametralladora (disparos más rápidos)
        gunScript.fireRate = 0.1f;

        // Iniciar la cuenta regresiva para restaurar los valores originales
        Invoke("DeactivatePowerUp", powerUpDuration);
    }

    void DeactivatePowerUp()
    {
        // Restaurar la tasa de disparo original de la pistola
        gunScript.fireRate = originalFireRate;
    }
}

/*using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration = 10f;  // Duración del power-up en segundos
    public GunScript gunScript;          // Referencia al script de la pistola
    public GameObject pistolObject;      // Objeto de la pistola
    public GameObject machineGunObject;  // Objeto de la metralleta

    private int originalAmmo;
    private float originalFireRate;
    private bool isMachineGunActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMachineGunActive)
        {
            ActivatePowerUp();
            gameObject.SetActive(false); // Desactivar el power-up después de recogerlo
        }
    }

    void ActivatePowerUp()
    {
        isMachineGunActive = true;

        // Cambiar a la metralleta
        pistolObject.SetActive(false);
        machineGunObject.SetActive(true);

        // Guardar la munición y la tasa de disparo original
        originalAmmo = gunScript.currentAmmo;
        originalFireRate = gunScript.fireRate;

        // Configurar la metralleta con 30 balas y disparo continuo
        gunScript.currentAmmo = 30;
        gunScript.fireRate = 0.1f; // Disparos rápidos
        gunScript.isAutomatic = true; // Habilitar disparo continuo

        // Iniciar la cuenta regresiva para desactivar el power-up
        Invoke("DeactivatePowerUp", powerUpDuration);
    }

    void DeactivatePowerUp()
    {
        isMachineGunActive = false;

        // Restaurar el objeto de la pistola
        machineGunObject.SetActive(false);
        pistolObject.SetActive(true);

        // Restaurar la munición y la tasa de disparo original
        gunScript.currentAmmo = originalAmmo;
        gunScript.fireRate = originalFireRate;
        gunScript.isAutomatic = false; // Volver al disparo manual
    }
}
*/