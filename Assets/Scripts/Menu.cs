using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEditor.Progress;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadFile()
    {
        int money = 0;
        int health = 0;
        int spawnerTime = 0;
        int percentRandomBoss = 0;
        int countTimeSpawn = 0;
        float enemySpawnRateIncrease = 0;
        int numberEnemySpawn = 2;
        float distanceBetweenObjects = 3;
        //string[] hero;
        //string[] enermy;
        string filePath = Application.dataPath + "/savegame.txt";
        if (System.IO.File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string line;
            var i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (i == 0)
                {
                    string[] parts = line.Split(':');
                     health = int.Parse(parts[1]);
                    var healthsys = new HealthSystem();
                    healthsys.defaultHealthCount = health;

                }
                if (i == 1)
                {
                    string[] parts = line.Split(':');
                    money = int.Parse(parts[1]);
                    var currency = new CurrencySystem();
                    currency.currency = money;
                }
                if (i == 2)
                {
                    string pattern = "\\(Tower[123]\\(Clone\\) [-+]?[0-9]*\\.?[0-9]+ [-+]?[0-9]*\\.?[0-9]+ [-+]?[0-9]*\\.?[0-9]+\\)";

                    // Find all matches of the pattern in the input string
                    MatchCollection matches = Regex.Matches(line, pattern);

                    // Create a new list to store the tower positions
                    List<string> towerPositions = new List<string>();

                    // Loop through each match and extract the tower position
                    foreach (Match match in matches)
                    {

                        // Extract the tower position from the match
                        string towerPosition = match.Groups[0].Value;

                        // Add the result string to the tower positions list
                        towerPositions.Add(towerPosition);
                    }

                    // Output the tower positions
                    foreach (string position in towerPositions)
                    {
                        Debug.Log(position);
                    }
                }
                if (i == 3)
                {
                    string pattern = "\\(Enemy[123]\\(Clone\\) [-+]?[0-9]*\\.?[0-9]+ [-+]?[0-9]*\\.?[0-9]+ [-+]?[0-9]*\\.?[0-9]+\\)";

                    // Find all matches of the pattern in the input string
                    MatchCollection matches = Regex.Matches(line, pattern);

                    // Create a new list to store the tower positions
                    List<string> towerPositions = new List<string>();

                    // Loop through each match and extract the tower position
                    foreach (Match match in matches)
                    {


                        // Extract the tower position from the match
                        string towerPosition = match.Groups[0].Value;

                        // Add the result string to the tower positions list
                        towerPositions.Add(towerPosition);
                    }

                    // Output the tower positions
                    var spawn = new EnemySpawner();
                    foreach (string position in towerPositions)
                    {
                        string[] parts = line.Split(' ');
                        var numbers = Regex.Matches(parts[0], @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
                        //spawn.loadGame(numbers[0], float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                    }
                }
                if (i == 4)
                {
                    string[] parts = line.Split(':');
                    spawnerTime = int.Parse(parts[1]);
                    
                }
                if (i == 5)
                {
                    string[] parts = line.Split(':');
                    percentRandomBoss = int.Parse(parts[1]);
                    var spanwer = new EnemySpawner();
                    spanwer.percentRandomBoss = percentRandomBoss;
                }
                if (i == 6)
                {
                    string[] parts = line.Split(':');
                    countTimeSpawn = int.Parse(parts[1]);
                    var spanwer = new EnemySpawner();
                    spanwer.countTimeSpawn = countTimeSpawn;
                }
                if (i == 7)
                {
                    string[] parts = line.Split(':');
                    enemySpawnRateIncrease = float.Parse(parts[1]);
                    var spanwer = new EnemySpawner();
                    spanwer.enemySpawnRateIncrease = enemySpawnRateIncrease;

                }
                if (i == 8)
                {
                    string[] parts = line.Split(':');
                    numberEnemySpawn = int.Parse(parts[1]);
                    var spanwer = new EnemySpawner();
                    spanwer.numberEnemySpawn = numberEnemySpawn;
                }
                if (i == 9)
                {
                    string[] parts = line.Split(':');
                    distanceBetweenObjects = float.Parse(parts[1]);
                    var spanwer = new EnemySpawner();
                    spanwer.distanceBetweenObjects = distanceBetweenObjects;
                }

                i++;
              
            }
           
        }
        else
        {
            Debug.Log("File not found");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
