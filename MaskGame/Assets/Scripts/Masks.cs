using UnityEngine;
using TMPro;

public class Masks : MonoBehaviour
{
    MasterMask MasterMaskScript;

    string PickedEyes;
    string PickedNose;
    string PickedMouth;

    public TextMeshProUGUI EyesText;
    public TextMeshProUGUI NoseText;
    public TextMeshProUGUI MouthText;

    void Start()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
    }
    
    public void RandomizeFeatures()
    {
        PickedEyes = MasterMaskScript.eyes[Random.Range(0, MasterMaskScript.eyes.Length)];
        PickedNose = MasterMaskScript.noses[Random.Range(0, MasterMaskScript.noses.Length)];
        PickedMouth = MasterMaskScript.mouths[Random.Range(0, MasterMaskScript.mouths.Length)];

        if (PickedEyes == MasterMaskScript.PickedEyes && PickedNose == MasterMaskScript.PickedNose && PickedMouth == MasterMaskScript.PickedMouth)
        {
            RandomizeFeatures();
        }
        else
        {
            EyesText.text = PickedEyes;
            NoseText.text = PickedNose;
            MouthText.text = PickedMouth;
        }
    }
}
