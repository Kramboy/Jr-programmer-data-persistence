using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHighestScoresManager : MonoBehaviour
{
    [SerializeField] private Text playerListText;

    private int menuSceneIndex = 0;

    private void Awake()
    {
        playerListText.text = 
            $"{GameManager.Instance.bestPlayer1} = {GameManager.Instance.highScore1}\n" +
            $"{GameManager.Instance.bestPlayer2} = {GameManager.Instance.highScore2}\n" +
            $"{GameManager.Instance.bestPlayer3} = {GameManager.Instance.highScore3}";
    }

    public void GoBack()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }
}
