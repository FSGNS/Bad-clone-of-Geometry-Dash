using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownWithTimeScale : MonoBehaviour
{
    [Header("Настройки отсчета")]
    public float countdownDuration = 3f;
    public bool showDebugLogs = true;

    [Header("UI элементы")]
    public TextMeshProUGUI countdownText;
    public GameObject countdownPanel;

    private bool gameStarted = false;

    void Start()
    {
        if (countdownPanel != null)
            countdownPanel.SetActive(true);

        Time.timeScale = 0f;

        StartCoroutine(CountdownSequence());
    }

    IEnumerator CountdownSequence()
    {
        ShowNumber("3");
        yield return new WaitForSecondsRealtime(1f);

        ShowNumber("2");
        yield return new WaitForSecondsRealtime(1f);

        ShowNumber("1");
        yield return new WaitForSecondsRealtime(1f);

        ShowNumber("GO!");
        yield return new WaitForSecondsRealtime(0.5f);

        StartGame();
    }

    void ShowNumber(string number)
    {
        if (countdownText != null)
        {
            countdownText.text = number;

            StartCoroutine(AnimateText(countdownText.transform));
        }

        if (showDebugLogs) Debug.Log(number);
    }

    IEnumerator AnimateText(Transform textTransform)
    {
        textTransform.localScale = Vector3.one * 1.5f;

        yield return new WaitForSecondsRealtime(0.1f);

        textTransform.localScale = Vector3.one;
    }

    void StartGame()
    {
        if (countdownPanel != null)
            countdownPanel.SetActive(false);

        Time.timeScale = 1f;

        gameStarted = true;

        if (showDebugLogs)
            Debug.Log("Игра началась! Time.timeScale восстановлен.");
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }

    void OnDestroy()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}