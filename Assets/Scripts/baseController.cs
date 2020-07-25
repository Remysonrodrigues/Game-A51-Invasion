using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseController : MonoBehaviour
{
    public GameObject alien;
    public int life = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        life--;

        if (life <= 0) {
            GameObject amigo = (GameObject) Instantiate(alien);
            amigo.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            Destroy(gameObject);
        }
    }
}
