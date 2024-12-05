using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public float jumpForce = 5f;  // Fuerza del salto
    public bool groundCheck;      // Casilla que indica si el personaje está tocando el suelo (booleano)

    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró el Rigidbody en el objeto!");
            return;
        }
        rb.freezeRotation = true;  // Para evitar que el jugador se voltee
    }

    void Update()
    {
        // Movimiento del jugador usando las teclas W, A, S, D o las flechas
        float moveX = Input.GetAxis("Horizontal");  // A/D, Flechas (izquierda/derecha)
        float moveZ = Input.GetAxis("Vertical");    // W/S, Flechas (arriba/abajo)

        // Movimiento en 3D basado en la orientación del jugador
        Vector3 move = new Vector3(moveX, 0f, moveZ);  // Movimiento solo en los ejes X y Z
        rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed); // Aplicar velocidad

        // Comprobar si el jugador está presionando la barra espaciadora para saltar
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck)  // Si el personaje está tocando el suelo
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Aplicar fuerza de salto en el eje Y
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
