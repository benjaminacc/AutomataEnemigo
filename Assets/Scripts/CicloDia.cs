using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDia : MonoBehaviour
{
    float tiempoReal = 300f;
    public float horaInicial = 7f; // Hora en la que empieza el ciclo (7 AM)

    // Método para obtener la hora actual del juego (en un ciclo de 24 horas)
    public float GetCurrentGameHour()
    {
        // Calcula el tiempo transcurrido en el ciclo y lo convierte en una hora del día
        float timeInCycle = (Time.time % tiempoReal) / tiempoReal;
        
        // Agrega la hora inicial (7 AM) y ajusta el resultado con mod 24 para que esté entre 0 y 24
        return (timeInCycle * 24f + horaInicial) % 24f;
    }

    // Método para determinar si es de día o de noche
    public bool IsDayTime()
    {
        // Calcula la hora actual del juego
        float currentHour = GetCurrentGameHour();

        // Se considera de día entre las 6:00 y las 18:00 (6 AM a 6 PM)
        return currentHour >= 6f && currentHour < 18f;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Hora actual: " + GetCurrentGameHour());
            Debug.Log("¿Es de día? " + IsDayTime());
        }
    }
}
