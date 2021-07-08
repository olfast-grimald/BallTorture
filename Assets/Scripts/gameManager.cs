using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public Text scoresText;
    public Text livesText;
    public Text levelsText;

    public GameObject panelPlay;
    public GameObject panelStats;
    public GameObject panelGameOver;
    public GameObject panelLevelComplete;
    public GameObject[] levels;

    public static gameManager Instance { get; private set; }
    public enum State { MENU, INIT, LOADLEVEL, PLAY, GAMEOVER, LEVELCOMPLETE }
    State pstate;
    GameObject pballnow;
    GameObject plevelnow;
    bool pswitch;

    private int pscore;

    public int Score
    {
        get { return pscore; }
        set
        {
            pscore = value;
            scoresText.text = "SCORE: " + pscore;
        }
    }

    private int plives;

    public int Lives
    {
        get { return plives; }
        set
        {
            plives = value;
            livesText.text = "LIVES: " + plives;
        }
    }

    private int plevels;

    public int Levels
    {
        get { return plevels; }
        set
        {
            plevels = value;
            levelsText.text = "LEVEL: " + plevels;
        }
    }

    public void playClicked()
    {
        SwitchState(State.INIT);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
        print("here?");
    }

    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        pswitch = true;
        yield return new WaitForSeconds(delay);

        EndState();
        pstate = newState;
        BeginState(newState);
        pswitch = false;

    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panelPlay.SetActive(true);
                Cursor.visible = true;
                //print("arre ho?");
                break;
            case State.INIT:
                Cursor.visible = false;
                //print("init here?");
                panelStats.SetActive(true);
                Score = 00;
                Lives = 3;
                Levels = 0;
                // no this wrong: plevelnow = Instantiate(levels[Levels]);
                //if (plevelnow != null)
                //{
                  //  Destroy(plevelnow);
                //}
                //Instantiate(ballPrefab);
                //switch to loadlevel
                SwitchState(State.LOADLEVEL);
                break;
            case State.LOADLEVEL:
                /*if (Levels >= 0)
                {
                    print(levels.Length);
                    print("did u come here?");
                    SwitchState(State.GAMEOVER);
                }
                else
                {*/
                    //print("stuck here?");
                    if(Levels >= 0)
                {
                    plevelnow = Instantiate(levels[Levels]);
                }
                    if(Levels > levels.Length - 1)
                {
                    print("KO from LOADLEVEL");
                    SwitchState(State.GAMEOVER);
                }
                   // plevelnow = Instantiate(levels[0]);
                print("ball from LOADLEVEL");
                //Instantiate(ballPrefab); // came after switching to play
                SwitchState(State.PLAY);
                //}
               // Instantiate(ballPrefab);
                break;
            case State.PLAY:
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;
            case State.LEVELCOMPLETE:
                if (Levels > levels.Length - 1)
                {
                    print("KO from LEVELCOMPLETE");
                    //Destroy(pballnow);
                    //Destroy(plevelnow);
                    SwitchState(State.GAMEOVER);
                }
                Destroy(pballnow);
                Destroy(plevelnow);
                Levels++;
                SwitchState(State.LOADLEVEL, 2f);
                panelLevelComplete.SetActive(true);
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        switch (pstate)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.LOADLEVEL:
                break;
            case State.PLAY:
                print("play state");
                if (pballnow == null)
                {
                    if (Lives > 0)
                    {
                        pballnow = Instantiate(ballPrefab);
                    }
                    else
                    {
                        print("KO from PLAY");
                        SwitchState(State.GAMEOVER);
                    }
                   /* if (plevelnow != null && plevelnow.transform.childCount == 0 && !pswitch)
                    {
                        SwitchState(State.LEVELCOMPLETE);
                    }*/
                }

                break;
            case State.GAMEOVER:
                if (Input.anyKeyDown)
                {
                    print("KO from GAMEOVER");
                    Score = 0;
                    Lives = 3;
                    Levels = 0;
                    // to stop all levels from instantiating after game over state (from level complete state)
                    Destroy(plevelnow);
                    Destroy(pballnow);
                    SwitchState(State.MENU);
                    
                }
                break;
            case State.LEVELCOMPLETE:
                break;
            default:
                break;
        }
    }

    void EndState()
    {
        switch (pstate)
        {
            case State.MENU:
                print("here often?");
                panelPlay.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.LOADLEVEL:
                break;
            case State.PLAY:
                break;
            case State.GAMEOVER:
                panelStats.SetActive(false);
                panelGameOver.SetActive(false);
                break;
            case State.LEVELCOMPLETE:
                panelLevelComplete.SetActive(false);
                break;
        }
    }
}
