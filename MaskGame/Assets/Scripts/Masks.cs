using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Masks : MonoBehaviour
{
    MasterMask MasterMaskScript;
    GameplayManager GameplayManagerScript;

    Sprite PickedEyes;
    Sprite PickedNose;
    Sprite PickedMouth;
    Color PickedColour;

    public Image EyesSprite;
    public Image NoseSprite;
    public Image MouthSprite;

    public float ShakeMagnitude;
    float ShakeMaxAngle;
    public float ShakeDuration;
    float ShakeTimer;
    bool Shaking;
    
    public GameObject IncorrectCrossSprite;

    public AudioSource Tap;

    void OnEnable()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();

        Shaking = false;
        ShakeTimer = 0;

        IncorrectCrossSprite.SetActive(false);

        GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        if (ShakeTimer > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-ShakeMaxAngle, ShakeMaxAngle));

            ShakeTimer -= Time.deltaTime;
            ShakeMaxAngle *= (ShakeTimer/ShakeDuration);

        }
        else if (ShakeTimer <= 0 && Shaking == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            Shaking = false;
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameplayManagerScript = GameObject.Find("Game Stats").GetComponent<GameplayManager>();
            GameplayManagerScript.IncorrectMaskStep1();
            
            ShakeTimer = ShakeDuration;
            ShakeMaxAngle = ShakeMagnitude;
            Shaking = true;

            IncorrectCrossSprite.transform.position = transform.position;
            IncorrectCrossSprite.SetActive(true);

            Tap.pitch = Random.Range(0.8f, 1.2f);
            Tap.Play(0);
        }
    }
    
    public void RandomizeFeatures()
    {
        MasterMaskScript = GameObject.Find("Master Mask").GetComponent<MasterMask>();
        
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
            EyesSprite.sprite = PickedEyes;
            NoseSprite.sprite = PickedNose;
            MouthSprite.sprite = PickedMouth;
            GetComponent<Image>().color = PickedColour;
        }
    }
}
