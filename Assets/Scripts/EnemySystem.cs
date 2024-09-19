using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{
    public Transform[] puntosPatrulla; // Puntos de patrullaje
    public Transform jugador; // Referencia al jugador
    public float rangoDeteccion = 10f; // Distancia de detección
    public float rangoAtaque = 2f; // Distancia de ataque
    public float rangoRegresoPatrulla = 15f; // Rango para regresar a patrullar
    public AudioSource sonidoAtaque; // Sonido del ataque

    private NavMeshAgent agente;
    private int indicePatrullaActual;
    private float distanciaAlJugador;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        indicePatrullaActual = 0;
        sonidoAtaque = GetComponent<AudioSource>();
        IrAlSiguientePuntoPatrulla();
    }

    void Update()
    {
        distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);

        // Si el jugador está en rango de ataque
        if (distanciaAlJugador <= rangoAtaque)
        {
            AtacarJugador();
        }
        // Si el jugador está en rango de detección pero fuera de rango de ataque
        else if (distanciaAlJugador <= rangoDeteccion)
        {
            PerseguirJugador();
        }
        // Si el jugador está fuera del rango de regreso a patrulla
        else if (distanciaAlJugador > rangoRegresoPatrulla)
        {
            Patrullar();
        }
    }

    void Patrullar()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.5f)
        {
            IrAlSiguientePuntoPatrulla();
        }
    }

    void PerseguirJugador()
    {
        agente.SetDestination(jugador.position);
    }

    void AtacarJugador()
    {
        sonidoAtaque.PlayOneShot(sonidoAtaque.clip);
    }

    void IrAlSiguientePuntoPatrulla()
    {
        if (puntosPatrulla.Length == 0)
            return;

        agente.destination = puntosPatrulla[indicePatrullaActual].position;
        indicePatrullaActual = (indicePatrullaActual + 1) % puntosPatrulla.Length;
    }
}
