using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    MasterMask MasterMaskScript;

    int LevelCount;
    int HighestLevelReach;

    float TotalTimeOnTimer;
    float Timer;
    bool TimerGoing;

    int Score;
    int Highscore = -1;

    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;
    public Slider TimerBar;

    string CauseOfGameOverString;
    public TextMeshProUGUI CauseOfGameOverText;
    public TextMeshProUGUI FinalLevelText;
    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI HighestLevelReachText;
    public TextMeshProUGUI HighscoreText;

    public GameObject GameSpaceScreen;
    public GameObject GameOverScreen;
    public GameObject TransitionScreen;

    public GameObject[] A_Masks;
    public GameObject[] B_Masks;
    public GameObject[] C_Masks;
    public GameObject[] D_Masks;

    public GameObject[] A_Points;
    public GameObject[] B_Points;
    public GameObject[] C_Points;
    public GameObject[] D_Points;

    public int MaskAmountIncreaseLevel2;
    public int MaskAmountIncreaseLevel3;
    public int MaskAmountIncreaseLevel4;
    public int TimerDescreaseStartLevel;
    public int TimerDescreaseEndLevel;

    void OnEnable()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();

        CancelInvoke();
        
        LevelCount = 1;

        TotalTimeOnTimer = 15;
        Timer = TotalTimeOnTimer;
        TimerGoing = true;

        Score = 0;

        LevelText.text = "Level: " + LevelCount;
        ScoreText.text = "Score: <BR>" + Score;

        GameObject[] MaskArray = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject mask in MaskArray)
        {
            mask.SetActive(false);
        }
        foreach(GameObject a_mask in A_Masks)
        {
            a_mask.SetActive(true);
        }

        GameObject[] PointArray = GameObject.FindGameObjectsWithTag("Mask Point");
        foreach(GameObject point in PointArray)
        {
            point.SetActive(false);
        }
        foreach(GameObject a_point in A_Points)
        {
            a_point.SetActive(true);
        }

        MasterMaskScript.SetMasks();
    }

    void Update()
    {
        if (TimerGoing == true)
        {
            Timer -= Time.deltaTime;
            TimerText.text = "Timer: " + Mathf.RoundToInt(Timer * (1000/TotalTimeOnTimer));
            TimerBar.value = Timer * (1000/TotalTimeOnTimer);
        }

        if (Timer <= 0)
        {
            CauseOfGameOverString = "ran out of Time.";
            //GameOver();
        }
    }

    public void CorrectMaskStep1()
    {
        Score += Mathf.RoundToInt(Timer * (1000/TotalTimeOnTimer));
        ScoreText.text = "Score: <BR>" + Score;

        GameObject[] MaskArray = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject mask in MaskArray)
        {
            mask.GetComponent<BoxCollider2D>().enabled = false;
        }

        GameObject[] DuplicateMaskArray = GameObject.FindGameObjectsWithTag("Duplicate Mask");
        foreach(GameObject duplicateMask in DuplicateMaskArray)
        {
            duplicateMask.GetComponent<BoxCollider2D>().enabled = false;
        }

        TimerGoing = false;

        InvokeRepeating("CorrectMaskStep2", 1f, 0.01f);
    }

    void CorrectMaskStep2()
    {
        TransitionScreen.transform.position = Vector3.Lerp(TransitionScreen.transform.position, new Vector3(0, 0, 90), 0.1f);

        Invoke("CorrectMaskStep3", 0.9f);
    }

    void CorrectMaskStep3()
    {
        CancelInvoke();

        LevelCount++;
        LevelText.text = "Level: " + LevelCount;

        if (LevelCount == MaskAmountIncreaseLevel2)
        {
            foreach (GameObject b_mask in B_Masks)
            {
                b_mask.SetActive(true);
            }

            foreach (GameObject a_point in A_Points)
            {
                a_point.SetActive(false);
            }
            foreach (GameObject b_point in B_Points)
            {
                b_point.SetActive(true);
            }
        }
        else if (LevelCount == MaskAmountIncreaseLevel3)
        {
            foreach (GameObject c_mask in C_Masks)
            {
                c_mask.SetActive(true);
            }

            foreach (GameObject b_point in B_Points)
            {
                b_point.SetActive(false);
            }
            foreach (GameObject c_point in C_Points)
            {
                c_point.SetActive(true);
            }
        }
        else if (LevelCount == MaskAmountIncreaseLevel4)
        {
            foreach (GameObject d_mask in D_Masks)
            {
                d_mask.SetActive(true);
            }

            foreach (GameObject c_point in C_Points)
            {
                c_point.SetActive(false);
            }
            foreach (GameObject d_point in D_Points)
            {
                d_point.SetActive(true);
            }
        }

        if(LevelCount > TimerDescreaseStartLevel && LevelCount <= TimerDescreaseEndLevel)
        {
            TotalTimeOnTimer -= 1f/3f;
        }
        Timer = TotalTimeOnTimer;
        TimerGoing = true;

        MasterMaskScript.SetMasks();

                GameObject[] MaskArray = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject mask in MaskArray)
        {
            mask.GetComponent<BoxCollider2D>().enabled = true;
        }
        
        GameObject[] DuplicateMaskArray = GameObject.FindGameObjectsWithTag("Duplicate Mask");
        foreach(GameObject duplicateMask in DuplicateMaskArray)
        {
            duplicateMask.GetComponent<BoxCollider2D>().enabled = true;
        }

        InvokeRepeating("CorrectMaskStep4", 0.1f, 0.01f);
        Invoke("CorrectMaskStep5", 0.5f);
    }

    void CorrectMaskStep4()
    {
        TransitionScreen.transform.position = Vector3.Lerp(TransitionScreen.transform.position, new Vector3(0, -116, 90), 0.1f);
    }

    void CorrectMaskStep5()
    {
        CancelInvoke();
    }

    public void IncorrectMaskStep1()
    {
        CauseOfGameOverString = "got the wrong mask.";

        GameObject[] MaskArray = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject mask in MaskArray)
        {
            mask.GetComponent<BoxCollider2D>().enabled = false;
        }

        GameObject[] DuplicateMaskArray = GameObject.FindGameObjectsWithTag("Duplicate Mask");
        foreach(GameObject duplicateMask in DuplicateMaskArray)
        {
            duplicateMask.GetComponent<BoxCollider2D>().enabled = false;
            duplicateMask.GetComponent<DupMasks>().HighlightLoopStart();
        }

        TimerGoing = false;

        Invoke("IncorrectMaskStep2", 4.9f);
    }

    void IncorrectMaskStep2()
    {
        CauseOfGameOverText.text = "You " + CauseOfGameOverString;

        FinalLevelText.text = "Level: " + LevelCount;
        FinalLevelText.color = Color.white;
        if(LevelCount > HighestLevelReach)
        {
            FinalLevelText.text += " NEW HIGHEST LEVEL REACH!";
            FinalLevelText.color = Color.yellow;
            HighestLevelReach = LevelCount;
        }
        HighestLevelReachText.text = "Highest Level Reach: " + HighestLevelReach;

        FinalScoreText.text = "Score: " + Score;
        FinalScoreText.color = Color.white;
        if(Score > Highscore)
        {
            FinalScoreText.text += " NEW HIGHSCORE!";
            FinalScoreText.color = Color.yellow;
            Highscore = Score;
        }
        HighscoreText.text = "Highscore: " + Highscore;

        InvokeRepeating("IncorrectMaskStep3", 0.1f, 0.01f);
        Invoke("IncorrectMaskStep4", 0.75f);
    }

    void IncorrectMaskStep3()
    {
        GameOverScreen.transform.position = Vector3.Lerp(GameOverScreen.transform.position, new Vector3(0, 0, 90), 0.1f);
    }

    void IncorrectMaskStep4()
    {
        GameSpaceScreen.SetActive(false);
        CancelInvoke();
    }

    public void RestartStep1()
    {
        InvokeRepeating("RestartStep2", 0f, 0.01f);
        Invoke("RestartStep3", 0.5f);
    } 

    void RestartStep2()
    {
        GameOverScreen.transform.position = Vector3.Lerp(GameOverScreen.transform.position, new Vector3(0, -116, 90), 0.1f);
    } 

    void RestartStep3()
    {
        CancelInvoke();
    } 
}
