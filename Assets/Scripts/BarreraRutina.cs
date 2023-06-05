using UnityEngine;

public class BarreraRutina : MonoBehaviour
{

    bool tengoQueBajar = false;
    bool tengoQueAvanzar = false;
    bool tengoQueSubir = false;
    bool tengoQueRetroceder = false;
    public int rapidez = 5;

    void Update()
    {
        if ((transform.position.y >= 12) && (transform.position.z <= 0 ))
        {
            tengoQueBajar = true;
            tengoQueAvanzar = false;
            tengoQueSubir = false;
            tengoQueRetroceder = false;
        }
        if ((transform.position.y <= 6) && (transform.position.z <= 0 ))
        {
            tengoQueBajar = false;
            tengoQueAvanzar = true;
            tengoQueSubir = false;
            tengoQueRetroceder = false;
        }

        if ((transform.position.y <= 6) && (transform.position.z >= 12))
        {
            tengoQueBajar = false;
            tengoQueAvanzar = false;
            tengoQueSubir = true;
            tengoQueRetroceder = false;
        }

        if ((transform.position.y >= 12) && (transform.position.z >= 12))
        {
            tengoQueBajar = false;
            tengoQueAvanzar = false;
            tengoQueSubir = false;
            tengoQueRetroceder = true;
        }

        if (tengoQueBajar)
        {
            Bajar();
        }
        if(tengoQueSubir)
        {
            Subir();
        }

        if(tengoQueAvanzar)
        {
            Avanzar();
        }
        if(tengoQueRetroceder)
        {
            Retroceder();
        }
    }

    void Subir()
    {
        transform.position += transform.up * rapidez * Time.deltaTime;
    }

    void Bajar()
    {
        transform.position -= transform.up * rapidez * Time.deltaTime;
    }

    void Avanzar()
    {
        transform.position += transform.forward * rapidez * Time.deltaTime;
    }

    void Retroceder()
    {
        transform.position -= transform.forward * rapidez * Time.deltaTime;
    }
}