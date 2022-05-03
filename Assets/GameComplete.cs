using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameComplete : MonoBehaviour
{

    public GameObject player;
    public GameObject line;
    public GameObject girl;
    public AudioSource audio;
    public Countdown countdown;
    public GameObject lose, win;
    public Animator playAnimator;
    Vector3 vector,vector180,vectorPlayer;
    bool watching=false;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        vector = new Vector3(0, 0, 0);
        vector180 = new Vector3(0, 180, 0);

        girl.transform.DORotate(vector, 1);
        StartCoroutine("GirlMoveBack",1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (watching)
        {
            if (IsMoving())
            {
                GameOver();
                Debug.Log("moving lose lose");
            }
        }
        if (countdown._currentTime<= 0){
            GameOver();
            Debug.Log("countdown lose");
        }
        else if (line.transform.position.z <= player.transform.position.z)
        {
            win.gameObject.SetActive(true);
        }
    }
    public void GameOver()
    {
        lose.SetActive(true);
        playAnimator.SetTrigger("death");
    }
    public bool IsMoving()
    {
        if (vectorPlayer != player.transform.position)
            return true;
        else
            return false;
    }
    public IEnumerator GirlMove()
    {
        yield return new WaitForSeconds(5);
        girl.transform.DORotate(vector,1);
        watching = false;
        StartCoroutine(GirlMoveBack());
    }
    public IEnumerator GirlMoveBack()
    {
        audio.Play();
        yield return new WaitForSeconds(2.65f);
        girl.transform.DORotate(vector180,1);
        yield return new WaitForSeconds(1);
        watching = true;
        vectorPlayer = player.transform.position;
        StartCoroutine("GirlMove");
    }
}
