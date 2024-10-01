using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del personaje del jugador
/// Gestiona el movimiento, salto y ca�da del personaje, con sus respectivas animaciones
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("Referencia al Rigidbody2D del personaje")]
    [SerializeField] private Rigidbody2D rb;

    [Tooltip("Referencia al AnimatorController del personaje")]
    [SerializeField] private Animator animator;

    [Tooltip("Referencia al SpriteRenderer del personaje")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Tooltip("Velocidad (fuerza) de movimiento del personaje")]
    [SerializeField] private float speed;

    [Tooltip("Fuerza de salto del personaje")]
    [SerializeField] private float jumpForce;

    [Tooltip("Fuerza de ca�da del personaje")]
    [SerializeField] private float fallForce;

    /// <summary>
    /// La funci�n de Start se ejecuta �nicamente el primer frame que el objeto est� activo
    /// </summary>
    void Start()
    {
        // Muestra un mensaje por consola
        Debug.Log("se ejecuta Start");
    }

    /// <summary>
    /// La funci�n de Update se ejecuta cada uno de los frames que el objeto est� activo
    /// </summary>
    void Update()
    {
        // Comprueba si el jugador ha pulsado la tecla D
        if (Input.GetKey(KeyCode.D))
        {
            // Movimiento del personaje hacia la derecha
            rb.AddForce(Vector2.right * speed);

            // Ajusta la orientaci�n del sprite del personaje hacia la derecha
            spriteRenderer.flipX = true;
        }

        // Comprueba si el jugador ha pulsado la tecla A
        if (Input.GetKey(KeyCode.A))
        {
            // Movimiento del personaje hacia la izquierda
            rb.AddForce(Vector2.left * speed);

            // Ajusta la orientaci�n del sprite del personaje hacia la izquierda
            spriteRenderer.flipX = false;
        }

        // Comprueba si el jugador ha pulsado la tecla espacio
        if (Input.GetKey(KeyCode.Space))
        {
            // Salto del personaje
            rb.AddForce(Vector2.up * jumpForce);
        }

        // Gesti�n de las animaciones de andar del personaje (cualquiera de las dos opciones es v�lida)
        animator.SetBool("walking", rb.velocity.x != 0); // Notifica al AnimatorController si el personaje est� o no en movimiento en el eje X
        animator.SetFloat("velocity", rb.velocity.x); // Notifica al AnimatorController la velocidad de movimiento del personaje en el eje X

        // Comprueba si el personaje est� cayendo (sentido negativo en eje Y)
        if (rb.velocity.y < 0)
        {
            // Aplica una fuerza extra a la ca�da
            rb.AddForce(Vector2.down * fallForce);
        }
    }
}
