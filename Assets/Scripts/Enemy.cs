using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;

    [SerializeField]
    public int attackPower;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public float attackInterval;

    Coroutine attackOrder;

    Tower detectedTower;
    private Animator animator;
    float screenLeft;
    float screenRight;
    float screenTop;
    float screenBottom;
    float posY;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        saveScreenSize();
        posY = transform.position.y;
    }

    void Update()
    {
        if (!detectedTower)
        {
            Move();
        }
    }
    private void saveScreenSize()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
    }
    void Move()
    {
        animator.SetBool("isAttack", false);
        float posX = transform.position.x - moveSpeed * Time.deltaTime;
        transform.position = new Vector3(posX, posY, -Camera.main.transform.position.z);
        if(gameObject.transform.position.x <= screenLeft)
        {
            GameManager.instance.health.LoseHealth();
            Destroy(gameObject);
        }
    }

    IEnumerator Attack()
    {
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(attackInterval);
        attackOrder = StartCoroutine(Attack());
        InflictDamage();
    }

    public void InflictDamage()
    {
        if(detectedTower != null)
        {
            bool towerDied = detectedTower.LoseHealth(attackPower);
            if (towerDied)
            {
                detectedTower = null;
                StopCoroutine(attackOrder);
            }
        }    
    }

    public void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());
        if (health <= 0)
            Destroy(gameObject);
    }

    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
            return;

        if (collision.tag == "Tower")
        {
            detectedTower = collision.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        }
    }
}
