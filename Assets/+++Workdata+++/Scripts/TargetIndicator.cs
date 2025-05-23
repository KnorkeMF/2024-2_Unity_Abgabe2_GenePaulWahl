using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform target;
    public float hideDistanceFar = 10f;
    public float hideDistanceNear = 1f;

    void Update()
    {
        var dir = target.position - transform.position;
        float distance = dir.magnitude;

        // Sichtbarkeit basierend auf Entfernung
        bool shouldShow = distance <= hideDistanceFar && distance >= hideDistanceNear;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(shouldShow);
        }

        // Rotation beibehalten
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}