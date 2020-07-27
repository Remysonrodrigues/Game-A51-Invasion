using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBarController : MonoBehaviour
{
    public int maxBullets;

    private int currentBullets;
    private Transform bar;
    private SpriteRenderer bulletsSprite;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        bulletsSprite = bar.Find("Bullets").GetComponent<SpriteRenderer>();
        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use(int value)
    {
        currentBullets += value;
        currentBullets = (currentBullets > maxBullets) ? maxBullets : currentBullets;
        currentBullets = (currentBullets < 0) ? 0 : currentBullets;

        float scale = (float) currentBullets / maxBullets;

        bar.localScale = new Vector3(scale, 1);
    }
}
