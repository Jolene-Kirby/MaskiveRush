using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MasterMask : MonoBehaviour
{
    public Sprite[] Eyes;
    public Sprite[] Noses;
    public Sprite[] Mouths;
    public Color[] Colours;

    public Sprite PickedEyes;
    public Sprite PickedNose;
    public Sprite PickedMouth;
    public Color PickedColour;

    public GameObject DuplicateMask1;
    public GameObject DuplicateMask2;
    public List<GameObject> MaskList;
    
    void OnEnable()
    {
        SetMasks();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            SetMasks();
        }
    }

    public void SetMasks()
    {
        MaskList.Clear();
        MaskList.Add(DuplicateMask1);
        MaskList.Add(DuplicateMask2);
        GameObject[] MaskObjects = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject maskObject in MaskObjects)
        {
            MaskList.Add(maskObject);
        }
        
        GameObject[] MaskPointObjects = GameObject.FindGameObjectsWithTag("Mask Point");
        foreach(GameObject maskPoint in MaskPointObjects)
        {
            GameObject TempMask = MaskList[Random.Range(0, MaskList.Count)];
            TempMask.transform.position = maskPoint.transform.position;
            MaskList.Remove(TempMask);
        }

        CreateFeatures();
    }

    void CreateFeatures()
    {
        PickedEyes = Eyes[Random.Range(0, Eyes.Length)];
        Debug.Log("Picked Eye = " + PickedEyes);
        PickedNose = Noses[Random.Range(0, Noses.Length)];
        Debug.Log("Picked Nose = " + PickedNose);
        PickedMouth = Mouths[Random.Range(0, Mouths.Length)];
        Debug.Log("Picked Mouth = " + PickedMouth);
        PickedColour = Colours[Random.Range(0, Colours.Length)];
        Debug.Log("PickedColour = " + PickedColour);

        GameObject[] DupMaskObjects = GameObject.FindGameObjectsWithTag("Duplicate Mask");
        foreach(GameObject dupMaskObject in DupMaskObjects)
        {
            dupMaskObject.GetComponent<DupMasks>().SetFeatures();
        }

        GameObject[] MaskObjects = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject maskObject in MaskObjects)
        {
            maskObject.GetComponent<Masks>().RandomizeFeatures();
        }
    }
}
