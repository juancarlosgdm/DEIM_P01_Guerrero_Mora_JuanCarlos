using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gestor = GestionEscenas.SceneManager;

/// <summary>
/// Controlador del objeto 'Candado'
/// Si el jugador choca con él y tiene la llave en el inventario, carga la escena indicada
/// </summary>
public class LockController : MonoBehaviour
{
    [Tooltip("Nombre de la escena a cargar")]
    [SerializeField] private string sceneToLoad;

    /// <summary>
    /// Referencia al inventario del jugador
    /// </summary>
    private PlayerInventory inventory;

    /// <summary>
    /// Función que se ejecuta cuando otro elemento entra en colisión con éste
    /// </summary>
    /// <param name="collision">Información sobre la colisión</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprueba si el elemento con el que se colisiona tiene la etiqueta del jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtiene la referencia al inventario del jugador
            inventory = collision.gameObject.GetComponent<PlayerInventory>();

            // Comprueba si el jugador tiene la llave en su inventario
            if (inventory.key)
            {
                // Carga la escena indicada en el inspector
                Gestor.LoadScene(sceneToLoad);
            }
        }
    }
}