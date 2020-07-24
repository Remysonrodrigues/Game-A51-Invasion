using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilController : MonoBehaviour
{
    public GameObject projetil;
    public GameObject ammo;
    public int life = 7;

    bool naveEmCima = false;
    bool disparando = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Disparar() {
        GameObject nave = GameObject.Find("Nave");

        if(nave != null && naveEmCima && !disparando)
        {
            GameObject disparo = (GameObject) Instantiate(projetil);
            disparando = true;

            disparo.transform.position = transform.position;
            disparo.transform.Translate(0, 1, 0);
            Vector3 direction = nave.transform.position - disparo.transform.position;
            disparo.GetComponent<projetilInimigoController>().SetDirection(direction);

            yield return new WaitForSeconds(1);

            disparando = false;
            StartCoroutine(Disparar());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Nave") {
            naveEmCima = true;
            StartCoroutine(Disparar());
        }
    }

    IEnumerator OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Nave") {
            Disparar();
            yield return new WaitForSeconds(1);
            naveEmCima = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.tag == "projetil")
        {
            life--;

            if (life == 0) {
                GameObject balas = (GameObject) Instantiate(ammo);
                balas.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                Destroy(gameObject);
            }
        }
    }
}
