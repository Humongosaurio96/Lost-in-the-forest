 using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    //Variables publicas de control del jugador
    public int velocidad;           
    public int fuerzaSalto;         
    public int fuerzaSaltoPared;
    public int empujeLateral;


    //Variables para cargar los componentes necesarios
    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private Animator animacion;

    //Start se ejecuta al inicio del juego.
    void Start()
    {
        //Cargamos los componentes para trabajar con ellos
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();

    }

    // Método que se ejecuta cada frame pero de tiempo fijo
    void FixedUpdate()
    {
        //Asociamos el movimiento del objeto con el Input de unity para el eje horizontal
        float entradaX = Input.GetAxis("Horizontal");

        //definimos el movimiento aplicando la velocidad en el eje X
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);
    }

    //Método que se ejecuta cada frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tocarSuelo())
            {
                // Salto normal
                animacion.Play("jump");
                fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
            else if (tocarParedIzquierda())
            {
                // Salto en pared hacia la derecha
                fisica.linearVelocity = new Vector2(0, 0); // resetear velocidad
                fisica.AddForce(new Vector2(empujeLateral, fuerzaSaltoPared), ForceMode2D.Impulse);
            }
            else if (tocarParedDerecha())
            {
                // Salto en pared hacia la izquierda
                fisica.linearVelocity = new Vector2(0, 0);
                fisica.AddForce(new Vector2(-empujeLateral, fuerzaSaltoPared), ForceMode2D.Impulse);
            }
        }


        //Si va a la dcha. dejamo flipX = false(no lo gira)
        if (fisica.linearVelocity.x < 0) sprite.flipX = false;
        //SI va hacia la izquierda, flipX = true (lo gira)
        else if (fisica.linearVelocity.x > 0) sprite.flipX = true;

        animarJugador();
    }

    private void animarJugador()
    {

        //Jugador Corriendo
        if (fisica.linearVelocity.x > 1 || fisica.linearVelocity.x < -1)
            animacion.Play("run");

        //Jugador Parado
        else if (fisica.linearVelocity.x < 1 && fisica.linearVelocity.x > -1)
            animacion.Play("PlayerIdle");
            
    }

    //Método para detectar si el objeto está tocando suelo
    private bool tocarSuelo()
    {
        //detecta la colisión entre la posición del objeto con un offset de -2 en dirección vertical hacia abajo
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.1f);
        return toca.collider != null;       //Si colisiona retorna TRUE
    }

    private bool tocarParedIzquierda()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position, Vector2.left, 0.1f);
        return toca.collider != null;
    }

    private bool tocarParedDerecha()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position, Vector2.right, 0.1f);
        return toca.collider != null;
    }


    public void FinJuego()
    {
        //Carga la escena  actual obteniendo su índice (Id de la escena)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

