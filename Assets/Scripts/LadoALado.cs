using UnityEngine;

public class LadoALado : MonoBehaviour
{

    bool irDerecha = false;
    public int rapidez = 5;

    void Update()
    {
        if (transform.position.x <= -4f)
        {
            irDerecha = true;
        }
        if (transform.position.x >= 4)
        {
            irDerecha = false;
        }

        if (irDerecha)
        {
            Derecha();
        }
        else
        {
            Izquierda();
        }

    }

    void Derecha()
    {
        transform.position += transform.right * rapidez * Time.deltaTime;
    }

    void Izquierda()
    {
        transform.position -= transform.right * rapidez * Time.deltaTime;
    }
}