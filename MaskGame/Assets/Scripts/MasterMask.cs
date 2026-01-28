using UnityEngine;

public class MasterMask : MonoBehaviour
{
    public string[] eyes;
    public string[] noses;
    public string[] mouths;

    public string PickedEyes;
    public string PickedNose;
    public string PickedMouth;
    
    void Start()
    {
        PickedEyes = eyes[Random.Range(0, eyes.Length)];
        Debug.Log("Picked Eye = " + PickedEyes);
        PickedNose = noses[Random.Range(0, noses.Length)];
        Debug.Log("Picked Nose = " + PickedNose);
        PickedMouth = mouths[Random.Range(0, mouths.Length)];
        Debug.Log("Picked Mouth = " + PickedMouth);

        GameObject[] MaskObjects = GameObject.FindGameObjectsWithTag("Mask");
        foreach(GameObject maskObject in MaskObjects)
        {
            maskObject.GetComponent<Masks>().RandomizeFeatures();
        }

        GameObject[] DupMaskObjects = GameObject.FindGameObjectsWithTag("Duplicate Mask");
        foreach(GameObject dupMaskObject in DupMaskObjects)
        {
            dupMaskObject.GetComponent<DupMasks>().SetFeatures();
        }
    }
}
