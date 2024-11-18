using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Configuration Data")]
public class PlayerConfigData : ScriptableObject
{
    [Tooltip("Velocidad de movimiento del personaje")]
    [Range(0, 999)]
    [SerializeField] private float movementSpeed;

    public RuntimeAnimatorController animatorController;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            if (value > 0)
            {
                movementSpeed = value;
            }
            else
            {
                Debug.LogError("La velocidad de movimiento no puede ser negativa");
            }
        }
    }

}
