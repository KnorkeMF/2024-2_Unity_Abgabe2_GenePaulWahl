using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button buttonStartGame;
    [SerializeField] Button buttonQuitGame;
    [SerializeField] Button buttonBack;
    [SerializeField] GameObject mainMenuPanel;
    void Start()
    {
        
        //Button Functions
        buttonStartGame.onClick.AddListener(StartGame);
        buttonQuitGame.onClick.AddListener(QuitGame);
    }


    void StartGame()
    {
        Debug.Log("Startet Game");
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
        Debug.Log("Game has been quit");
        Application.Quit();
    }
}
