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

    private string mainSceneName = "main";


    private void Awake()
    {
        GameManager.Instance.Load();
        if (GameManager.Instance.bestPlayer != "") highestScoreText.text = $"Highest Score: {GameManager.Instance.bestPlayer} = {GameManager.Instance.highScore}";
        else highestScoreText.text = "No highscore set";
    }

    public void StartGame()
    {
        if (inputName.text != "")
        {
            GameManager.Instance.currentPlayer = inputName.text;
            SceneManager.LoadScene(mainSceneName);
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
