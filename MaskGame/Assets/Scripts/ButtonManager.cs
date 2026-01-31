using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameplayManager GameplayManagerScript;

    public GameObject StartScreen;
    public GameObject GameSpaceScreen;
    public GameObject GameOverScreen;

    public void StartGame()
    {
        StartScreen.SetActive(false);
        GameSpaceScreen.SetActive(true);
    }

    public void Restart()
    {
        GameSpaceScreen.SetActive(true);

        GameplayManagerScript = GameObject.Find("Game Stats").GetComponent<GameplayManager>();
        GameplayManagerScript.RestartStep1();
    }
}
