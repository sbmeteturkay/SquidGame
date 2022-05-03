using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreakable : MonoBehaviour
{
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < gameObjects.Length; i++)
        {
            int f = Random.Range(1, 3);
            Debug.Log(f);
            bool a = true;
            if (f == 2)
            {
                a = false;
                i++;
            }
            gameObjects[i].transform.GetChild(0).GetComponent<BreakableWindow>().breakable = a;
        }   
    }
}
