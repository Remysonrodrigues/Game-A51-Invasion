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

    private void OnCollisionEnter(Collision coli)
    {
        if (coli.gameObject.tag != "Player")
        {
            Destroy(coli.gameObject);
            Destroy(gameObject);                    
        }
    }

    IEnumerator HoraDeDestruir()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
