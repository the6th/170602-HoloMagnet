using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour
{

    public float gizmoSize = 0.3f;
    public Color gizmoColor = Color.yellow;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }

    void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }
}