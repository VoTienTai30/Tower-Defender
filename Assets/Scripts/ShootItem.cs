using UnityEngine;

public class ShootItem : MonoBehaviour
{
    public Transform graphics;
    public int damage;
    public float flySpeed,rotateSpeed;

    float screenLeft;
    float screenRight;
    float screenTop;
    float screenBottom;

    public void Init(int dmg)
    {
        damage = dmg;
        saveScreenSize();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().LoseHealth();
            Destroy(gameObject);
        }
    }

    //Handle rotation and flying
    void Update()
    {
        Rotate();
        FlyForward();
        if (gameObject.transform.position.x >= screenRight)
        {
            Destroy(gameObject);
        }
    }
    void Rotate()
    {
        graphics.Rotate(new Vector3(0,0,-rotateSpeed*Time.deltaTime));
    }
    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
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
}
