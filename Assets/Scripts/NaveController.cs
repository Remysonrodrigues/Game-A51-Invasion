﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public GameObject projetil;
    public int maxLife = 15;
    public int life;
    public int maxProjetil;
    public int projetils;
    public float velociadeMove;
    public HealthBarController healthBar;

    private Rigidbody2D naveRb;
    Animator animator;
    PolygonCollider2D naveCollider;
    bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        naveRb = GetComponent<Rigidbody2D>();
        naveCollider = GetComponent<PolygonCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        projetils = maxProjetil;
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
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
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.tag == "dano_inimigo")
        {
            life--;
            healthBar.hit(-1);
        }
        else if (coli.gameObject.tag == "missil")
        {
            life -= 2;
            healthBar.hit(-2);
        }

        if (life <= 0) {
            stop = true;
            Destroy(naveCollider);
            healthBar.transform.localScale = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(6, 6, 6);
            animator.Play("NaveExplosion");
            Destroy(gameObject, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "vida")
        {
            life += 5;
            life = (life > maxLife) ? maxLife : life;
            healthBar.hit(5);
        }
        else if (col.gameObject.tag == "balas")
        {
            projetils += 10;
        }
        else if (col.gameObject.tag == "amigo")
        {
            GameObject amigo = GameObject.FindWithTag("amigo");

            if (amigo != null)
            {
                stop = true;
                naveRb.velocity = new Vector2(0, 0);
                transform.position = new Vector3(
                    amigo.transform.position.x,
                    2.5f,
                    transform.position.z);

                animator.Play("NaveResgatando");
            }
        }
    }
}
