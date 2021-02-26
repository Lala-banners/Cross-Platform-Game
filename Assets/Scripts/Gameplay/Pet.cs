using UnityEngine;
using System;

public class Pet : MonoBehaviour
{
    #region Pet Stat Variables
    [SerializeField] private int hunger;
    [SerializeField] private int happiness;
    [SerializeField] private int fun;
    #endregion
    [SerializeField] private GameManager manager;

    //This will be used to measure how much time has passed since game has been played
    //for updating the hunger, happiness and fun bars
    private bool serverTime;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("then", "28/02/2021 5:24"); //TESTING
        UpdateStats();
        manager.happinessSlider.value = _happiness;
        manager.funSlider.value = _fun;
        manager.hungerSlider.value = _hunger;
    }

    private int clickCount;
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            //print("Clicked");
            Camera mainCam = Camera.main;
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousPos = mainCam.ScreenToWorldPoint(mousePos);
            RaycastHit hitInfo;

            if(Physics.Raycast(worldMousPos, Vector2.zero, out hitInfo))
            {
                //print(hit.transform.gameObject.name);
                if(hitInfo.transform.gameObject.CompareTag("Lion"))
                {
                    clickCount++;
                    
                    if(clickCount >= 3)
                    {
                        clickCount = 0; //Reset click count
                        UpdateHappiness(15); //Increase happiness
                    }
                }
            }
        }
    }

    //Use PlayerPrefs to save stats
    private void UpdateStats()
    {
        #region Hunger Stat
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }
        #endregion

        #region Happiness Stat
        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }
        #endregion

        #region Fun Stat

        if (!PlayerPrefs.HasKey("fun"))
        {
            fun = 100;
            PlayerPrefs.SetInt("fun", fun);
        }
        else
        {
            fun = PlayerPrefs.GetInt("fun");
        }
        #endregion

        #region Using TimeSpan to alter hunger and happiness value - I AM GOING TO ASSUME THIS WORKS
        TimeSpan ts = getTimeSpan();
        hunger -= (int)(ts.TotalHours * 2); //Every hour will subtract 2 points from hunger
        if (hunger < 0)
        {
            hunger = 0;
        }

        happiness -= (int)((100 - hunger) * (ts.TotalHours / 5));
        if(happiness < 0)
        {
            happiness = 0;
        }
        //Debug.Log(happiness.ToString());
        //Debug.Log(hunger.ToString());
        #endregion

        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
        }
        
        //Debug.Log(getTimeSpan().ToString()); TESTING

        if (serverTime)
        {
            UpdateServer();
        }
        else
        {
            InvokeRepeating("UpdateDevice", 0f, 30f); //Every 30 sec will save the time when close game. Then when player opens again, time will be based on 30 secs before game was closed.
        }
    }

    public void UpdateServer()
    {

    }

    /// <summary>
    /// This function will allow access of devices time in order to alter hunger and happiness based
    /// on how much time has passed in the game
    /// </summary>
    public void UpdateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    /// <summary>
    /// Object that is the result of two time subtractions
    /// </summary>
    /// <returns></returns>
    TimeSpan getTimeSpan()
    {
        if(serverTime)
        {
            return new TimeSpan();
        }
        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    private string getStringTime()
    {
        DateTime now = DateTime.Now; //Accessing current time on device
        return now.Day + "/" + now.Month + "/" + now.Year + " " + now.Hour + ":" + now.Minute;
    }

    public int _hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int _happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public int _fun
    {
        get { return fun; }
        set { fun = value; }
    }

    /// <summary>
    /// Function to update happiness
    /// </summary>
    /// <param name="happyIndex">happiness index</param>
    public void UpdateHappiness(int happyIndex)
    {
        happiness += happyIndex;
        manager.happinessSlider.value = happiness;

        if(happiness > 100)
        {
            happiness = 100;
        }
    }
}
