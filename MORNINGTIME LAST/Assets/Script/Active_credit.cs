using UnityEngine;
using System.Collections;

public class Active_credit : MonoBehaviour {

    public Texture boxTexture;
    public GUIStyle boxStyle;

    void OnGUI()
    {
        
        GUI.Box(new Rect(10, 10, (Screen.width - 20), (Screen.height)), boxTexture, boxStyle);
    }
}
