using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private SimplePlayerScript playerScript;

    [SerializeField] public int counter = 0;
    [SerializeField] private UIManager uiManager;
    [SerializeField] int winCondition = 1;


    private void Start()
    {
        counter = 0;
        uiManager.UpdateCoinText(counter);
    }

    public void AddCoin()
    {
        counter++;
        uiManager.UpdateCoinText(counter);
        
        if (counter >= winCondition)
        {
            uiManager.ShowPanelWin();
            playerScript.canMove = false;
            
        }
        
    }   
}   