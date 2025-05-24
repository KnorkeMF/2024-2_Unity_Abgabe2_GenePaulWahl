using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading
using UnityEngine.EventSystems;  // Required for UI selection management

public class MenuManager : MonoBehaviour {
    
    
    #region Input declaration

    [Header("_____________PANELS______________")]
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject settingsPanel;

    [HideInInspector] public string notVisibleInInspector = "ich bin unsichtbar im Inspektor.";

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(message: "Make only Main Menu Panel visible");
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true); ;
    }
    
    
    public void OpenMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    
    public void OpenSettingsMenu()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenCreditsMenu()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    
    public void OpenScoreMenu()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    
}