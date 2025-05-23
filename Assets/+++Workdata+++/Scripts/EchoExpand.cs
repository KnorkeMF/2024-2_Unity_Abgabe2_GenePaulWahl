using UnityEngine;

public class EchoExpand : MonoBehaviour
{
    public float expandSpeed = 3f;

    void Update()
    {
        transform.localScale += Vector3.one * expandSpeed * Time.deltaTime;
    }
}