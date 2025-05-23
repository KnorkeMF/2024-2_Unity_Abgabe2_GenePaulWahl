using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button buttonStartGame;
    [SerializeField] Button buttonQuitGame;
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
        SceneManager.UnloadSceneAsync("MainMenuScene");
    }

    void QuitGame()
    {
        Debug.Log("Game has been quit");
        Application.Quit();
    }
}
