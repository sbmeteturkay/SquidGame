using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBridgeManager : MonoBehaviour
{
    public GameObject player;
    public GameObject line;
    public GameObject lose, win;
    public Animator playAnimator;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (line.transform.position.z <= player.transform.position.z)
        {
            win.SetActive(true);
        }
        if (player.transform.position.y < -10)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        lose.SetActive(true);
        playAnimator.SetTrigger("death");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
