using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public int maxHealth;

    private int currentHealth;
    private Transform bar;
    private SpriteRenderer healthSprite;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        healthSprite = bar.Find("Health").GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthSprite.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hit(int value)
    {
        currentHealth += value;
        currentHealth = (currentHealth > maxHealth) ? maxHealth : currentHealth;
        currentHealth = (currentHealth < 0) ? 0 : currentHealth;

        float scale = (float) currentHealth / maxHealth;

        bar.localScale = new Vector3(scale, 1);

        if (scale > 0.75f)
        {
            healthSprite.color = Color.green;
        }
        else if (scale <= 0.75f && scale > 0.25f)
        {
            healthSprite.color = Color.yellow;
        }
        else if (scale <= 0.25f)
        {
            healthSprite.color = Color.red;
        }
    }
}
