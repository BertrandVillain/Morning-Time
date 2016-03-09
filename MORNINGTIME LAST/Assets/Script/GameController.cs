using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private float timer;
    private float countdown;
    public GameObject assiette;
    public GameObject daymove;
    public GameObject PauseMenu;

    public GameObject chat;
    public GameObject cactus;
    private bool choose;

    private int score;
    private int totalscore;
    private int day;
    private bool a;
    private bool pause;
    private bool end_alliment;
    public string NextScene;

    public GUIText scoreText;
    public GUIText timeText;
    public GUIText dayText;
    public GUIText countDownText;
    public GUIText totalscoreText;

    // Variable food image
    public Food[] foodList;
    private int aliment = 0;
    private List<Food> foodForADay = new List<Food>();
	//static int[] spotArrayX = {0, 15, 30, 45, 60, 75};
	static Vector3[] spotArray = new Vector3[]
		{
			new Vector3((float)-4.5, (float)-1.5, (float) -2.8),
			new Vector3((float) -2, -2, (float) -1.8),
			new Vector3(0, -1, (float) -1.5),
			new Vector3((float)2, (float)-2.5, (float) -1.8),
			new Vector3((float)4.5, -2, (float) -2.8)
		};
	

	// Use this for initializatio
	void Start ()
    {
        DeviceOrientation orientation = Input.deviceOrientation;
        score = 0;
        totalscore = 0;
        end_alliment = true;
        a = true;
        pause = false;
        day = 1;
        timer = 10;
        countdown = 5;
        timeText.fontSize = Screen.width / 15;
        timeText.text = "Time : " + timer.ToString("F1") + " s";
        scoreText.fontSize = Screen.height / 12;
        scoreText.text = "Calories : " + score;
        totalscoreText.fontSize = Screen.height / 12;
        totalscoreText.text = "Total Calories : " + totalscore;
        dayText.fontSize = Screen.height / 8;
        dayText.text = "day " + day;
        countDownText.fontSize = Screen.width / 4;
        this.initFoodList(2);
        choose = true;
        cactus.SetActive(choose);
        chat.SetActive(!choose);
        if (orientation == DeviceOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if (orientation == DeviceOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
    }

    // Update is called once per frame
    void Update()
    {
       pause_game();
       if (a == true)
        {
            Vector3 temp = new Vector3((float)0.47, (float)0.31, 0);
            if (countdown > 0)
            {
                assiette.SetActive(true);
                countDownText.text = "" + countdown.ToString("F0");
                countdown -= Time.deltaTime;
                daymove.transform.position = temp;
            }
            else
            {
                assiette.SetActive(false);
                a = false;
                countdown = 5;
            }
        }
        else
        {
            Vector3 pos1 = new Vector3((float)0.47, (float)0.7, 0);
            daymove.transform.position = pos1;
            if (Input.touchCount > 0)
            {
                if (TouchPhase.Began == Input.GetTouch(0).phase && pause == false)
                {
                    AddScore(10);
                    if (foodForADay[aliment].eatFood() == false)
                    {
                        if (aliment >= 4)
                        {
                            end_alliment = false;
                            score += 100;
                        }
                        score += 30;
                        aliment += 1;
                    }
                }
            }
            if (timer >= 0 && end_alliment == true)
            {
                timeText.text = "Time : " + timer.ToString("F1") + " s";
                timer -= Time.deltaTime;
            }
            else
            {
             reinit_day();
            }
        }
   }

    public void reinit_day()
    {
        choose = !choose;
        cactus.SetActive(choose);
        chat.SetActive(!choose);
        day++;
        dayText.text = "day " + day;
        timer = 10;
        a = true;
        totalscore += score;
        score = 0;
        totalscoreText.text = "Total Calories : " + totalscore;
        scoreText.text = "Calories : " + score;
        end_alliment = true;
        aliment = 0;
        this.initFoodList(2);
        if (day == 6)
        {
            PlayerPrefs.SetInt("ScoreMiam", totalscore);
            SceneManager.LoadScene(NextScene);
        }
    }

    // Score
    public void AddScore(int newscore)
    {
        score += newscore;
        scoreText.text = "Calories : " + score;
    }

    //pause
    public void pause_game()
    {
        if (Input.GetKeyDown("escape"))
        {
            pause = !pause;
        }

        if (pause == true)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(pause);
        }
        else
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(pause);
        }
    }

	void printFoodForADay()
	{
		int i = 0;

		while (i < this.foodForADay.Count)
		{
			Debug.Log(foodForADay[i].name, gameObject);
			i++;
		}
	}

	//verifier que l'élément n'est pas déja dans la liste avant de l'ajouter
	bool checkAddFoodForADay(int indexFoodList)
	{
		int i = 0;
		Debug.Log(foodForADay.Count.ToString()+"-------", gameObject);
		while (i < this.foodForADay.Count)
		{
			if (this.foodForADay[i] == this.foodList[indexFoodList])
			{
				Debug.Log("false", gameObject);
				return (false);
			}
			i++;
		}
		return (true);
	}

    void initFoodList(int limit)
    {
        int tmp;

        foodForADay.Clear();
        for (int i = 0; i < foodList.Length; i++)
        {
            foodList[i].SetIncLimit(limit);
            foodList[i].reset();
        }
        for (int j = 0; j < 5; j++)
        {
            tmp = Random.Range(0, foodList.Length);

			while (this.checkAddFoodForADay(tmp) == false)
				tmp = Random.Range(0, foodList.Length);
			this.foodForADay.Add(foodList[tmp]);
			this.foodForADay[j].show();
			this.foodForADay[j].transform.position = spotArray[j]; //A rajouter pour alignement
        }
		printFoodForADay();
    }
}
