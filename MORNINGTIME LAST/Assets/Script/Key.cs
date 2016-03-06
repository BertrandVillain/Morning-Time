using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public string KeyBoard;

    public void displayKey()
    {
        this.gameObject.SetActive(true);
    }

    public void removeKey()
    {
        this.gameObject.SetActive(false);
    }
}
