using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        string[] hero;
        string[] enermy;
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
                    
                }
                if (i == 1)
                {
                    string[] parts = line.Split(':');
                    money = int.Parse(parts[1]);
                }
                if (i == 2)
                {
                    string pattern = @"\((.*?)\)";

                    // Find all matches of the pattern in the input string
                    MatchCollection matches = Regex.Matches(line, pattern);

                    // Create a new array to store the tower positions
                    string[] towerPositions = new string[matches.Count];

                    // Loop through each match and extract the tower position
                    for (int j  = 0; j  < matches.Count; j ++)
                    {
                        // Extract the tower position from the match
                        string towerPosition = matches[j].Groups[0].Value;
                        Debug.Log(towerPosition);
                        // Add the result string to the tower positions array
                        towerPositions[j] = towerPosition;
                    }

                    // Output the tower positions
                    //foreach (string position in towerPositions)
                    //{
                    //    Debug.Log(position);
                    //}
                }
                if (i == 3)
                {
                    string pattern = @"\((.*?)\)";
                    MatchCollection matches = Regex.Matches(line, pattern);
                    enermy = new string[matches.Count];
                    for (int j = 0; j < matches.Count; j++)
                    {

                        string positionString = matches[j].Groups[1].Value;
                        

                        string resultString = positionString;

                        // Add the result string to the tower positions array
                        enermy[j] = resultString;
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
                }
                if (i == 6)
                {
                    string[] parts = line.Split(':');
                    countTimeSpawn = int.Parse(parts[1]);
                }
                if (i == 7)
                {
                    string[] parts = line.Split(':');
                    enemySpawnRateIncrease = float.Parse(parts[1]);
                }
                if (i == 8)
                {
                    string[] parts = line.Split(':');
                    numberEnemySpawn = int.Parse(parts[1]);
                }
                if (i == 9)
                {
                    string[] parts = line.Split(':');
                    distanceBetweenObjects = float.Parse(parts[1]);
                }

                i++;
              
            }
        }
        else
        {
            Debug.Log("File not found");
        }
    }
}
