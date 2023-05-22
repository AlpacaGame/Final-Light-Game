using UnityEngine;

public class DetectionSpace : MonoBehaviour
{

    //Ã¸»s¤j·§½d³ò
    public float radius = 1f;
    public Color gizmoColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}