using System.Collections;
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
        //explosionAnimator.SetBool("ProjetilExplosion", true);
        //if (coli.gameObject.tag != "Player")
        //Instantiate(explosion, coli.transform.position, coli.transform.rotation);
        // Destroy(coli.gameObject);
        if (coli.gameObject.tag != "Player") {
            Destroy(gameObject);
        }
    }

    IEnumerator HoraDeDestruir()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
