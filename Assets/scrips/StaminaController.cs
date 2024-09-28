
/*using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDrainRate = 15f;
    public float staminaRegenRate = 10f;
    public float staminaRegenDelay = 3f;
    public float sprintSpeed = 10f;
    public float normalSpeed = 5f;
    public float jumpHeight = 2f; // Altura del salto
    public float gravity = -9.81f;

    public Slider staminaBar;

    private bool canSprint = true;
    private bool isStaminaRegenDelayed;

    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;

        characterController = GetComponent<CharacterController>(); // Obtener el CharacterController
    }

    void Update()
    {
        // Aplicar gravedad manualmente
        if (IsGrounded() && velocity.y < 0)
        {
            velocity.y = -2f; // Mantener al jugador en el suelo
        }

        // Movimiento de sprint y normal
        SprintAndMove();

        // Saltar
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity); // Cálculo para saltar
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Control de la resistencia (stamina)
        HandleStamina();
    }

    void SprintAndMove()
    {
        // Movimiento del jugador
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Ajustar la velocidad según si está sprintando o no
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) && canSprint ? sprintSpeed : normalSpeed;
        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    void HandleStamina()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && canSprint && characterController.velocity.magnitude > 0;

        if (isSprinting)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

            // Actualizar la barra de stamina
            staminaBar.value = currentStamina;

            if (currentStamina <= 0)
            {
                StartCoroutine(HandleStaminaDepletion());
            }
        }
        else
        {
            if (!isStaminaRegenDelayed && currentStamina < maxStamina)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

                // Actualizar la barra de stamina
                staminaBar.value = currentStamina;
            }
        }
    }

    IEnumerator HandleStaminaDepletion()
    {
        canSprint = false; // El jugador no puede sprintar
        isStaminaRegenDelayed = true; // Detener la regeneración por 3 segundos

        yield return new WaitForSeconds(staminaRegenDelay); // Esperar

        isStaminaRegenDelayed = false;
        canSprint = true; // Permitir que el jugador vuelva a sprintar
    }

    // Método para detectar si el jugador está en el suelo usando un Raycast
    bool IsGrounded()
    {
        // El Raycast verifica una pequeña distancia por debajo del jugador
        return Physics.Raycast(transform.position, Vector3.down, characterController.height / 2 + 0.1f);
    }
}
*/
//respaldo original
/*using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaSlider; // Asigna tu slider en el Inspector
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRecoveryRate = 5f; // Tasa de recuperación de estamina
    public float staminaUsageRate = 10f; // Estamina consumida por segundo

    private void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    private void Update()
    {
        // Usar estamina al mantener presionado Shift
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            UseStamina(staminaUsageRate * Time.deltaTime); // Reduce estamina
        }
        else
        {
            RecoverStamina(staminaRecoveryRate * Time.deltaTime); // Recupera estamina si no se usa
        }

        staminaSlider.value = currentStamina; // Actualiza el slider
    }

    void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina a 0
    }

    void RecoverStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina al máximo
    }
}
*/
/*using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaSlider; // Asigna tu slider en el Inspector
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRecoveryRate = 5f; // Tasa de recuperación de estamina
    public float staminaUsageRate = 10f; // Estamina consumida por segundo

    public CharacterController controller; // Asigna el CharacterController en el Inspector
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float gravity = -9.81f; // Fuerza de gravedad
    public float jumpHeight = 1.5f; // Altura del salto
    private Vector3 velocity; // Velocidad del jugador

    private bool isGrounded; // Para verificar si el jugador está en el suelo

    private void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    private void Update()
    {
        // Comprobar si el jugador está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantener al jugador en el suelo
        }

        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Usar estamina al mantener presionado Shift
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && move.magnitude > 0)
        {
            UseStamina(staminaUsageRate * Time.deltaTime); // Reduce estamina al moverse
            controller.Move(move * moveSpeed * 1.5f * Time.deltaTime); // Aumenta velocidad al usar estamina
        }
        else
        {
            RecoverStamina(staminaRecoveryRate * Time.deltaTime); // Recupera estamina si no se usa
            controller.Move(move * moveSpeed * Time.deltaTime); // Movimiento normal
        }

        // Gravedad
        velocity.y += gravity * Time.deltaTime; // Aplicar gravedad
        controller.Move(velocity * Time.deltaTime); // Mover al jugador con gravedad

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calcular la fuerza de salto
        }

        staminaSlider.value = currentStamina; // Actualiza el slider
    }

    void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina a 0
    }

    void RecoverStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina al máximo
    }
}
*/
//buen codigo
/*
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaSlider; // Asigna tu slider en el Inspector
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRecoveryRate = 5f; // Tasa de recuperación de estamina
    public float staminaUsageRate = 10f; // Estamina consumida por segundo

    public CharacterController controller; // Asigna el CharacterController en el Inspector
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float sprintSpeedMultiplier = 1.5f; // Multiplicador de velocidad al sprintar
    public float gravity = -9.81f; // Fuerza de gravedad
    public float jumpHeight = 1.5f; // Altura del salto
    private Vector3 velocity; // Velocidad del jugador

    private bool isGrounded; // Para verificar si el jugador está en el suelo

    private void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    private void Update()
    {
        // Comprobar si el jugador está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantener al jugador en el suelo
        }

        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Usar estamina al mantener presionado Shift
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && move.magnitude > 0)
        {
            UseStamina(staminaUsageRate * Time.deltaTime); // Reduce estamina al moverse
            controller.Move(move * moveSpeed * sprintSpeedMultiplier * Time.deltaTime); // Aumenta velocidad al usar estamina
        }
        else
        {
            RecoverStamina(staminaRecoveryRate * Time.deltaTime); // Recupera estamina si no se usa
            controller.Move(move * moveSpeed * Time.deltaTime); // Movimiento normal
        }

        // Gravedad
        velocity.y += gravity * Time.deltaTime; // Aplicar gravedad
        controller.Move(velocity * Time.deltaTime); // Mover al jugador con gravedad

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calcular la fuerza de salto
        }

        // Actualiza el slider
        staminaSlider.value = currentStamina;

        // Desactivar sprint si la estamina llega a 0
        if (currentStamina <= 0)
        {
            // Puedes añadir un mensaje o cambiar el comportamiento aquí si lo deseas
        }
    }

    void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina a 0
    }

    void RecoverStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina al máximo
    }
}*/
//buen codigo.2

using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaSlider; // Asigna tu slider en el Inspector
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRecoveryRate = 5f; // Tasa de recuperación de estamina
    public float staminaUsageRate = 10f; // Estamina consumida por segundo

    public float sprintSpeedMultiplier = 1.5f; // Multiplicador de velocidad al sprintar

    private void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    private void Update()
    {
        // Actualiza el slider
        staminaSlider.value = currentStamina;
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina a 0
    }

    public void RecoverStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // Limitar estamina al máximo
    }

    public bool CanSprint()
    {
        return currentStamina > 0;
    }
}
