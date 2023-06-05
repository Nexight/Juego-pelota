using UnityEngine;

public class SubeYBaja : MonoBehaviour
{

    bool tengoQueBajar = false;
    public int rapidez = 5;

    void Update()
    {
        if (transform.position.y >= 3.8f)
        {
            tengoQueBajar = true;
        }
        if (transform.position.y <= 1)
        {
            tengoQueBajar = false;
        }

        if (tengoQueBajar)
        {
            Bajar(); 
        }
        else
        {
           Subir();
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
}