using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public GameObject projetil;
    public int life = 10;
    public int maxProjetil;
    public int projetils;
    public bool podeRecarregar = true;

    private Rigidbody2D naveRb;
    public float velociadeMove;

    // Start is called before the first frame update
    void Start()
    {
        naveRb = GetComponent<Rigidbody2D>();
        projetils = maxProjetil;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimentação
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        naveRb.velocity = new Vector2(
            horizontal * velociadeMove,
            vertical * velociadeMove
        );
        // Disparos
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if ( projetils > 0)
            {
                Instantiate(
                              projetil,
                              transform.position + new Vector3(0, -0.1f, 0),
                              transform.rotation
                            );
                projetils -= 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.tag == "dano_inimigo")
        {
            life--;

            if (life <= 0) {
                Destroy(gameObject);
            }
        }
        else if (coli.gameObject.tag == "missil")
        {
            life -= 2;

            if (life <= 0) {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "vida")
        {
            life += 5;
        }

        if (col.gameObject.tag == "balas")
        {
            projetils += 10;
        }
    }
}
