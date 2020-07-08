using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Material materialAtual;
    public float velocidadeX;
    private float escalaMovimento;

    // Start is called before the first frame update
    void Start()
    {
        materialAtual = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        escalaMovimento += 0.01f;   

        materialAtual.SetTextureOffset("_MainTex", new Vector2(escalaMovimento * velocidadeX, 0));
    }
}
