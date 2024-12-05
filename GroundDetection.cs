using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundDetection : MonoBehaviour
{
    public PlayerMovement playerMovement;  // Referencia al script de movimiento
    public string groundTag = "Ground";    // Tag del suelo

    void OnCollisionEnter(Collision collision)
    {
        // Si el personaje colisiona con algo etiquetado como "Ground", se activa groundCheck
        if (collision.gameObject.CompareTag(groundTag))
        {
            playerMovement.groundCheck = true;  // Activar el estado de estar en el suelo
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Si el personaje deja de tocar el suelo, se desactiva groundCheck
        if (collision.gameObject.CompareTag(groundTag))
        {
            playerMovement.groundCheck = false;  // Desactivar el estado de estar en el suelo
        }
    }
}
