using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilInimigoController : MonoBehaviour
{
    public float speed;
    public bool isReady;

    private Vector3 _direction;
    Animator animator;

    void Awake()
    {
        speed = 5f;
        isReady =  false;
    }

     // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(HoraDeDestruir());
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
        isReady = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            Vector3 position = transform.position;

            position += (_direction * speed * Time.deltaTime);

            transform.position = position;

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Nave") {
            animator.Play("ProjetilExplosion");
            isReady = false;
            Destroy(gameObject, 0.2f);
        }
    }

    IEnumerator HoraDeDestruir()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
