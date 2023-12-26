using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
     public float currentTime;
    [SerializeField]public float startingTime;
    [SerializeField] public Text countDownText;
    public static Timer instance;

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

    void Start()
    {
        currentTime = startingTime;
    }

   
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if(currentTime<=0)
        {
            currentTime = 0;

        }
        
    }

    public float CurrentTime()
    {
        return currentTime;
    }
}
