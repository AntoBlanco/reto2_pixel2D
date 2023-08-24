using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SistemaRecoleccion : MonoBehaviour
{
    public int cantidadBombillos;
    public int bombillosRecolectados = 0;

    public UnityEvent recoleccionCompleta;

    void Start()
    {
        cantidadBombillos = GameObject.FindGameObjectsWithTag("Bombillo").Length;
    }

    public void EvaluarRecoleccion()
    {
        bombillosRecolectados++;
        if (bombillosRecolectados == cantidadBombillos)
            recoleccionCompleta.Invoke();
    }
}
