using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmigoController : MonoBehaviour
{
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.Play("AmigoResgatando");
        }
    }
}
