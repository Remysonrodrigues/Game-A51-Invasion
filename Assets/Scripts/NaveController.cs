using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public GameObject projetil;
    public int life = 5;
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
                Instantiate(projetil, transform.position, transform.rotation);
                projetils -= 1;
            }            
        }
        // Recarga
        if(projetils < maxProjetil && podeRecarregar == true)
        {
            podeRecarregar = false;
            StartCoroutine(Recarregar());
        }
    }

    IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(0.5f);
        projetils += 1; 
        podeRecarregar = true;
    }

}
