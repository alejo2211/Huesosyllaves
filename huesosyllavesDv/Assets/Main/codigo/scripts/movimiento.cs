using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad horizontal
    public float jumpForce = 7f;      // Fuerza del salto
    private Rigidbody2D rb;           // Referencia al Rigidbody2D
    private bool isGrounded = true;   // Para saber si est� en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Busca el Rigidbody2D del jugador
    }

    void Update()
    {
        // Movimiento horizontal con ?/?
        float moveInput = Input.GetAxis("Horizontal"); // -1 = izquierda, 1 = derecha
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Salto con espacio
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
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

    
