/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float mouseSensitivity = 100f; // Sensibilidad del ratón
    public float jumpForce = 5f; // Fuerza del salto
    public Transform playerBody; // Transform del cuerpo del jugador
    public Transform cameraTransform; // Transform de la cámara

    private Rigidbody rb; // Referencia al Rigidbody del jugador
    private float xRotation = 0f; // Control de la rotación en el eje X (vertical)
    private bool isGrounded; // Indica si el jugador está en el suelo

    void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Obtener el Rigidbody del jugador
        rb = playerBody.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // --- Movimiento del ratón para rotar la cámara y el cuerpo del jugador ---

        // Obtener el movimiento del ratón en los ejes X e Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar la cámara en el eje X (vertical, hacia arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación para no mirar completamente hacia arriba/abajo

        // Aplicar la rotación a la cámara
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el cuerpo del jugador en el eje Y (horizontal, izquierda/derecha)
        playerBody.Rotate(Vector3.up * mouseX);

        // --- Movimiento del jugador ---

        // Capturar las entradas del teclado para movimiento
        float moveX = Input.GetAxis("Horizontal"); // Flechas izquierda/derecha o teclas A/D
        float moveZ = Input.GetAxis("Vertical"); // Flechas arriba/abajo o teclas W/S

        // Crear un vector de movimiento en relación a la cámara
        Vector3 move = cameraTransform.right * moveX + cameraTransform.forward * moveZ;

        // Evitar que el personaje se mueva hacia arriba/abajo (solo mover en X y Z)
        move.y = 0f;

        // Mover el personaje según la velocidad
        playerBody.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // --- Saltar ---
        // Saltar si se presiona la tecla Espacio y el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Método para detectar si el jugador está tocando el suelo (objetos con tag "Ground")
    private void OnCollisionStay(Collision collision)
    {
        // Verifica si el jugador está en contacto con un objeto que tiene el tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando el jugador deja de estar en contacto con el suelo, isGrounded se vuelve false
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento normal
    public float sprintSpeed = 10f; // Velocidad al correr
    public float mouseSensitivity = 100f; // Sensibilidad del ratón
    public float jumpForce = 5f; // Fuerza del salto
    public Transform playerBody; // Transform del cuerpo del jugador
    public Transform cameraTransform; // Transform de la cámara
    public Camera playerCamera; // Referencia a la cámara

    public float normalFOV = 60f; // Campo de visión normal de la cámara
    public float sprintFOV = 80f; // Campo de visión cuando corre
    public float fovTransitionSpeed = 5f; // Velocidad de la transición del FOV

    private Rigidbody rb; // Referencia al Rigidbody del jugador
    private float xRotation = 0f; // Control de la rotación en el eje X (vertical)
    private bool isGrounded; // Indica si el jugador está en el suelo

    void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Obtener el Rigidbody del jugador
        rb = playerBody.GetComponent<Rigidbody>();

        // Obtener la cámara principal si no se asignó
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        // --- Movimiento del ratón para rotar la cámara y el cuerpo del jugador ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación para no mirar completamente hacia arriba/abajo

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // --- Movimiento del jugador ---
        bool isSprinting = Input.GetKey(KeyCode.LeftShift); // Verifica si el jugador está corriendo
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right * moveX + cameraTransform.forward * moveZ;
        move.y = 0f;

        playerBody.Translate(move * currentSpeed * Time.deltaTime, Space.World);

        // --- Campo de visión de la cámara (FOV) al correr ---
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
