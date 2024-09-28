/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobbingWithAnimations : MonoBehaviour
{
    public Animator cameraAnimator; // El componente Animator que controla las animaciones de la c�mara

    void Update()
    {
        // Detectar si alguna de las teclas de movimiento est� siendo presionada
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            // Iniciar la animaci�n de bobbing
            cameraAnimator.SetBool("isWalking", true);
        }
        else
        {
            // Detener la animaci�n de bobbing cuando no se est� moviendo
            cameraAnimator.SetBool("isWalking", false);
        }

        // Detectar la direcci�n para reproducir animaciones espec�ficas (si es necesario)
        if (Input.GetKey("a"))
        {
            cameraAnimator.SetTrigger("stepLeft");
        }
        else if (Input.GetKey("d"))
        {
            cameraAnimator.SetTrigger("stepRight");
        }
    }
}
*/

/*using UnityEngine;

public class CameraBobbingWithSteps : MonoBehaviour
{
    public Animator cameraAnimator; // El Animator que controla las animaciones de la c�mara

    void Update()
    {
        // Detectar la direcci�n y activar la animaci�n correspondiente
        if (Input.GetKeyDown("a")) // Paso a la izquierda (A)
        {
            cameraAnimator.SetTrigger("stepLeft");
        }
        else if (Input.GetKeyDown("d")) // Paso a la derecha (D)
        {
            cameraAnimator.SetTrigger("stepRight");
        }

        // Opcionalmente, puedes agregar otros controles para W/S si tienes m�s animaciones
        if (Input.GetKeyDown("w"))
        {
            // Aqu� podr�as agregar un trigger para animaciones al avanzar
        }
        if (Input.GetKeyDown("s"))
        {
            // Aqu� podr�as agregar un trigger para animaciones al retroceder
        }
    }
}
*/
using UnityEngine;

public class CameraBobbingWithSteps : MonoBehaviour
{
    public Animator cameraAnimator;
    private bool isLeftStep = true;

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if (isLeftStep)
            {
                cameraAnimator.SetTrigger("stepLeft");
                isLeftStep = false;
            }
            else
            {
                cameraAnimator.SetTrigger("stepRight");
                isLeftStep = true;
            }
        }
    }
}
