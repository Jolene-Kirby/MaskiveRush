using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DupMasks : MonoBehaviour
{
    MasterMask MasterMaskScript;
    GameplayManager GameplayManagerScript;


    public TextMeshProUGUI EyesText;
    public TextMeshProUGUI NoseText;
    public TextMeshProUGUI MouthText;

    void Start()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
        GameplayManagerScript = GameObject.Find("Game Stats").GetComponent<GameplayManager>();
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameplayManagerScript.CorrectMask();
        }
    }
    
    public void SetFeatures()
    {
        EyesText.text = MasterMaskScript.PickedEyes;
        NoseText.text = MasterMaskScript.PickedNose;
        MouthText.text = MasterMaskScript.PickedMouth;
        this.GetComponent<Image>().color = MasterMaskScript.PickedColour;
    }
}
