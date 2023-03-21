using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnContinue;
    void Start()
    {
        string filePath = Application.dataPath + "/savegame.txt";
        if (!System.IO.File.Exists(filePath))
        {
            btnContinue.gameObject.SetActive(false);  
        }
        StreamReader reader = new StreamReader(filePath);
        string line = reader.ReadToEnd();
        if (line == "" || line == null)
        {
            btnContinue.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
