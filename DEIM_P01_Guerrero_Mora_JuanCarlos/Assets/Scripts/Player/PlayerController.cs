using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del personaje del jugador
/// Gestiona el movimiento, salto y caída del personaje, con sus respectivas animaciones
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

    [Tooltip("Fuerza de caída del personaje")]
    [SerializeField] private float fallForce;

    /// <summary>
    /// La función de Start se ejecuta únicamente el primer frame que el objeto esté activo
    /// </summary>
    void Start()
    {
        // Muestra un mensaje por consola
        Debug.Log("se ejecuta Start");
    }

    /// <summary>
    /// La función de Update se ejecuta cada uno de los frames que el objeto está activo
    /// </summary>
    void Update()
    {
        // Comprueba si el jugador ha pulsado la tecla D
        if (Input.GetKey(KeyCode.D))
        {
            // Movimiento del personaje hacia la derecha
            rb.AddForce(Vector2.right * speed);

            // Ajusta la orientación del sprite del personaje hacia la derecha
            spriteRenderer.flipX = true;
        }

        // Comprueba si el jugador ha pulsado la tecla A
        if (Input.GetKey(KeyCode.A))
        {
            // Movimiento del personaje hacia la izquierda
            rb.AddForce(Vector2.left * speed);

            // Ajusta la orientación del sprite del personaje hacia la izquierda
            spriteRenderer.flipX = false;
        }

        // Comprueba si el jugador ha pulsado la tecla espacio
        if (Input.GetKey(KeyCode.Space))
        {
            // Salto del personaje
            rb.AddForce(Vector2.up * jumpForce);
        }

        // Gestión de las animaciones de andar del personaje (cualquiera de las dos opciones es válida)
        animator.SetBool("walking", rb.velocity.x != 0); // Notifica al AnimatorController si el personaje está o no en movimiento en el eje X
        animator.SetFloat("velocity", rb.velocity.x); // Notifica al AnimatorController la velocidad de movimiento del personaje en el eje X

        // Comprueba si el personaje está cayendo (sentido negativo en eje Y)
        if (rb.velocity.y < 0)
        {
            // Aplica una fuerza extra a la caída
            rb.AddForce(Vector2.down * fallForce);
        }
    }
}
