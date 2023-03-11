using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;

    [SerializeField]
    public int baseHealth;

    [SerializeField]
    public int attackPower;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public HealthBar healthBar;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    public void loseHealth()
    {
        health--;
        healthBar.setHealth(health, baseHealth);
        StartCoroutine(BlinkRed());
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
