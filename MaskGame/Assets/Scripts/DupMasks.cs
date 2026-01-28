using UnityEngine;
using TMPro;

public class DupMasks : MonoBehaviour
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
    
    public void SetFeatures()
    {
        EyesText.text = MasterMaskScript.PickedEyes;
        NoseText.text = MasterMaskScript.PickedNose;
        MouthText.text = MasterMaskScript.PickedMouth;
    }
}
