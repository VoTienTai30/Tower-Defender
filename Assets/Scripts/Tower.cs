using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int cost;
    private Vector3Int cellPosition;


    protected virtual void Start()
    {
    }

    public virtual void Init(Vector3Int cellPos)
    {
        cellPosition = cellPos;
    }

    //Lose Health
    public virtual bool LoseHealth(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    //Die
    protected virtual void Die()
    {
        if (gameObject != null)
        {
            FindObjectOfType<Spawner>().RevertCellState(cellPosition);
            Destroy(gameObject);
        } else
        {
            return;
        }
            
    }
}
