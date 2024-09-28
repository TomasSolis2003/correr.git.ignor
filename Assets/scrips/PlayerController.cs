
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento normal
    public float sprintSpeed = 10f; // Velocidad al correr
    public float mouseSensitivity = 100f; // Sensibilidad del rat�n
    public float jumpForce = 5f; // Fuerza del salto
    public Transform playerBody; // Transform del cuerpo del jugador
    public Transform cameraTransform; // Transform de la c�mara
    public Camera playerCamera; // Referencia a la c�mara

    public float normalFOV = 60f; // Campo de visi�n normal de la c�mara
    public float sprintFOV = 80f; // Campo de visi�n cuando corre
    public float fovTransitionSpeed = 5f; // Velocidad de la transici�n del FOV

    private Rigidbody rb; // Referencia al Rigidbody del jugador
    private float xRotation = 0f; // Control de la rotaci�n en el eje X (vertical)
    private bool isGrounded; // Indica si el jugador est� en el suelo

    void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Obtener el Rigidbody del jugador
        rb = playerBody.GetComponent<Rigidbody>();

        // Obtener la c�mara principal si no se asign�
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        // --- Movimiento del rat�n para rotar la c�mara y el cuerpo del jugador ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotaci�n para no mirar completamente hacia arriba/abajo

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // --- Movimiento del jugador ---
        bool isSprinting = Input.GetKey(KeyCode.LeftShift); // Verifica si el jugador est� corriendo
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right * moveX + cameraTransform.forward * moveZ;
        move.y = 0f;

        playerBody.Translate(move * currentSpeed * Time.deltaTime, Space.World);

        // --- Campo de visi�n de la c�mara (FOV) al correr ---
        float targetFOV = isSprinting ? sprintFOV : normalFOV;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, fovTransitionSpeed * Time.deltaTime);

        // --- Saltar ---
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
*///respaldo

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento normal
    public float sprintSpeed = 10f; // Velocidad al correr
    public float mouseSensitivity = 100f; // Sensibilidad del rat�n
    public float jumpForce = 5f; // Fuerza del salto
    public Transform cameraTransform; // Transform de la c�mara
    public Camera playerCamera; // Referencia a la c�mara

    public float normalFOV = 60f; // Campo de visi�n normal de la c�mara
    public float sprintFOV = 80f; // Campo de visi�n cuando corre
    public float fovTransitionSpeed = 5f; // Velocidad de la transici�n del FOV

    private CharacterController controller; // Referencia al CharacterController
    private float xRotation = 0f; // Control de la rotaci�n en el eje X (vertical)
    private bool isGrounded; // Indica si el jugador est� en el suelo
    private StaminaController staminaController; // Referencia al controlador de estamina

    private Vector3 velocity; // Velocidad del jugador

    private bool isFatigued = false; // Indica si el jugador est� fatigado

    private void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Obtener el CharacterController del jugador
        controller = GetComponent<CharacterController>();

        // Obtener el controlador de estamina
        staminaController = GetComponent<StaminaController>();
    }

    private void Update()
    {
        // Movimiento del rat�n para rotar la c�mara y el cuerpo del jugador
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotaci�n para no mirar completamente hacia arriba/abajo

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Movimiento del jugador
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && staminaController.CanSprint() && !isFatigued; // Solo puede correr si no est� fatigado
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right * moveX + cameraTransform.forward * moveZ;
        move.y = 0f;

        // Aplicar movimiento y gravedad
        if (isGrounded)
        {
            velocity.y = 0f; // Resetear la velocidad vertical si est� en el suelo

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpForce; // Establecer fuerza de salto
            }
        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime; // Aplicar gravedad
        }

        controller.Move((move * currentSpeed + velocity) * Time.deltaTime);

        // Campo de visi�n de la c�mara (FOV)
        float targetFOV = isSprinting ? sprintFOV : normalFOV;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, fovTransitionSpeed * Time.deltaTime);

        // Usar estamina al correr
        if (isSprinting)
        {
            staminaController.UseStamina(staminaController.staminaUsageRate * Time.deltaTime);
        }
        else
        {
            staminaController.RecoverStamina(staminaController.staminaRecoveryRate * Time.deltaTime);
        }

        // Verificar si la estamina ha llegado a 0 y el jugador no est� fatigado
        if (staminaController.currentStamina <= 0 && !isFatigued)
        {
            StartCoroutine(HandleFatigue());
        }

        // Actualizar si est� en el suelo
        isGrounded = controller.isGrounded;

        // Verificar si la estamina se ha recuperado suficientemente para permitir correr nuevamente
        if (isFatigued && staminaController.currentStamina > staminaController.maxStamina * 0.5f)
        {
            isFatigued = false; // El jugador puede volver a correr cuando se recupere un 50% de la estamina
        }
    }

    private IEnumerator HandleFatigue()
    {
        isFatigued = true; // El jugador est� fatigado
        float originalFOV = playerCamera.fieldOfView; // Guardar el FOV actual

        // Transici�n al FOV normal
        while (playerCamera.fieldOfView != normalFOV)
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, normalFOV, fovTransitionSpeed * Time.deltaTime);
            yield return null; // Esperar al siguiente frame
        }

        // Esperar 3 segundos de fatiga
        yield return new WaitForSeconds(3f);
    }
}
//respaldo mejorado
/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento normal
    public float sprintSpeed = 10f; // Velocidad al correr
    public float mouseSensitivity = 100f; // Sensibilidad del rat�n
    public float jumpForce = 5f; // Fuerza del salto
    public Transform cameraTransform; // Transform de la c�mara
    public Camera playerCamera; // Referencia a la c�mara

    public float normalFOV = 60f; // Campo de visi�n normal de la c�mara
    public float sprintFOV = 80f; // Campo de visi�n cuando corre
    public float fovTransitionSpeed = 5f; // Velocidad de la transici�n del FOV

    private CharacterController controller; // Referencia al CharacterController
    private float xRotation = 0f; // Control de la rotaci�n en el eje X (vertical)
    private bool isGrounded; // Indica si el jugador est� en el suelo
    private StaminaController staminaController; // Referencia al controlador de estamina

    private Vector3 velocity; // Velocidad del jugador

    // Propiedad p�blica para acceder al estado de sprint desde otros scripts
    public bool isSprinting { get; private set; }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        staminaController = GetComponent<StaminaController>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotaci�n para no mirar completamente hacia arriba/abajo

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        isSprinting = Input.GetKey(KeyCode.LeftShift) && staminaController.CanSprint();
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right * moveX + cameraTransform.forward * moveZ;
        move.y = 0f;

        if (isGrounded)
        {
            velocity.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }

        controller.Move((move * currentSpeed + velocity) * Time.deltaTime);

        float targetFOV = isSprinting ? sprintFOV : normalFOV;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, fovTransitionSpeed * Time.deltaTime);

        if (isSprinting)
        {
            staminaController.UseStamina(staminaController.staminaUsageRate * Time.deltaTime);
        }
        else
        {
            staminaController.RecoverStamina(staminaController.staminaRecoveryRate * Time.deltaTime);
        }

        if (staminaController.currentStamina <= 0)
        {
            StartCoroutine(HandleFatigue());
        }

        isGrounded = controller.isGrounded;
    }

    private IEnumerator HandleFatigue()
    {
        float originalFOV = playerCamera.fieldOfView;
        playerCamera.fieldOfView = normalFOV;

        yield return new WaitForSeconds(1f);

        playerCamera.fieldOfView = originalFOV;
    }
}
*/