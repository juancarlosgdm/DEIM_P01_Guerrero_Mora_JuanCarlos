using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] levelPieces;

    [SerializeField] private int pieceHeight;

    [SerializeField] private int levelHeight;

    [SerializeField] private List<GameObject> piecesToUse;

    // Start is called before the first frame update
    void Start()
    {
        piecesToUse = new List<GameObject>();
        int piecesPerType = Mathf.CeilToInt(((float) levelHeight / pieceHeight) / (float) levelPieces.Length);
        
        for (int lp = 0; lp<levelPieces.Length; lp++)
        {
            for (int p = 0; p < piecesPerType; p++)
            {
                piecesToUse.Add(levelPieces[lp]);
            }
        }



        //for (int p = 0; p < levelHeight / pieceHeight; p++)
        //{
        //    Instantiate(levelPiece, new Vector3(0, -p * pieceHeight, 0), Quaternion.identity, transform);
        //}

        for (int p = 0; p < levelHeight; p += pieceHeight)
        {


            int pieceIndex = Random.Range(0, piecesToUse.Count);

            Instantiate(piecesToUse[pieceIndex], new Vector3(0, -p, 0), Quaternion.identity, transform);

            piecesToUse.RemoveAt(pieceIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
