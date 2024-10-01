using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gesti�n del inventario del jugador
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    [Tooltip("Referencia al icono de \"Llave\" en la interfaz")]
    [SerializeField] private GameObject keyIcon;

    [Tooltip("Objeto \"Llave\" del inventario")]
    public bool key;

    /// <summary>
    /// La funci�n de Update se ejecuta cada uno de los frames que el objeto est� activo
    /// </summary>
    private void Update()
    {
        // Visibilidad del icono de la llave seg�n el jugador la tenga o no (opci�n 1)
        keyIcon.SetActive(key);

        // Visibilidad del icono de la llave seg�n el jugador la tenga o no (opci�n 2)
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
