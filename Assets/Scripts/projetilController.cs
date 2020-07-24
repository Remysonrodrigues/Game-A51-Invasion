﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HoraDeDestruir());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.1f, 0);
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.tag == "dano_inimigo") {
            GameObject bullet = GameObject.FindWithTag("dano_inimigo");
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (coli.gameObject.tag != "Player" &&
            coli.gameObject.tag != "dano_inimigo" &&
            coli.gameObject.tag != "missil") {
            Destroy(gameObject);
        }
    }

    IEnumerator HoraDeDestruir()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
