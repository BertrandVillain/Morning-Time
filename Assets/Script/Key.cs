using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public char KeyBoard;
    public GameObject KeySprite;

    public void displayKey()
    {
        KeySprite.active = true;
    }
}
