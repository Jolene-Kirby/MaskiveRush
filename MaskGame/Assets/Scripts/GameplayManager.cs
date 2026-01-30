using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    MasterMask MasterMaskScript;

    int LevelCount = 1;
    float Timer = 10;
    float TimerTickRate = 1;
    int Score;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    string CauseOfGameOverString;
    public TextMeshProUGUI CauseOfGameOverText;
    public TextMeshProUGUI FinalLevelText;
    public TextMeshProUGUI FinalScoreText;

    public GameObject GameSpaceScreen;
    public GameObject GameOverScreen;

    public GameObject[] B_Masks;
    public GameObject[] C_Masks;
    public GameObject[] D_Masks;

    public GameObject[] A_Points;
    public GameObject[] B_Points;
    public GameObject[] C_Points;
    public GameObject[] D_Points;

    void OnEnable()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
        
        LevelCount = 1;
        Timer = 10;
        TimerTickRate = 1;
        Score = 0;

        LevelText.text = "Level: " + LevelCount;
        ScoreText.text = "Score: " + Score;
    }

    void Update()
    {
        Timer = Timer - (Time.deltaTime * TimerTickRate);
        TimerText.text = "Timer: " + Mathf.RoundToInt(Timer * 100);

        if (Timer <= 0)
        {
            CauseOfGameOverString = "ran out of Time.";
            GameOver();
        }
    }

    public void CorrectMask()
    {
        Score = Score + Mathf.RoundToInt(Timer * 100);
        ScoreText.text = "Score: " + Score;
        Timer = 10;

        LevelCount++;
        LevelText.text = "Level: " + LevelCount;

        if (LevelCount == 6)
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
        else if (LevelCount == 11)
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
        else if (LevelCount == 16)
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

        if(LevelCount >= 21)
        {
            TimerTickRate = -(1 / Mathf.Sqrt(1 + (Mathf.Pow(LevelCount - 20, 2) / 100))) + 2;
        }
        Debug.Log(TimerTickRate);

        MasterMaskScript.SetMasks();
    }

    public void WrongMask()
    {
        CauseOfGameOverString = "got the wrong mask.";
        GameOver();
    }

    void GameOver()
    {
        FinalLevelText.text = "Level: " + LevelCount;
        FinalScoreText.text = "Score: " + Score;
        CauseOfGameOverText.text = "You " + CauseOfGameOverString;
        GameOverScreen.SetActive(true);
        GameSpaceScreen.SetActive(false);
    }
}
