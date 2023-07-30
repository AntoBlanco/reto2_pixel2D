using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargarEscena : MonoBehaviour
{
    public GameObject mensajeCarga;
    public Slider progreso;
    public TextMeshProUGUI procentaje;

    public void Cargar()
    {
        StartCoroutine(CargarAsynchronously(PlayerPrefs.GetString("Escena")));
    }

    public void Cargar(string valor)
    {
        StartCoroutine(CargarAsynchronously(valor));
    }

    IEnumerator CargarAsynchronously(string valor)
    {
        mensajeCarga.SetActive(true);
        AsyncOperation operacion = SceneManager.LoadSceneAsync(valor);

        while (!operacion.isDone)
        {
            float porcentaje = Mathf.Clamp01(operacion.progress / 0.9f);
            progreso.value = porcentaje;
            procentaje.text = Mathf.FloorToInt(porcentaje * 100) + "%";
            yield return null;
        }
    }
    public void CambiarEstado(string valor)
    {
        PlayerPrefs.SetString("Estado", valor);
    }
}
