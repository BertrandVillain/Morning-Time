using UnityEngine;

public class KeyArray : MonoBehaviour
{
    public Key[] array ;

    public Key returnKey()
    {
        return (array[Random.Range(0, array.Length)]);
    }
    
}
