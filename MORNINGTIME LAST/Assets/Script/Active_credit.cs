using UnityEngine;
using System.Collections;

public class Active_credit : MonoBehaviour {

    public Texture boxTexture;

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, (Screen.width - 20), (Screen.height - 20)), boxTexture);
    }
}
