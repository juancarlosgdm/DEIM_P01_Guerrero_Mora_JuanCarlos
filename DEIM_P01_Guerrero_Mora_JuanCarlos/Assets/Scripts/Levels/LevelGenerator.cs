using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generador de niveles
/// </summary>
public class LevelGenerator : MonoBehaviour
{
    [Tooltip("Referencia a las piezas base a utilizar en la generación")]
    [SerializeField] private GameObject[] levelPieces;

    [Tooltip("Referencia a las piezas base a utilizar en el inicio")]
    [SerializeField] private GameObject[] startPieces;

    [Tooltip("Referencia a las piezas base a utilizar en el final")]
    [SerializeField] private GameObject[] endPieces;

    [Tooltip("Altura de cada una de las piezas")]
    [SerializeField] private int pieceHeight;

    [Tooltip("Altura total del nivel")]
    [SerializeField] private int levelHeight;

    /// <summary>
    /// Listado de piezas a utilizar en la generación
    /// </summary>
    private List<GameObject> piecesToUse;

    // Start is called before the first frame update
    void Start()
    {
        // Preparación de las piezas a utilizar 
        PrepPiecesToUse();        

        // Generación del nivel
        GenerateLevelByHeight();
    }

    /// <summary>
    /// Genera el nivel según la altura indicada para el nivel
    /// </summary>
    private void GenerateLevelByHeight()
    {
        Instantiate(startPieces[Random.Range(0, startPieces.Length)], Vector3.zero, Quaternion.identity, transform);

        // En cada una de las iteraciones, se añade la altura de la pieza hasta llegar a la altura total deseada
        for (int p = pieceHeight; p < levelHeight; p += pieceHeight)
        {
            // Elige aleatoriamente una de las piezas a utilizar
            int pieceIndex = Random.Range(0, piecesToUse.Count);

            // Instancia una copia de la pieza elegida, colocándola en una posición acorde a las ya instanciadas
            Instantiate(piecesToUse[pieceIndex], new Vector3(0, -p, 0), Quaternion.identity, transform);

            // Elimina la pieza utilizada de la bolsa, para que no vuelva a utilizarse
            piecesToUse.RemoveAt(pieceIndex);
        }

        Instantiate(endPieces[Random.Range(0, endPieces.Length)], new Vector3(0, -levelHeight, 0), Quaternion.identity, transform);
    }

    /// <summary>
    /// Prepara el listado o "bolsa" de piezas de donde escoger durante la generación
    /// </summary>
    private void PrepPiecesToUse()
    {
        // Creación de la lista donde almacenar cada una de las referencias a las piezas
        piecesToUse = new List<GameObject>();

        // Calcula el número de piezas que deben existir de cada tipo
        // Necesario porque en el proyecto hay menos piezas base de las que necesita un nivel
        // Al utilizar el casting (float), el resultado de la división entre dos números enteros sea decimal y no entero
        int piecesPerType = Mathf.CeilToInt(((float)levelHeight / pieceHeight) / (float)levelPieces.Length);

        // Iteramos por cada uno de los tipos de piezas existentes
        for (int lp = 0; lp < levelPieces.Length; lp++)
        {
            // Añadimos a la "bolsa" tantas referencias del tipo de pieza concreto como se haya calculado previamente
            for (int p = 0; p < piecesPerType; p++)
            {
                piecesToUse.Add(levelPieces[lp]);
            }
        }
    }
}