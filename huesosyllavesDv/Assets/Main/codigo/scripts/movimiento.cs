using UnityEngine;

public class movimiento : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 5f;      // Velocidad horizontal
    [SerializeField]
    private float jumpForce = 7f;      // Fuerza del salto
    [SerializeField]
    private Rigidbody2D rb2d;           // Referencia al Rigidbody2D
    [SerializeField]
    private bool isGrounded = true;   // Para saber si esta en el suelo
    [SerializeField]
    private Vector2 v2;
    [SerializeField]
    private float estaminaMax = 100f;      // Estamina máxima
    [SerializeField]
    private float estaminaActual;          // Estamina actual
    [SerializeField]
    private float consumoMovimiento = 10f; // Consumo por moverse (por segundo)
    [SerializeField]
    private float consumoSalto = 15f;      // Consumo por salto
    [SerializeField]
    private float regeneracion = 20f;      // Regeneración por segundo
    [SerializeField]
    private float velocidadReducida = 2.5f;// Velocidad cuando no hay estamina
    [SerializeField]
    private bool estaminaCero = false;
                                           


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Busca el Rigidbody2D del jugador
        estaminaActual = estaminaMax;        // Llena la estamina al inicio
    }

    void Update()
    {
        // Movimiento horizontal con derecho/izquierdo
        float moveInput = Input.GetAxis("Horizontal"); // -1 = izquierda, 1 = derecha mover la entrada 
        rb2d.linearVelocity = new Vector2(moveInput * velocidad, rb2d.linearVelocity.y);

        float velocidadActual = (estaminaActual > 0) ? velocidad : velocidadReducida;
        if (Mathf.Abs(moveInput) > 0.01f)
        {
            // Si hay movimiento, consumir estamina
            estaminaActual -= consumoMovimiento * Time.deltaTime;
        }
        else
        {
            // Si no se mueve, regenerar estamina
            estaminaActual += regeneracion * Time.deltaTime;
        }

        estaminaActual = Mathf.Clamp(estaminaActual, 0, estaminaMax);
        

        rb2d.linearVelocity = new Vector2(moveInput * velocidadActual, rb2d.linearVelocity.y);
        // Salto con espacio
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb2d.AddForce(v2*jumpForce);
            //isGrounded = false;
            estaminaActual -= consumoSalto;
            estaminaActual = Mathf.Clamp(estaminaActual, 0, estaminaMax);
            estaminaCero = true;
           
        }
        
    }

    // Detecta si toca el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            
        }
        
    }
    
}

    
