using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour
{
    /* このオブジェクトを中心に回転する。Pivot。ここから。 */
    public float gizmoSize = 0.3f;
    public Color gizmoColor = Color.yellow;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
    /* このオブジェクトを中心に回転する。Pivot。ここまで。 */

    GameObject northPole;
    GameObject southPole;

    void Start()
    {
         northPole = GameObject.Find("North Pole");
         southPole = GameObject.Find("South Pole");
    }

    private void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 5));
        //transform.LookAt(northPole.transform);
        //Vector3 selfToNorthPole = northPole.transform.transform.position - transform.transform.position; 
        //transform.LookAt(selfToNorthPole);
        transform.LookAt(northPole.transform.transform.position);
    }
}