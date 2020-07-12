using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    private Rigidbody2D naveRb;
    public float velociadeMove;
    
    // Start is called before the first frame update
    void Start()
    {
        naveRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        naveRb.velocity = new Vector2(
            horizontal * velociadeMove,
            vertical * velociadeMove
        );
    }
}
