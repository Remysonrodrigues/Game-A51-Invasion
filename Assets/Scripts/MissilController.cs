using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilController : MonoBehaviour
{
    public GameObject projetil;
    public int life = 10;
    bool naveEmCima = false;

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

        if(nave != null && naveEmCima)
        {
            GameObject disparo = (GameObject) Instantiate(projetil);

            disparo.transform.position = transform.position;
            disparo.transform.Translate(0, 1, 0);
            Vector3 direction = nave.transform.position - disparo.transform.position;
            disparo.GetComponent<projetilInimigoController>().SetDirection(direction);

            yield return new WaitForSeconds(1);

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
}
