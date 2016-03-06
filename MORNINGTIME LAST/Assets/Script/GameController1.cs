using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour {

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

    // Variable random key
    public int[] range;
    public KeyArray keyarray;
    private Key tmp;
 //   private int posKey = 0;

    // Use this for initialization
    void Start ()
    {
        score = 0;
        totalscore = 0;
        end_alliment = true;
        a = true;
        pause = false;
        day = 1;
        timer = 30;
        countdown = 5;
        timeText.fontSize = Screen.width / 15;
        timeText.text = "Time : " + timer.ToString("F1") + " s";
        scoreText.fontSize = Screen.height / 10;
        scoreText.text = "Calories : " + score;
        totalscoreText.fontSize = Screen.height / 10;
        totalscoreText.text = "Total Calories : " + totalscore;
        dayText.fontSize = Screen.height / 8;
        dayText.text = "day " + day;
        countDownText.fontSize = Screen.width / 4;
        this.initFoodList(1);
        this.putKey();
        choose = true;
        cactus.SetActive(choose);
        chat.SetActive(!choose);
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
            if (Input.GetKeyDown(tmp.KeyBoard) && pause == false)
            {
               AddScore(10);
                tmp.removeKey();
                this.putKey();
                if (foodForADay[aliment].eatFood() == false)
                {
                    print(aliment);
                    if (aliment >= 4)
                        end_alliment = false;
                    print(end_alliment);
                    score += 30;
                    aliment += 1;
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
        timer = 30;
        a = true;
        totalscore += score;
        score = 0;
        totalscoreText.text = "Total Calories : " + totalscore;
        scoreText.text = "Calories : " + score;
        end_alliment = true;
        aliment = 0;
        this.initFoodList(1);
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

            this.foodForADay.Add(foodList[tmp]);
            this.foodForADay[j].show();
        }

    }

    
    //Key Randomizer//

    void putKey()
    {
        tmp = this.keyarray.returnKey(range[day - 1]);
        tmp.displayKey();
    }

}
