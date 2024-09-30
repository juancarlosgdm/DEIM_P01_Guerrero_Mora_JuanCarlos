using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del personaje del jugador
/// Gestiona el movimiento y el salto del personaje
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("Referencia al Rigidbody2D del personaje")]
    [SerializeField] private Rigidbody2D rb;

    [Tooltip("Velocidad (fuerza) de movimiento del personaje")]
    [SerializeField] private float speed;

    [Tooltip("Fuerza de salto del personaje")]
    [SerializeField] private float jumpForce;

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
        }

        // Comprueba si el jugador ha pulsado la tecla A
        if (Input.GetKey(KeyCode.A))
        {
            // Movimiento del personaje hacia la izquierda
            rb.AddForce(Vector2.left * speed);
        }

        // Comprueba si el jugador ha pulsado la tecla espacio
        if (Input.GetKey(KeyCode.Space))
        {
            // Salto del personaje
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
