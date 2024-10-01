/*using UnityEngine;
using TMPro; // Asegúrate de incluir esta referencia para TextMeshPro

public class TimerText : MonoBehaviour
{
    public float timeRemaining = 300f; // 5 minutos (300 segundos)
    public TextMeshProUGUI timerText; // Referencia al componente TextMeshProUGUI

    private bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Se acabó el tiempo");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Para evitar que el contador muestre 0:00 instantáneamente

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Rescate en:{0:00}:{1:00}", minutes, seconds);
    }
}
*/
using UnityEngine;
using TMPro; // Asegúrate de incluir esta referencia para TextMeshPro
using UnityEngine.SceneManagement; // Para reiniciar la escena

public class TimerText : MonoBehaviour
{
    public float timeRemaining = 300f; // 5 minutos (300 segundos)
    public TextMeshProUGUI timerText; // Referencia al componente TextMeshProUGUI
    public TextMeshProUGUI gameOverText; // Referencia al componente TextMeshProUGUI para "GAME OVER"

    private bool timerIsRunning = true;

    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Ocultar el texto "GAME OVER" al inicio
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }

        // Si se presiona "P", reiniciar la partida
        if (Input.GetKeyDown(KeyCode.P))
        {
            RestartGame();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Para evitar que el contador muestre 0:00 instantáneamente

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Rescate en: {0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Time.timeScale = 0; // Pausar el juego
        gameOverText.gameObject.SetActive(true); // Mostrar el texto "GAME OVER"
        gameOverText.text = "GAME OVER press p for reset."; // Asignar el texto
    }

    void RestartGame()
    {
        Time.timeScale = 1; // Restablecer el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
    }
}
