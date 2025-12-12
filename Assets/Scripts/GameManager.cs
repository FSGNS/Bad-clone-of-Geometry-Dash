using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool gameEnded = false;

    private GameObject redWinFlag;
    private GameObject blueWinFlag;
    private GameObject endScreen;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        redWinFlag = GameObject.FindGameObjectWithTag("RedWin");
        blueWinFlag = GameObject.FindGameObjectWithTag("BlueWin");
        endScreen = GameObject.FindGameObjectWithTag("EndScreen");

        if (redWinFlag != null) redWinFlag.SetActive(false);
        if (blueWinFlag != null) blueWinFlag.SetActive(false);
        if (endScreen != null) endScreen.SetActive(false);
    }

    public void PlayerDied(string deadPlayerTag)
    {
        if (gameEnded) return;
        gameEnded = true;

        string winnerTag = deadPlayerTag == "Player1" ? "Player2" : "Player1";
        Debug.Log(winnerTag + " победил!");

        if (endScreen != null)
        {
            endScreen.SetActive(true);

            if (winnerTag == "Player1" && redWinFlag != null)
            {
                redWinFlag.SetActive(true);
            }
            else if (winnerTag == "Player2" && blueWinFlag != null)
            {
                blueWinFlag.SetActive(true);
            }
        }
    }
}