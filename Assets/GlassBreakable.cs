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
                //increase if second glass
            }
            gameObjects[i].transform.GetChild(0).GetComponent<BreakableWindow>().enabled = a;
            gameObjects[i+1].transform.GetChild(0).GetComponent<BreakableWindow>().enabled =! gameObjects[i].transform.GetChild(0).GetComponent<BreakableWindow>().enabled;

            gameObjects[i].transform.GetChild(0).GetComponent<BreakableWindow>().breakable = a;
            gameObjects[i + 1].transform.GetChild(0).GetComponent<BreakableWindow>().breakable = !gameObjects[i].transform.GetChild(0).GetComponent<BreakableWindow>().breakable;
            i++;
        }   
    }
}
