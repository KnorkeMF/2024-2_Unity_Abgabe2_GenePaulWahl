using TMPro;
using Unity.Mathematics;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class SimplePlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    private Vector3 direction = new Vector3(x: 0f, y: 0 ,z:0);

    [SerializeField] private CoinManager coinManager;
    [SerializeField] UIManager uiManager;
    
    private Animator animator;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    
    public bool canMove = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //----------------Bewegeung--------------------
        if (canMove)
        {
            
            transform.position += direction.normalized * speed * Time.deltaTime;
            direction = Vector3.zero;

            if (Keyboard.current.wKey.isPressed)
            {
                // direction = new Vector3(x: 0f, y: 1f);
                direction.y = 1;
            }
            
            if (Keyboard.current.aKey.isPressed)
            {
                //direction = new Vector3(x: -1f, y: 0f);
                direction.x = -1;
            } 
            if (Keyboard.current.sKey.isPressed)
            {
                //direction = new Vector3(x: 0f, y: -1f);
                direction.y = -1;
            } 
            
            if (Keyboard.current.dKey.isPressed)
            {
                //direction = new Vector3(x: 1f, y: 0f);
                direction.x = 1;
            }
        }
        
        
        animator.SetFloat(_horizontal, direction.x);
        animator.SetFloat(_vertical, direction.y);
        if (direction != Vector3.zero)
        {
            animator.SetFloat(_lastHorizontal, direction.x);
            animator.SetFloat(_lastVertical, direction.y);
        }
 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log(message: "wir sind kollidiert");

        if (other.CompareTag("coin"))
        {
            Debug.Log(message: "mit einer Münze " );
            Destroy(other.gameObject);
            coinManager.AddCoin();  
        }

        if (other.CompareTag("obstacle"))
        {
            Debug.Log(message: "Es war ein obstacle");
            uiManager.ShowPanelLost();
            canMove = false;
        }
        
        if (other.CompareTag("uitrigger"))
        {
            Debug.Log(message: "mit dem uitrigger" );
            Destroy(other.gameObject);
            uiManager.HidePanelProtocol();  
        }
        
    }
}

