using System.Collections;
using System.Collections.Generic;
using BBSamples.PQSG;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasTime : MonoBehaviour
{
    // Referencia al script DoneDayNightCycle.cs
    public DoneDayNightCycle doneDayNightCycle;

    // UI elements (con TextMeshPro)
    public TMP_Text timeText; // Referencia al TextMeshPro para mostrar la hora
    public TMP_Text dayNightText; // Texto para mostrar si es de día o noche

    void Update()
    {
        // Calcular el tiempo en horas basado en el ciclo de día y noche
        float horaActual = ObtenerHoraActual();

        // Actualizar UI con la hora actual
        ActualizarTimeUI(horaActual);

        // Verificar si es de día o noche usando doneDayNightCycle
        ActualizarDayNightUI();
    }

    float ObtenerHoraActual()
    {
        // Usamos la duración del día del ciclo para calcular la hora actual en un ciclo de 24 horas
        float timeInCycle = (Time.time % doneDayNightCycle.dayDuration) / doneDayNightCycle.dayDuration;
        return timeInCycle * 24f; // Convertimos el tiempo transcurrido en una hora de 24
    }

    void ActualizarTimeUI(float horaActual)
    {
        int hours = Mathf.FloorToInt(horaActual);
        int minutes = Mathf.FloorToInt((horaActual - hours) * 60);
        timeText.text = $"Hora: {hours:D2}:{minutes:D2}"; // Formato HH:MM
    }

    void ActualizarDayNightUI()
    {
        // Usar la propiedad isNight de DoneDayNightCycle para determinar si es de noche
        if (doneDayNightCycle.isNight)
        {
            dayNightText.text = "Es de noche";
        }
        else
        {
            dayNightText.text = "Es de día";
        }
    }
}
