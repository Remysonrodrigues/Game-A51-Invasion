using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoController : MonoBehaviour
{
    public GameObject projetil;
    //public GameObject nave;
    public int life = 5; 

    private Rigidbody2D inimigoRb;
    public float velociadeMove;
    
    // Start is called before the first frame update
    void Start()
    {
        inimigoRb = GetComponent<Rigidbody2D>();
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        // Movimentação
        /*
        float naveX = nave.transform.position.x;
        float inimigoX = nave.transform.position.x;
        float horizontal = Input.GetAxis("Horizontal");
        if (naveX < inimigoX) {
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
            // transform.rotation += new Vector2(0, 180.0f);
            //inimigoRb.transform.rotation.y = 180.0f;
            // inimigoRb.transform.rotation = new Vector2(0, 180.0f);
            inimigoRb.velocity = new Vector2(horizontal * velociadeMove, 0);
        }
        else
        {
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
            // transform.rotation +=  new Vector2(0, 0);
            // inimigoRb.transform.rotation = new Vector2(0, 0);
            //inimigoRb.transform.rotation.y = 0.0f;
            inimigoRb.velocity = new Vector2(horizontal * velociadeMove, 0);
        }
        */
    }

    IEnumerator Disparar()
    {
        GameObject nave = GameObject.Find("Nave");

        if(nave != null)
        {
            GameObject disparo = (GameObject) Instantiate(projetil);

            disparo.transform.position = transform.position;

            Vector3 direction = nave.transform.position - disparo.transform.position;

            disparo.GetComponent<projetilInimigoController>().SetDirection(direction);

            yield return new WaitForSeconds(1);
            
            StartCoroutine(Disparar());
        }
    }
}
