using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading
using UnityEngine.EventSystems;  // Required for UI selection management

public class PauseManager : MonoBehaviour {
    public GameObject canvasPauseMenu;  // Assign "PausePanel" in Inspector
    private bool paused = false;

    #region Input declaration 
    
    [Header("_____________PANELS______________")]
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject settingsPanel;
    
    #endregion
    void Start() {
        canvasPauseMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
    }

    private void TogglePause() {
        paused = !paused;
        canvasPauseMenu.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;
        Cursor.visible = paused;
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;

        // 🔹 Clear the selected UI element
        if (!paused) {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void Resume() {
        paused = false;
        canvasPauseMenu.SetActive(false);
        Time.timeScale = 1f;

        // 🔹 Properly unlock the cursor
        Cursor.visible = true;  // Ensure it's visible
        Cursor.lockState = CursorLockMode.None;  // Free movement

        // 🔹 Deselect UI to prevent button focus issues
        EventSystem.current.SetSelectedGameObject(null);
    }


    public void ReturnToMainMenu() {
        Time.timeScale = 1f;
        canvasPauseMenu.SetActive(false);

        // 🔹 Clear the selected UI element
        EventSystem.current.SetSelectedGameObject(null);

        SceneManager.LoadScene("MainMenuScene");  // Change to your actual scene name
    }
    
    public void OpenSettingsMenu() {
        paused = true;
        Time.timeScale = 0f;
        canvasPauseMenu.SetActive(false);
        
        // 🔹 Clear the selected UI element
        EventSystem.current.SetSelectedGameObject(null);
        
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    
    public void ReturnToPauseMenu() {
        paused = true;
        Time.timeScale = 0f;
        canvasPauseMenu.SetActive(true);
        
        // 🔹 Clear the selected UI element
        EventSystem.current.SetSelectedGameObject(null);
        
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}