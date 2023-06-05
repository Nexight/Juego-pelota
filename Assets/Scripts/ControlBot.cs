using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private GameObject jugador;
    public int rapidez;

    void Start()
    {
        jugador = GameObject.Find("Jugador");
    }

    private void Update()
    {
        transform.LookAt(jugador.transform);
        transform.Translate(rapidez * Vector3.forward * Time.deltaTime);
    }
}
