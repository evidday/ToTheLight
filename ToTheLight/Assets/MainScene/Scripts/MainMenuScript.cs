using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void GenerateLocation()
    {
        string[] dayType = { "Day", "Night" };
        string[] firstMapType = { "Field", "Forest", "Mountains", "Beach", "Arctic" };
        string[] secondaryMapType = { "None", "Urban", "Country", "River", "Lake", "WarField", "Trash", "WarBase", "Castle", "Town"};
        string[] tripleMapType = { "None", "Settelment", "Camp", "Wild", "Texno", "Monsters" };
        string[] firstEnemyType = { "None", "People", "Monsters", "Texno" };
        string[] secondaryEnemyType = { "None", "People", "Monsters", "Texno" };
        PlayerPrefs.SetString("dayType", dayType[Random.Range(1, 1)]);
        PlayerPrefs.SetString("firstMapType", firstMapType[Random.Range(0, 0)]);
        PlayerPrefs.SetString("secondaryMapType", secondaryMapType[Random.Range(0, 0)]);
        PlayerPrefs.SetString("tripleMapType", tripleMapType[Random.Range(0, 0)]);
        PlayerPrefs.SetString("firstEnemyType", firstEnemyType[Random.Range(0, 0)]);
        PlayerPrefs.SetString("secondaryEnemyType", firstEnemyType[Random.Range(0, 0)]);
    }

    private void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Hero", 0);
        GenerateLocation();
        Application.LoadLevel("BattleScene");
    }

    private void Load()
    {
        PlayerPrefs.SetInt("Hero", 1);
        Application.LoadLevel("BattleScene");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height / 4), "New Game"))
        {
            NewGame();
        }
        if (GUI.Button(new Rect(0, Screen.height / 4, Screen.width, Screen.height / 4), "Continue"))
        {
            Load();
        }
        if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width, Screen.height / 4), "Options"))
        {

        }
        if (GUI.Button(new Rect(0, Screen.height / 4 * 3, Screen.width, Screen.height / 4), "Exit"))
        {
            Application.Quit();
        }
    }   
}
