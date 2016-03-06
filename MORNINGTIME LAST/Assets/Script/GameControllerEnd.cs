using UnityEngine;
using System.Collections;

public class GameControllerEnd : MonoBehaviour {

    public GUIText scoreTotal;
    public GUIText credits;
    public GameObject ObjectCredit;

    // Update is called once per frame
    void Update()
    {
        scoreTotal.fontSize = Screen.width / 22;
        scoreTotal.text = "Calories Total \n     " + PlayerPrefs.GetInt("ScoreMiam");
        credits.fontSize = Screen.height / 14;
        if (credits.HitTest(Input.mousePosition))
        {
            credits.material.color = Color.green;
            ObjectCredit.SetActive(true);
        }
        else
        {
            credits.material.color = Color.white;
            ObjectCredit.SetActive(false);
        }
        credits.text = "Crédits";
    }
}
