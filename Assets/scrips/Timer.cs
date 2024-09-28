using UnityEngine;
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
