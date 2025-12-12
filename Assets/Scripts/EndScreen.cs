using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject PlayerRed;
    public GameObject PlayerBlue;

    private GameObject redWinFlag;
    private GameObject blueWinFlag;
    private GameObject endScreen;

    void Start()
    {
        redWinFlag = GameObject.FindGameObjectWithTag("RedWin");
        blueWinFlag = GameObject.FindGameObjectWithTag("BlueWin");
        endScreen = GameObject.FindGameObjectWithTag("EndScreen");
    }

    void Update()
    {
        if (PlayerRed == null)
        {
            EndGame("Blue");
        }
        else if (PlayerBlue == null)
        {
            EndGame("Red");
        }
    }

    void EndGame(string winner)
    {
        if (winner == "Red" && redWinFlag != null)
        {
            redWinFlag.SetActive(true);
        }
        else if (winner == "Blue" && blueWinFlag != null)
        {
            blueWinFlag.SetActive(true);
        }

        if (endScreen != null)
        {
            endScreen.SetActive(true);
        }
    }
}