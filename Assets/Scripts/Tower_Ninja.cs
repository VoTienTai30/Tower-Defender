using System.Collections;
using UnityEngine;

public class Tower_Ninja : Tower
{
    public int damage;
    public GameObject prefab_shootItem;
    public float interval;


    protected override void Start()
    {
        //start the shooting interval IEnum
        StartCoroutine(ShootDelay());
    }
    //Interval for shooting
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());
    }
    //Shoot an item
    void ShootItem()
    {
        //Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem,transform);
        //Set its values  
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
}
