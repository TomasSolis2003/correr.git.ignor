/*using System.Collections;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public float maxStamina = 100f; // Máxima resistencia
    public float currentStamina; // Resistencia actual
    public float staminaDrainRate = 15f; // Tasa de consumo de resistencia al hacer sprint
    public float staminaRegenRate = 10f; // Tasa de regeneración de resistencia
    public float staminaRegenDelay = 3f; // Tiempo de espera antes de poder regenerar resistencia después de agotar la resistencia
    public float sprintSpeed = 10f; // Velocidad cuando hace sprint
    public float normalSpeed = 5f; // Velocidad normal

    private bool canSprint = true; // Indica si el jugador puede hacer sprint
    private bool isSprinting; // Indica si el jugador está haciendo sprint
    private bool isStaminaRegenDelayed; // Indica si está en el tiempo de espera antes de regenerar resistencia

    private CharacterController characterController;

    void Start()
    {
        currentStamina = maxStamina; // Iniciar con la resistencia máxima
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) && canSprint && characterController.velocity.magnitude > 0;

        if (isSprinting)
        {
            // Reducir la resistencia mientras el jugador corre
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

            // Si la resistencia se agota, impedir que el jugador pueda sprintar
            if (currentStamina <= 0)
            {
                StartCoroutine(HandleStaminaDepletion());
            }
        }
        else
        {
            // Si el jugador no está corriendo y no está en tiempo de espera, regenerar resistencia
            if (!isStaminaRegenDelayed && currentStamina < maxStamina)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }
        }

        // Ajustar la velocidad del jugador
        float currentSpeed = isSprinting ? sprintSpeed : normalSpeed;
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * currentSpeed;
        characterController.Move(move * Time.deltaTime);
    }

    // Coroutine para manejar la espera después de agotar la resistencia
    IEnumerator HandleStaminaDepletion()
    {
        canSprint = false; // Impedir que el jugador haga sprint
        isStaminaRegenDelayed = true; // Activar la espera antes de regenerar resistencia

        // Esperar 3 segundos
        yield return new WaitForSeconds(staminaRegenDelay);

        isStaminaRegenDelayed = false; // Permitir la regeneración de resistencia
        canSprint = true; // Permitir que el jugador pueda volver a correr
    }
}
*/
using System.Collections;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public float maxStamina = 100f; // Máxima resistencia
    public float currentStamina; // Resistencia actual
    public float staminaDrainRate = 15f; // Tasa de consumo de resistencia al hacer sprint
    public float staminaRegenRate = 10f; // Tasa de regeneración de resistencia
    public float staminaRegenDelay = 3f; // Tiempo de espera antes de poder regenerar resistencia después de agotar la resistencia
    public float sprintSpeed = 10f; // Velocidad cuando hace sprint
    public float normalSpeed = 5f; // Velocidad normal

    private bool canSprint = true; // Indica si el jugador puede hacer sprint
    private bool isSprinting; // Indica si el jugador está haciendo sprint
    private bool isStaminaRegenDelayed; // Indica si está en el tiempo de espera antes de regenerar resistencia

    private CharacterController characterController;

    void Start()
    {
        currentStamina = maxStamina; // Iniciar con la resistencia máxima
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) && canSprint && characterController.velocity.magnitude > 0;

        if (isSprinting)
        {
            // Reducir la resistencia mientras el jugador corre
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

            // Si la resistencia se agota, impedir que el jugador pueda sprintar
            if (currentStamina <= 0)
            {
                StartCoroutine(HandleStaminaDepletion());
            }
        }
        else
        {
            // Si el jugador no está corriendo y no está en tiempo de espera, regenerar resistencia
            if (!isStaminaRegenDelayed && currentStamina < maxStamina)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }
        }

        // Ajustar la velocidad del jugador
        float currentSpeed = isSprinting ? sprintSpeed : normalSpeed;
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * currentSpeed;
        characterController.Move(move * Time.deltaTime);
    }

    // Coroutine para manejar la espera después de agotar la resistencia
    IEnumerator HandleStaminaDepletion()
    {
        canSprint = false; // Impedir que el jugador haga sprint
        isStaminaRegenDelayed = true; // Activar la espera antes de regenerar resistencia

        // Esperar 3 segundos
        yield return new WaitForSeconds(staminaRegenDelay);

        isStaminaRegenDelayed = false; // Permitir la regeneración de resistencia
        canSprint = true; // Permitir que el jugador pueda volver a correr
    }
}
