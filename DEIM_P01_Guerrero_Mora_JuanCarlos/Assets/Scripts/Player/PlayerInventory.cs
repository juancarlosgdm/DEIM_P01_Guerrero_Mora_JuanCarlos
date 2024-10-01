using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestión del inventario del jugador
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    [Tooltip("Referencia al icono de \"Llave\" en la interfaz")]
    [SerializeField] private GameObject keyIcon;

    [Tooltip("Objeto \"Llave\" del inventario")]
    public bool key;

    /// <summary>
    /// La función de Update se ejecuta cada uno de los frames que el objeto está activo
    /// </summary>
    private void Update()
    {
        // Visibilidad del icono de la llave según el jugador la tenga o no (opción 1)
        keyIcon.SetActive(key);

        // Visibilidad del icono de la llave según el jugador la tenga o no (opción 2)
        if (key)
        {
            keyIcon.SetActive(true);
        }
        else
        {
            keyIcon.SetActive(false);
        }
    }
}
