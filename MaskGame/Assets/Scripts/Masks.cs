using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Masks : MonoBehaviour
{
    MasterMask MasterMaskScript;

    string PickedEyes;
    string PickedNose;
    string PickedMouth;
    Color PickedColour;

    public TextMeshProUGUI EyesText;
    public TextMeshProUGUI NoseText;
    public TextMeshProUGUI MouthText;

    void Start()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
    }
    
    public void RandomizeFeatures()
    {
        PickedEyes = MasterMaskScript.Eyes[Random.Range(0, MasterMaskScript.Eyes.Length)];
        PickedNose = MasterMaskScript.Noses[Random.Range(0, MasterMaskScript.Noses.Length)];
        PickedMouth = MasterMaskScript.Mouths[Random.Range(0, MasterMaskScript.Mouths.Length)];
        PickedColour = MasterMaskScript.Colours[Random.Range(0, MasterMaskScript.Colours.Length)];

        if (PickedEyes == MasterMaskScript.PickedEyes && PickedNose == MasterMaskScript.PickedNose && PickedMouth == MasterMaskScript.PickedMouth && PickedColour == MasterMaskScript.PickedColour)
        {
            RandomizeFeatures();
        }
        else
        {
            EyesText.text = PickedEyes;
            NoseText.text = PickedNose;
            MouthText.text = PickedMouth;
            this.GetComponent<Image>().color = PickedColour;
        }
    }
}
