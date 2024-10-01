/*using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public Slider sliderVida; // Referencia al slider que representa la vida del jugador
    public float vidaMaxima = 100f; // La cantidad m�xima de vida
    public float vidaActual; // La cantidad actual de vida
    public float velocidadRecuperacion = 5f; // Velocidad a la que se recupera la vida por segundo
    public float tiempoEsperaRecuperacion = 2f; // Tiempo que espera antes de empezar a recuperar vida

    private bool estaPerdiendoVida = false;

    void Start()
    {
        // Inicializamos la vida del jugador en su valor m�ximo
        vidaActual = vidaMaxima;
        sliderVida.maxValue = vidaMaxima;
        sliderVida.value = vidaMaxima;
    }

    void Update()
    {
        // Recuperar vida si no est� perdiendo salud y no est� en el m�ximo
        if (!estaPerdiendoVida && vidaActual < vidaMaxima)
        {
            vidaActual += velocidadRecuperacion * Time.deltaTime;
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Aseguramos que no supere el m�ximo
            sliderVida.value = vidaActual;
        }
    }

    // Llamar a esta funci�n para hacer que el jugador pierda vida
    public void PerderVida(float cantidad)
    {
        vidaActual -= cantidad;
        sliderVida.value = vidaActual;
        estaPerdiendoVida = true;

        // Asegurarnos de que la vida no baje de 0
        if (vidaActual <= 0)
        {
            MuerteJugador();
        }

        // Iniciar la recuperaci�n despu�s de un tiempo
        Invoke("IniciarRecuperacion", tiempoEsperaRecuperacion);
    }

    // Iniciar la recuperaci�n de vida despu�s del tiempo de espera
    void IniciarRecuperacion()
    {
        estaPerdiendoVida = false;
    }

    // Funci�n que se llama cuando la vida del jugador llega a 0
    void MuerteJugador()
    {
        Debug.Log("Jugador ha muerto");
        // Aqu� podr�as agregar la l�gica de muerte, como reiniciar la partida o mostrar Game Over
    }
}
*/
/*using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public Slider sliderVida; // Referencia al slider que representa la vida del jugador
    public float vidaMaxima = 100f; // La cantidad m�xima de vida
    public float vidaActual; // La cantidad actual de vida
    public float velocidadRecuperacion = 5f; // Velocidad a la que se recupera la vida por segundo
    public float tiempoEsperaRecuperacion = 2f; // Tiempo que espera antes de empezar a recuperar vida

    private bool estaPerdiendoVida = false;

    void Start()
    {
        // Inicializamos la vida del jugador en su valor m�ximo
        vidaActual = vidaMaxima;
        sliderVida.maxValue = vidaMaxima;
        sliderVida.value = vidaMaxima;
    }

    void Update()
    {
        // Recuperar vida si no est� perdiendo salud y no est� en el m�ximo
        if (!estaPerdiendoVida && vidaActual < vidaMaxima)
        {
            vidaActual += velocidadRecuperacion * Time.deltaTime;
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Aseguramos que no supere el m�ximo
            sliderVida.value = vidaActual;
        }
    }

    // Llamar a esta funci�n para hacer que el jugador pierda vida
    public void PerderVida(float cantidad)
    {
        vidaActual -= cantidad;
        sliderVida.value = vidaActual;
        estaPerdiendoVida = true;

        // Asegurarnos de que la vida no baje de 0
        if (vidaActual <= 0)
        {
            MuerteJugador();
        }

        // Iniciar la recuperaci�n despu�s de un tiempo
        Invoke("IniciarRecuperacion", tiempoEsperaRecuperacion);
    }

    // Iniciar la recuperaci�n de vida despu�s del tiempo de espera
    void IniciarRecuperacion()
    {
        estaPerdiendoVida = false;
    }

    // Funci�n que se llama cuando la vida del jugador llega a 0
    void MuerteJugador()
    {
        Debug.Log("Jugador ha muerto");
        // Aqu� podr�as agregar la l�gica de muerte, como reiniciar la partida o mostrar Game Over
    }
}
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Para reiniciar la escena

public class VidaJugador : MonoBehaviour
{
    public Slider sliderVida; // Referencia al slider que representa la vida del jugador
    public float vidaMaxima = 100f; // La cantidad m�xima de vida
    public float vidaActual; // La cantidad actual de vida
    public float velocidadRecuperacion = 5f; // Velocidad a la que se recupera la vida por segundo
    public float tiempoEsperaRecuperacion = 2f; // Tiempo que espera antes de empezar a recuperar vida
    public float tiempoInvulnerabilidad = 1f; // Tiempo de invulnerabilidad tras recibir da�o

    public TextMeshProUGUI gameOverText; // Referencia al texto de "Game Over"
    private bool estaPerdiendoVida = false;
    private bool esInvulnerable = false; // Variable para evitar recibir da�o constantemente
    private bool partidaTerminada = false; // Indica si la partida ha terminado

    void Start()
    {
        // Inicializamos la vida del jugador en su valor m�ximo
        vidaActual = vidaMaxima;
        sliderVida.maxValue = vidaMaxima;
        sliderVida.value = vidaMaxima;

        // Asegurarse de que el texto de Game Over est� oculto al inicio
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Si la partida ha terminado, permitir reiniciar presionando "P"
        if (partidaTerminada && Input.GetKeyDown(KeyCode.P))
        {
            ReiniciarPartida();
        }

        // Recuperar vida si no est� perdiendo salud, no est� en el m�ximo y la partida no ha terminado
        if (!estaPerdiendoVida && vidaActual < vidaMaxima && !partidaTerminada)
        {
            vidaActual += velocidadRecuperacion * Time.deltaTime;
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Aseguramos que no supere el m�ximo
            sliderVida.value = vidaActual;
        }
    }

    // Llamar a esta funci�n para hacer que el jugador pierda vida
    public void PerderVida(float cantidad)
    {
        if (esInvulnerable || partidaTerminada) return; // Si el jugador es invulnerable o la partida ha terminado, no recibe da�o

        vidaActual -= cantidad;
        sliderVida.value = vidaActual;
        estaPerdiendoVida = true;
        esInvulnerable = true; // Activamos la invulnerabilidad

        // Asegurarnos de que la vida no baje de 0
        if (vidaActual <= 0)
        {
            MuerteJugador();
        }

        // Iniciar la recuperaci�n despu�s de un tiempo
        Invoke("IniciarRecuperacion", tiempoEsperaRecuperacion);
        // Desactivar la invulnerabilidad despu�s del tiempo especificado
        Invoke("DesactivarInvulnerabilidad", tiempoInvulnerabilidad);
    }

    // Iniciar la recuperaci�n de vida despu�s del tiempo de espera
    void IniciarRecuperacion()
    {
        estaPerdiendoVida = false;
    }

    // Desactivar la invulnerabilidad
    void DesactivarInvulnerabilidad()
    {
        esInvulnerable = false;
    }

    // Funci�n que se llama cuando la vida del jugador llega a 0
    void MuerteJugador()
    {
        Debug.Log("Jugador ha muerto");

        // Mostrar el texto de "Game Over"
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        // Detener la partida
        partidaTerminada = true;
        Time.timeScale = 0f; // Detiene el tiempo en el juego
    }

    // Funci�n para reiniciar la partida
    void ReiniciarPartida()
    {
        Time.timeScale = 1f; // Reactivar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena actual
    }
}
