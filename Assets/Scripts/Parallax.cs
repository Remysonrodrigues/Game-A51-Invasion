using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public FreeParallax parallax;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        if (parallax != null)
        {
            if (movimentoHorizontal < 0) // Indo para Esquerda
            {
                parallax.Speed = 10.0f;
            }
            else if (movimentoHorizontal > 0) // Indo para Direita
            {
                parallax.Speed = -10.0f;
            }
            else
            {
                parallax.Speed = 0.0f;
            }
        }
    }
}
