using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    float tiempoActual = 0f;
    float tiempoInicial = 60f;
    [SerializeField] Text tiempo;
    void Start()
    {
        tiempoActual = tiempoInicial;
    }
    void Update()
    {
        tiempoActual -= 1 * Time.deltaTime;
        tiempo.text = tiempoActual.ToString("0");

        if (tiempoActual <= 0)
        {
            tiempoActual = 0;
        }
    }
}

