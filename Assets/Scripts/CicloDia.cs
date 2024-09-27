 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDia : MonoBehaviour
{
    private const float TIEMPO_REAL = 300f; // Duración de un ciclo en tiempo real (5 minutos)
    private const float HORA_INICIO_DIA = 6f; // Hora en la que comienza el día (6 AM)
    private const float HORA_FIN_DIA = 18f; // Hora en la que termina el día (6 PM)


    [Tooltip("Hora en la que comienza el ciclo (7 AM)")]
    public float horaInicial = 7f;

    /// <summary>
    /// Obtiene la hora actual del juego en un ciclo de 24 horas.
    /// </summary>
    /// <returns>La hora actual del juego.</returns>
    public float ObtenerHoraActual()
    {
        // Calcula el tiempo transcurrido en el ciclo y lo convierte en una hora de 24 horas
        float timeInCycle = (Time.time % TIEMPO_REAL) / TIEMPO_REAL;

        // Agrege la hora inicial (7 AM) y ajusta el resultado con mod 24 hrs para que esté entre 0 y 24
        return (timeInCycle * 24f + horaInicial) % 24f;
    }

    /// <summary>
    /// Determina si es de día o de noche en el juego.
    /// </summary>
    public bool IsDayTime()
    {
        // Calcula la hora actual del juego
        float currentHour = ObtenerHoraActual();

        // Se considera de día entre las 6:00 y las 18:00 (6 AM a 6 PM)
        return currentHour >= HORA_INICIO_DIA && currentHour < HORA_FIN_DIA;
    }

    private void OnValidate()
    {
        // Asegura que horaInicial esté dentro del rango de 0 a 24
        if (horaInicial < 0f || horaInicial >= 24f)
        {
            Debug.LogWarning("La hora inicial debe estar entre 0 y 24. Ajustando a 7 AM por defecto.");
            horaInicial = 7f;
        }
    }
}
