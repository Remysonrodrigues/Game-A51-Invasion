using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseController : MonoBehaviour
{
    public GameObject alien;
    public HealthBarController healthBar;
    public int life = 10;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.tag == "projetil")
        {
            life--;
            healthBar.hit(-1);

            if (life <= 0) {
                animator.Play("baseExplosion");
                GameObject amigo = (GameObject) Instantiate(alien);
                amigo.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                Destroy(gameObject, 0.45f);
            }
        }
    }
}
