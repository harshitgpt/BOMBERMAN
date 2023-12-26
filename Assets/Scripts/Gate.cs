using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.IO;

public class Gate : MonoBehaviour
{
    public new SpriteRenderer renderer;

    public Collider2D boxCol;
    public Collider2D circleCol;

    public Sprite gateClosed;
    public Sprite gateOpen;

    public int sceneIndex;
    public int score=0;
    

    public void Start()
    {
        sceneIndex= SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        ///If enemies aren't alive, open the gate

        if (FindObjectOfType<LevelCreator>().numberOfEnemies <= 0)
        {
            renderer.sprite = gateOpen;
            boxCol.enabled = false;
            circleCol.enabled = true;
        }

     
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ///Enter gate on collision with player

        if (col.gameObject.tag.Equals("Player"))
        {
            int timeLeft =(int) Timer.instance.CurrentTime();
            score = (timeLeft) * 10;

            if (score >= Score.instance.highestScore)
            {

                string json = JsonConvert.SerializeObject(score);
                File.WriteAllText(Path.Combine(Application.persistentDataPath, "LevelScore" + sceneIndex + ".json"), json);


            }
           


            if (sceneIndex == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            else
            { FindObjectOfType<WinPanel>().canvas.enabled = true; }
            
        }
    }

  

   

}
