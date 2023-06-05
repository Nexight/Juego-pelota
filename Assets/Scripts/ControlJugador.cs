using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody rb;
    private int cont;
    private int saltoActual = 0;
    private Scene scene;
    public int Vida = 100;
    public int saltosMax = 2;
    public float rapidezDesplazamiento = 10.0f;
    public float magnitudSalto;
    public Text textoCantidadRecolectados;
    public Text textoGanaste;
    public Text txtVida;
    public LayerMask capaPiso;
    public SphereCollider col;
    public ControlMirarCamara controlMirarCamara;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        scene = SceneManager.GetActiveScene();
        rb = GetComponent<Rigidbody>();
        cont = 0;       // texto
        textoGanaste.text = "";  // texto
        setearTextos();     //  texto
        col = GetComponent<SphereCollider>();


    }

    public void RecibirDaño ()
    {
        Vida = Vida - 25;
        setearTextos();
    }

    private void setearTextos()
    {
        textoCantidadRecolectados.text = cont.ToString();
        txtVida.text = Vida.ToString();
        if (cont >= 5)
        {
            textoGanaste.text = "Ganaste!";
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable") == true)
        {
            cont = cont + 1;
            setearTextos();
            other.gameObject.SetActive(false);
            if (cont>=5)
            {
                Time.timeScale = 0;
                controlMirarCamara.enabled = false;
            }
        }
        if(other.gameObject.CompareTag("Boost")== true)
        {
            Vector3 local = transform.localScale;
            transform.localScale = new Vector3(3, 3, 3);
            rapidezDesplazamiento+=10;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("EnemigoLetal") == true)
        {
            Vida -= 100;
        }
        if(other.gameObject.CompareTag("GhostR")==true)
        {
            RecibirDaño();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (EstaEnPiso() || saltosMax > saltoActual))
        {
            rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);
            saltoActual++;

        }
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (transform.position.y <= -20)
        {
            SceneManager.LoadScene(scene.name);
        }

        if (Vida<=0)
        {
            Time.timeScale = 0;
            textoGanaste.text = "Game Over";
            controlMirarCamara.enabled = false;

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        saltoActual = 0;
    }

    private bool EstaEnPiso()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
        col.bounds.min.y, col.bounds.center.z), col.radius * .9f, capaPiso);
    }

}