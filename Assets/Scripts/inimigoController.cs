using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoController : MonoBehaviour
{
    public GameObject projetil;
    public GameObject ammo;
    public GameObject lifeObject;
    public HealthBarController healthBar;
    public int life = 5;

    Animator animator;
    bool naveEmCima = false;
    bool atirando = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Disparar()
    {
        if (naveEmCima && !atirando) {
            float count = 0f;
            atirando = true;

            for (int i = 0; i < 5; i++) {
                GameObject disparo = (GameObject) Instantiate(projetil);

                disparo.transform.position = transform.position;
                disparo.transform.Translate(-1 + count, 1, 0);
                disparo.GetComponent<projetilInimigoController>().SetDirection(Vector3.up);
                count += 0.25f;
                yield return new WaitForSeconds(0.2f);
            }

            atirando = false;

            StartCoroutine(Disparar());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Nave") {
            animator.Play("Atacando");
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
            animator.Play("parado");
        }
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.tag == "projetil") {
            life--;
            healthBar.hit(-1);

            if (life == 0) {
                GameObject balas = (GameObject) Instantiate(ammo);
                GameObject vida = (GameObject) Instantiate(lifeObject);

                vida.transform.position = new Vector3(transform.position.x - 1, transform.position.y, -1);
                balas.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

                Destroy(gameObject);
            }
        }
    }
}
