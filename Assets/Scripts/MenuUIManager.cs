using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Text highestScoreText;
    [SerializeField] private InputField inputName;

    private int mainSceneIndex = 1;
    private int highScoreSceneIndex = 2;


    private void Awake()
    {
        GameManager.Instance.Load();
        if (GameManager.Instance.bestPlayer1 != "") highestScoreText.text = $"Highest Score: {GameManager.Instance.bestPlayer1} = {GameManager.Instance.highScore1}";
        else highestScoreText.text = "No highscore set";
    }

    public void ViewHighScores()
    {
        SceneManager.LoadScene(highScoreSceneIndex);
    }

    public void StartGame()
    {
        if (inputName.text != "")
        {
            GameManager.Instance.currentPlayer = inputName.text;
            SceneManager.LoadScene(mainSceneIndex);
        }
        else inputName.text = "NO NAME";
    }

    public void QuitGame()
    {
        GameManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
