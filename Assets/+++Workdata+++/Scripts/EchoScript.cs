using UnityEngine;
using UnityEngine.UI;


public class EchoScript : MonoBehaviour
{
  public GameObject EchoMask;
  public Transform player;
  public float lifetime = 1f;
  
  private float cooldownTimer = 0f;
  public float cooldownDuration = 3f;
  public Image cooldownBar;
  
  public AudioSource audioSource;
  public AudioClip echoSound;
  
    void Update()
    {
        
        //cooldown timer counts to 0
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0f) cooldownTimer = 0f;
        }
        
        //cooldownbar updater
        cooldownBar.fillAmount = 1f - (cooldownTimer / cooldownDuration);
        
        //echo can be used when cooldown timer is <= 0
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            GameObject echo = Instantiate(EchoMask, player.position, player.rotation, player);
            Destroy(echo, lifetime);
            cooldownTimer = cooldownDuration;
            audioSource.PlayOneShot(echoSound);
        }
    }
}
