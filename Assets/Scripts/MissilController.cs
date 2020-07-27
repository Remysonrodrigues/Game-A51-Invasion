using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilController : MonoBehaviour
{
    public GameObject projetil;
    public GameObject ammo;
    public GameObject smoke;
    public HealthBarController healthBar;
    public int life = 7;

    bool naveEmCima = false;
    bool disparando = false;
    bool stop = false;
    private Animator animator;
    private CapsuleCollider2D missilCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        missilCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Disparar() {
        GameObject nave = GameObject.Find("Nave");

        if(nave != null && naveEmCima)
        {
            if (!disparando)
            {
                GameObject disparo = (GameObject) Instantiate(projetil);

                GameObject smokeObject = (GameObject) Instantiate(smoke);
                smokeObject.transform.position = transform.position;
                var smokeEffect = smokeObject.GetComponent<Animator>();
                smokeEffect.Play("smokeRunning");
                Destroy(smokeObject, 0.2f);

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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Nave" && !stop) {
            naveEmCima = true;
            StartCoroutine(Disparar());
        }
    }

    IEnumerator OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Nave" && !stop) {
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
            healthBar.hit(-1);

            if (life == 0) {
                stop = true;
                Destroy(missilCollider);
                healthBar.transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(4, 4, 4);
                animator.Play("torreExplosion");

                GameObject balas = (GameObject) Instantiate(ammo);
                balas.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                Destroy(gameObject, 1);
            }
        }
    }
}
