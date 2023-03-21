using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

namespace Assets.Scripts
{
    public class FirstTime : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> prefabsTower;

        [SerializeField]
        public List<GameObject> prefabsEnemy;
        private void Start()
        {
            if(DataLoad.isContinue == true)
            {
                GameObject.Find("_Scripts").GetComponent<HealthSystem>().healthCount = DataLoad.health;
                GameObject.Find("_Scripts").GetComponent<HealthSystem>().txt_healthCount.text = DataLoad.health.ToString();
                GameObject.Find("_Scripts").GetComponent<CurrencySystem>().currency = DataLoad.money;
                GameObject.Find("_Scripts").GetComponent<CurrencySystem>().txt_Currency.text = DataLoad.money.ToString();
                GameObject.Find("_Scripts").GetComponent<EnemySpawner>().timer.Duration = DataLoad.spawnerTime;
                GameObject.Find("_Scripts").GetComponent<EnemySpawner>().percentRandomBoss = DataLoad.percentRandomBoss;
                GameObject.Find("_Scripts").GetComponent<EnemySpawner>().countTimeSpawn = DataLoad.countTimeSpawn;
                GameObject.Find("_Scripts").GetComponent<EnemySpawner>().enemySpawnRateIncrease = DataLoad.enemySpawnRateIncrease;
                GameObject.Find("_Scripts").GetComponent<EnemySpawner>().numberEnemySpawn = DataLoad.numberEnemySpawn;
                GameObject.Find("_Scripts").GetComponent<EnemySpawner>().distanceBetweenObjects = DataLoad.distanceBetweenObjects;

                foreach(string item in DataLoad.towers)
                {
                    string[] parts = item.Split(' ');

                    var number = parts[0].Substring(6, 1);
                    var posX = (float) Convert.ToDouble(parts[1]);
                    var posY = (float) Convert.ToDouble(parts[2]);
                    var posZ = (float) Convert.ToDouble(parts[3].Substring(0, 1));

                    GameObject tower = prefabsTower[Convert.ToInt32(number) - 1];
                    Vector3 pos = new Vector3(posX, posY, posZ);
                    Instantiate(tower, pos, Quaternion.identity);

                }

                foreach (string item in DataLoad.enemies)
                {
                    string[] parts = item.Split(' ');

                    var number = parts[0].Substring(6, 1);
                    var posX = (float)Convert.ToDouble(parts[1]);
                    var posY = (float)Convert.ToDouble(parts[2]);
                    var posZ = (float)Convert.ToDouble(parts[3].Substring(0, 2));

                    GameObject enemy = prefabsEnemy[Convert.ToInt32(number) - 1];
                    Vector3 pos = new Vector3(posX, posY, posZ);
                    Instantiate(enemy, pos, Quaternion.identity);
                }

            }
            else
            {
                Debug.Log("New game");
            }
        }
    }
}
