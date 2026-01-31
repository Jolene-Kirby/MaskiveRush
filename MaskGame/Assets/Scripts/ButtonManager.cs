using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameplayManager GameplayManagerScript;

    public GameObject StartScreen;
    public GameObject GameSpaceScreen;
    public GameObject GameOverScreen;
    public GameObject TransitionScreen;

    public TextMeshProUGUI ButtonText;

    public AudioSource Tap;
    public AudioSource Slide;

    void OnEnable()
    {
        ButtonText.color = Color.white;
    }

    void OnMouseEnter()
    {
        ButtonText.color = Color.grey;
    }

    void OnMouseDown()
    {
        Tap.pitch = Random.Range(0.8f, 1.2f);
        Tap.Play(0);
    }

    void OnMouseExit()
    {
        ButtonText.color = Color.white;
    }

    public void StartGame()
    {
        InvokeRepeating("StartGameStep1", 0f, 0.01f);
        
        Slide.pitch = Random.Range(0.8f, 1.2f);
        Slide.Play(0);

        Invoke("StartGameStep2", 0.6f);
    }

    public void Restart()
    {
        GameSpaceScreen.SetActive(true);

        GameplayManagerScript = GameObject.Find("Game Stats").GetComponent<GameplayManager>();
        GameplayManagerScript.RestartStep1();
    }

    public void BackToStartScreen()
    {
        StartScreen.SetActive(true);

        InvokeRepeating("BackToStartScreenStep1", 0f, 0.01f);

        Slide.pitch = Random.Range(0.8f, 1.2f);
        Slide.Play(0);

        Invoke("BackToStartScreenStep2", 0.6f);
    }

    void StartGameStep1()
    {
        TransitionScreen.transform.position = Vector3.Lerp(TransitionScreen.transform.position, new Vector3(0, 0, 90), 0.1f);
    }
    void StartGameStep2()
    {
        CancelInvoke();
        Invoke("StartGameStep3", 1f);
    }

    void StartGameStep3()
    {
        GameSpaceScreen.SetActive(true);
        StartScreen.SetActive(false);

        InvokeRepeating("StartGameStep4", 0f, 0.01f);

        Slide.pitch = Random.Range(0.8f, 1.2f);
        Slide.Play(0);

        Invoke("StartGameStep5", 0.5f);
    }

    void StartGameStep4()
    {
        TransitionScreen.transform.position = Vector3.Lerp(TransitionScreen.transform.position, new Vector3(0, -116, 90), 0.1f);
    }

    void StartGameStep5()
    {
        CancelInvoke();
    }

    void BackToStartScreenStep1()
    {
        GameOverScreen.transform.position = Vector3.Lerp(GameOverScreen.transform.position, new Vector3(0, -116, 90), 0.1f);
    }

    void BackToStartScreenStep2()
    {
        CancelInvoke();
    }
}
