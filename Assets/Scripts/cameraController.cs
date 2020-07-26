using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;


    private Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        offset = transform.position - player.transform.position;
        offset = new Vector3(offset.x, 0, 0);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {
        if (player != null) {
            Vector3 tmp = player.transform.position + offset;
            transform.position = new Vector3(tmp.x, 0, -10);
        }
    }
}
