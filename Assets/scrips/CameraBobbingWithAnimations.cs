/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobbingWithAnimations : MonoBehaviour
{
    public Animator cameraAnimator; // El componente Animator que controla las animaciones de la cámara

    void Update()
    {
        // Detectar si alguna de las teclas de movimiento está siendo presionada
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            // Iniciar la animación de bobbing
            cameraAnimator.SetBool("isWalking", true);
        }
        else
        {
            // Detener la animación de bobbing cuando no se está moviendo
            cameraAnimator.SetBool("isWalking", false);
        }

        // Detectar la dirección para reproducir animaciones específicas (si es necesario)
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
    public Animator cameraAnimator; // El Animator que controla las animaciones de la cámara

    void Update()
    {
        // Detectar la dirección y activar la animación correspondiente
        if (Input.GetKeyDown("a")) // Paso a la izquierda (A)
        {
            cameraAnimator.SetTrigger("stepLeft");
        }
        else if (Input.GetKeyDown("d")) // Paso a la derecha (D)
        {
            cameraAnimator.SetTrigger("stepRight");
        }

        // Opcionalmente, puedes agregar otros controles para W/S si tienes más animaciones
        if (Input.GetKeyDown("w"))
        {
            // Aquí podrías agregar un trigger para animaciones al avanzar
        }
        if (Input.GetKeyDown("s"))
        {
            // Aquí podrías agregar un trigger para animaciones al retroceder
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
