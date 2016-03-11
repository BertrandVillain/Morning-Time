using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{

    public GameObject pauseMenu;
    public GUIStyle restart_GUI;
    public GUIStyle quit_GUI;
    public GUIStyle boxSTYLE;
    public Texture boxTexture;
    public string NextScene;
    public string MENU;



    void OnGUI()
    {
        var rect_restart = new Rect((Screen.width / 4), (2 * Screen.height / 6), Screen.width / 2, (Screen.height) / 6);
        var rect_quit = new Rect((Screen.width / 4), (4 * Screen.height / 6), Screen.width / 3, (Screen.height) / 6);
        if (rect_restart.Contains(Event.current.mousePosition))
        {
            restart_GUI.fontSize = Screen.width / 10;
            restart_GUI.normal.textColor = Color.red;
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(NextScene);
            }
        }
        else
        {
            restart_GUI.fontSize = Screen.width / 11;
            restart_GUI.normal.textColor = Color.black;

        }
        if (rect_quit.Contains(Event.current.mousePosition))
        {
            quit_GUI.fontSize = Screen.width / 10;
            quit_GUI.normal.textColor = Color.red;
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(MENU);
            }
        }
        else
        {
            quit_GUI.fontSize = Screen.width / 11;
            quit_GUI.normal.textColor = Color.black;
        }

        GUI.Box(new Rect(10, 10, (Screen.width - 20), (Screen.height - 20)), boxTexture, boxSTYLE);
        GUI.Box(rect_restart, "Restart", restart_GUI);
        GUI.Box(rect_quit, "Menu", quit_GUI);
    }
}