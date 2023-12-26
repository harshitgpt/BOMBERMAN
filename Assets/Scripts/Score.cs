using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;


public class Score : MonoBehaviour
{

    public static Score instance;
    [SerializeField] public Text scoreText;
    public int intialScore = 0;
    public int sceneIndex;
    public int highestScore = 0;
    public int levelScore=0;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        string  jsonDataPath = Path.Combine(Application.persistentDataPath, "LevelScore" + sceneIndex + ".json");
        if (File.Exists(jsonDataPath))
        {
            string jsonStr = File.ReadAllText(jsonDataPath);
            levelScore = JsonConvert.DeserializeObject<int>(jsonStr);

            highestScore = levelScore;
            scoreText.text = highestScore.ToString("0");

        }
        else
        {
            highestScore = levelScore;
            scoreText.text = intialScore.ToString("0");
        }


    }

    
}
