using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public Sprite[] sprite;
    private int nbr = 0;
    private int incLimit, currentLimit;

    public Vector2 pos;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
    }

	public bool eatFood()
    {
        currentLimit++;
        if (nbr == sprite.Length)
            return (false);
        if (currentLimit == incLimit)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite[nbr];
            nbr++;
            currentLimit = 0;
        }
        return (true);
    }

    public void SetIncLimit(int tmp)
        {
             incLimit = tmp;
        }
	
    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void reset()
    {
        nbr = 0;
        currentLimit = 0;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite[nbr];
        this.gameObject.SetActive(false);
    }
}
