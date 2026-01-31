using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameplayManager GameplayManagerScript;

    public GameObject StartScreen;
    public GameObject GameSpaceScreen;
    public GameObject TransitionScreen;

    public void StartGame()
    {
        InvokeRepeating("StartGameStep1", 0f, 0.01f);
        Invoke("StartGameStep2", 0.6f);
    }

    public void Restart()
    {
        GameSpaceScreen.SetActive(true);

        GameplayManagerScript = GameObject.Find("Game Stats").GetComponent<GameplayManager>();
        GameplayManagerScript.RestartStep1();
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
        Invoke("StartGameStep5", 0.5f);
    }

    void StartGameStep4()
    {
        TransitionScreen.transform.position = Vector3.Lerp(TransitionScreen.transform.position, new Vector3(0, -116, 90), 0.1f);
        Debug.Log("3");

    }

    void StartGameStep5()
    {
        CancelInvoke();
    }
}
