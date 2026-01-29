using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    MasterMask MasterMaskScript;

    int LevelCount = 1;
    public TextMeshProUGUI LevelText;

    public GameObject[] B_Masks;
    public GameObject[] C_Masks;
    public GameObject[] D_Masks;

    public GameObject[] A_Points;
    public GameObject[] B_Points;
    public GameObject[] C_Points;
    public GameObject[] D_Points;

    void Start()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
    }

    public void CorrectMask()
    {
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

        MasterMaskScript.SetMasks();
    }
}
