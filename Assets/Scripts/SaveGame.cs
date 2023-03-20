using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI moneyTxt;
    [SerializeField]
    TextMeshProUGUI healthTxt;
    [SerializeField]
    Button buttonSave;
    GameObject[] listHeroes;
    GameObject[] listEnemy;
    string money;
    string health;

    public void saveGame()
    {
        string filePath = Application.dataPath + "/savegame.txt";
        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, String.Empty);

            listHeroes = GameObject.FindGameObjectsWithTag("Tower");
            listEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            money = moneyTxt.text;
            health = healthTxt.text;
            string txt = "";
            txt += $"health: {health}\nmoney: {money}\nheroes: (";
            StreamWriter writer = new StreamWriter(filePath, true);
            foreach (GameObject hero in listHeroes)
            {
                txt += "(" + hero.name + " " + hero.transform.position.x + " " + hero.transform.position.y + " " + hero.transform.localScale.x + ")";
            }
            txt += ")\nenemy: (";
            foreach (GameObject enemy in listEnemy)
            {
                txt += "(" + enemy.name + " " + enemy.transform.position.x + " " + enemy.transform.position.y + " " + enemy.transform.localScale.x + ")";
            }
            Timer time = GameObject.Find("_Scripts").GetComponents<Timer>()[0];
            txt += ")\nenemy spawner time: " + time.Duration + "\n";
            txt += "percent random boss: " + GameObject.Find("_Scripts").GetComponent<EnemySpawner>().percentRandomBoss +"\n";
            txt += "count time spawn: " + GameObject.Find("_Scripts").GetComponent<EnemySpawner>().countTimeSpawn + "\n";
            txt += "enemy spawn rate increase: " + GameObject.Find("_Scripts").GetComponent<EnemySpawner>().enemySpawnRateIncrease + "\n";
            txt += "number enemy spawn: " + GameObject.Find("_Scripts").GetComponent<EnemySpawner>().numberEnemySpawn + "\n";
            txt += "distance between objects: " + GameObject.Find("_Scripts").GetComponent<EnemySpawner>().distanceBetweenObjects;
            writer.Write(txt);
            writer.Close();
        }
        else
        {
            Debug.Log("File not found");
        }
    }
}
