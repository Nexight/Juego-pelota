using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlJuego : MonoBehaviour
{
    public GameObject jugador;
    public GameObject bot;
    private Scene scene;
    float tiempoRestante=60;
    public ControlMirarCamara controlMirarCamara;
    public Text textoGanaste;

    void Start()
    {
        Time.timeScale = 1;
        scene = SceneManager.GetActiveScene();
        ComenzarJuego();
        print("Empieza el Juego");
    }

    void Update()
    {
        if (tiempoRestante == 0)
        {
            Time.timeScale = 0;
            controlMirarCamara.enabled = false;
            textoGanaste.text = "Game Over ( time out )";

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    void ComenzarJuego()
    {
        jugador.transform.position = new Vector3(0f, 0f, 0f);

        StartCoroutine(ComenzarCronometro(60));
    }

    public IEnumerator ComenzarCronometro(float valorCronometro = 60)
    {
        tiempoRestante = valorCronometro;
        while (tiempoRestante > 0)
        {
            Debug.Log( tiempoRestante + " segundos.");
            yield return new WaitForSeconds(1.0f);
            tiempoRestante--;
        }
    }
  
}