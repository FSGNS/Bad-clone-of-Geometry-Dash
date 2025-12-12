using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject selectCountPlayers;

    public static int playersCount = 1;
    private string OnePlayer = "OnePlayer";
    private string TwoPlayers = "TwoPlayers";
    private string GoToMenu = "Menu";

    void Start()
    {
        if (menuPanel != null)
            menuPanel.SetActive(true);

        if (selectCountPlayers != null)
            selectCountPlayers.SetActive(false);
    }

    public void Back()
    {
        if (menuPanel != null)
            menuPanel.SetActive(true);

        if (selectCountPlayers != null)
            selectCountPlayers.SetActive(false);
    }

    public void StartGame()
    {
        if (menuPanel != null)
            menuPanel.SetActive(false);

        if (selectCountPlayers != null)
            selectCountPlayers.SetActive(true);
    }

    public void SelectOnePlayer()
    {
        playersCount = 1;
        PlayWithSelectedPlayers(OnePlayer);
    }

    public void SelectTwoPlayers()
    {
        playersCount = 2;
        PlayWithSelectedPlayers(TwoPlayers);
    }

    private void PlayWithSelectedPlayers(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Game is out");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(GoToMenu);
    }
}