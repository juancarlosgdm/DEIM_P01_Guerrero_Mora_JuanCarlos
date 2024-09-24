using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("se ejecuta Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector2.right * speed);
        }


    }
}
