using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del personaje del jugador
/// Gestiona el movimiento, salto y caída del personaje, con sus respectivas animaciones
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("Referencia a los datos de configuración del personaje")]
    [SerializeField] private PlayerConfigData playerConfigData;

    [Tooltip("Referencia al Rigidbody2D del personaje")]
    [SerializeField] private Rigidbody2D rb;

    [Tooltip("Referencia al AnimatorController del personaje")]
    [SerializeField] private Animator animator;

    [Tooltip("Referencia al SpriteRenderer del personaje")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Tooltip("Fuerza de salto del personaje")]
    [SerializeField] private float jumpForce;

    [Tooltip("Tiempo máximo que el jugador puede mantener pulsado la tecla de salto")]
    [SerializeField] private float maxJumpTime;

    [Tooltip("Fuerza de caída del personaje")]
    [SerializeField] private float fallForce;

    /// <summary>
    /// Tiempo que el personaje lleva saltando
    /// </summary>
    private float jumpTime;

    private bool jumping;

    private float airTime;

    public float coyoteTime;

    public LayerMask jumpLayerMask;

    public float groundCheck;

    public ParticleSystem ps;

    /// <summary>
    /// La función de Start se ejecuta únicamente el primer frame que el objeto esté activo
    /// </summary>
    void Start()
    {
        // Muestra un mensaje por consola
        Debug.Log("se ejecuta Start");

        playerConfigData.MovementSpeed = 6;

        animator.runtimeAnimatorController = playerConfigData.animatorController;
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
            rb.AddForce(Vector2.right * playerConfigData.MovementSpeed);

            // Ajusta la orientación del sprite del personaje hacia la derecha
            spriteRenderer.flipX = true;
        }

        // Comprueba si el jugador ha pulsado la tecla A
        if (Input.GetKey(KeyCode.A))
        {
            // Movimiento del personaje hacia la izquierda
            rb.AddForce(Vector2.left * playerConfigData.MovementSpeed);

            // Ajusta la orientación del sprite del personaje hacia la izquierda
            spriteRenderer.flipX = false;
        }

        // Comprueba si el jugador ha pulsado la tecla espacio
        if ((Input.GetKeyDown(KeyCode.Space)) && CanJump())
        {
            // El personaje inicia el salto
            jumping = true;
            jumpTime = 0;
            Debug.Log("inicio de salto");
        }

        if ((Input.GetKeyUp(KeyCode.Space)) || (jumpTime >= maxJumpTime))
        {
            // El personaje finaliza el salto
            jumping = false;
            Debug.Log("fin de salto");
        }

        if (jumping)
        {
            //rb.AddForce(Vector2.up * jumpForce);
            rb.velocity = Vector2.up * jumpForce;
            jumpTime += Time.deltaTime;
            airTime = coyoteTime;
        }

        if (!IsGrounded())
        {
            airTime += Time.deltaTime;
        }
        else
        {
            airTime = 0;
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

    public void PlayFootStep()
    {
        // Efecto de sonido para los pasos del personaje
        if (IsGrounded())
        {
            AudioManager.PlayFootstepSound();
        }
    }

    private bool CanJump()
    {
        bool res = (!jumping && (IsGrounded() || (airTime < coyoteTime)));

        return res;
    }

    private bool IsGrounded()
    {
        bool res = Physics2D.Raycast(transform.position, Vector2.down, groundCheck, jumpLayerMask);

        return res;
    }
}
