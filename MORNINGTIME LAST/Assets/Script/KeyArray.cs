using UnityEngine;

public class KeyArray : MonoBehaviour
{
    public Key[] array ;

    public Key returnKey(int limit)
    {
        Key lol = array[Random.Range(0, limit)];
        return (lol);

    }

}
