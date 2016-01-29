using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private int score;
    public GUIText scoreText;

	// Use this for initialization
	void Start ()
    {
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	if (Input.GetButton("Jump"))
        {
            AddScore(10);
        }
        if (Input.GetKey("up"))
            print("up arrow key is held down");

        if (Input.GetKey("down"))
            print("down arrow key is held down");
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newscore)
    {
        score += newscore;
        UpdateScore();
    }

}
