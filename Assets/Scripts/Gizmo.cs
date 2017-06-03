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

        // 自身からN極への変位ベクトル
        Vector3 vectorSelfToNorthPole = northPole.transform.transform.position - transform.transform.position;
        // N極によるクーロン力
        Vector3 forceByNorthPole = vectorSelfToNorthPole.normalized / vectorSelfToNorthPole.sqrMagnitude;
        // 自身からS極への変位ベクトル
        Vector3 vectorSelfToSouthPole = southPole.transform.transform.position - transform.transform.position;
        // S極によるクーロン力
        Vector3 forceBySouthPole = -vectorSelfToSouthPole.normalized / vectorSelfToSouthPole.sqrMagnitude;
        // クーロン力の合力
        Vector3 forceResultant = forceByNorthPole + forceBySouthPole;
        // コンパスの向きを設定する
        transform.LookAt(transform.transform.position + forceResultant);
        // コンパスの透明度を設定する
        // まだ
    }
}