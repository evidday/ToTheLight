using UnityEngine;
using System.Collections;

public class EndLocationScript : MonoBehaviour {

    string[] dayType = { "Day", "Night" };
    string[] firstMapType = { "Forest", "Field", "Mountains", "Beach", "Arctic" };
    string[] secondaryMapType = { "None", "Urban", "Country", "River", "Lake", "WarField", "Trash", "WarBase", "Castle", "Town" };
    string[] tripleMapType = { "None", "Settelment", "Camp", "Wild", "Texno", "Monsters" };
    string[] firstEnemyType = { "None", "People", "Monsters", "Texno" };
    string[] secondaryEnemyType = { "None", "People", "Monsters", "Texno" };

    private class NextLocation
    {
        public string dayType;
        public string firstMapType;
        public string secondaryMapType;
        public string tripleMapType;
        public string firstEnemyType;
        public string secondaryEnemyType;

    }

    private NextLocation firstChiose;
    private NextLocation secondChiose;
    private NextLocation tripleChiose;

    private bool activeNextLocationMenu = false;

    private NextLocation GenerateLocation()
    {
        NextLocation next = new NextLocation();
        next.dayType = dayType[Random.Range(1, 1)];
        next.firstMapType = firstMapType[Random.Range(0, 0)];
        next.secondaryMapType = secondaryMapType[Random.Range(0, 0)];
        next.tripleMapType = tripleMapType[Random.Range(0, 0)];
        next.firstEnemyType = firstEnemyType[Random.Range(0, 0)];
        next.secondaryEnemyType = firstEnemyType[Random.Range(0, 0)];
        return next;
    }

    public void SetActiveMenu(bool tf)
    {
        activeNextLocationMenu = true;
    }

	// Use this for initialization
	void Start () {
        firstChiose = GenerateLocation();
        secondChiose = GenerateLocation();
        tripleChiose = GenerateLocation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SaveScene(NextLocation map)
    {
        if (PlayerPrefs.GetString("dayType") == "Day")
        {
            PlayerPrefs.SetString("dayType", "Night");
        }
        else
        {
            PlayerPrefs.SetString("dayType", "Day");
        }
        PlayerPrefs.SetString("firstMapType", map.firstMapType);
        PlayerPrefs.SetString("secondaryMapType", map.secondaryMapType);
        PlayerPrefs.SetString("tripleMapType", map.tripleMapType);
        PlayerPrefs.SetString("firstEnemyType", map.firstEnemyType);
        PlayerPrefs.SetString("secondaryEnemyType", map.secondaryEnemyType);
    }

    void LoadScene()
    {
        Application.LoadLevel("BattleScene");
    }

    void OnGUI()
    {
        if (activeNextLocationMenu)
        {

            if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height / 3), ""))
            {
                SaveScene(firstChiose);
                LoadScene();
            }

            if(GUI.Button(new Rect(0, Screen.height / 3, Screen.width, Screen.height / 3), ""))
            {
                SaveScene(secondChiose);
                LoadScene();
            }

            if(GUI.Button(new Rect(0, Screen.height / 3 * 2, Screen.width, Screen.height / 3), ""))
            {
                SaveScene(tripleChiose);
                LoadScene();
            }

            GUI.Label(new Rect (0, 0, Screen.width, Screen.height / 15), "First Map Type: " + firstChiose.firstMapType);
            GUI.Label(new Rect(0, Screen.height / 15, Screen.width, 2 * Screen.height / 15), "Secondary Map Type: " + firstChiose.secondaryMapType);
            GUI.Label(new Rect(0, 2 * Screen.height / 15, Screen.width, 3 * Screen.height / 15), "Triple Map Type: " + firstChiose.tripleMapType);
            GUI.Label(new Rect(0, 3 * Screen.height / 15, Screen.width, 4 * Screen.height / 15), "First Enemy Type: " + firstChiose.firstEnemyType);
            GUI.Label(new Rect(0, 4 * Screen.height / 15, Screen.width, 5 * Screen.height / 15), "Secondary Map Type: " + firstChiose.secondaryMapType);

            GUI.Label(new Rect(0, 5 * Screen.height / 15, Screen.width, 6 * Screen.height / 15), "First Map Type: " + secondChiose.firstMapType);
            GUI.Label(new Rect(0, 6 * Screen.height / 15, Screen.width, 7 * Screen.height / 15), "Secondary Map Type: " + secondChiose.secondaryMapType);
            GUI.Label(new Rect(0, 7 * Screen.height / 15, Screen.width, 8 * Screen.height / 15), "Triple Map Type: " + secondChiose.tripleMapType);
            GUI.Label(new Rect(0, 8 * Screen.height / 15, Screen.width, 9 * Screen.height / 15), "First Enemy Type: " + secondChiose.firstEnemyType);
            GUI.Label(new Rect(0, 9 * Screen.height / 15, Screen.width, 10 * Screen.height / 15), "Secondary Map Type: " + secondChiose.secondaryMapType);

            GUI.Label(new Rect(0, 10 * Screen.height / 15, Screen.width, 11 * Screen.height / 15), "First Map Type: " + tripleChiose.firstMapType);
            GUI.Label(new Rect(0, 11 * Screen.height / 15, Screen.width, 12 * Screen.height / 15), "Secondary Map Type: " + tripleChiose.secondaryMapType);
            GUI.Label(new Rect(0, 12 * Screen.height / 15, Screen.width, 13 * Screen.height / 15), "Triple Map Type: " + tripleChiose.tripleMapType);
            GUI.Label(new Rect(0, 13 * Screen.height / 15, Screen.width, 14 * Screen.height / 15), "First Enemy Type: " + tripleChiose.firstEnemyType);
            GUI.Label(new Rect(0, 14 * Screen.height / 15, Screen.width, 15 * Screen.height / 15), "Secondary Map Type: " + tripleChiose.secondaryMapType);
        }
    }
}
