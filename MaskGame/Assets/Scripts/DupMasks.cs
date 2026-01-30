using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DupMasks : MonoBehaviour
{
    MasterMask MasterMaskScript;
    GameplayManager GameplayManagerScript;


    public Image EyesSprite;
    public Image NoseSprite;
    public Image MouthSprite;

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameplayManagerScript = GameObject.Find("Game Stats").GetComponent<GameplayManager>();
            GameplayManagerScript.CorrectMask();
        }
    }
    
    public void SetFeatures()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
        EyesSprite.sprite = MasterMaskScript.PickedEyes;
        NoseSprite.sprite = MasterMaskScript.PickedNose;
        MouthSprite.sprite = MasterMaskScript.PickedMouth;
        this.GetComponent<Image>().color = MasterMaskScript.PickedColour;
    }
}
