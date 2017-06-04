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
    int _FrameCount = 0;

    void Start()
    {
         northPole = GameObject.Find("North Pole");
         southPole = GameObject.Find("South Pole");
    }

    private void Update()
    {
        _FrameCount++;
        if (_FrameCount < 6) return;
        _FrameCount = 0;

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
        // 磁石のモデルを取得する
        var magnetRed  = transform.GetChild(0);
        var magnetBlue = transform.GetChild(1);

        // 合力の大きさの2乗
        //Debug.Log(forceResultant.sqrMagnitude);
        //Debug.Log((Mathf.Pow(forceResultant.sqrMagnitude, 0.01f) - 2.0f) / 6.0f);
        float a = forceResultant.sqrMagnitude / 200000;

        // シェーダーを取得する
        MeshRenderer meshrenderRed  = magnetRed.GetComponent<MeshRenderer>();
        MeshRenderer meshrenderBlue = magnetBlue.GetComponent<MeshRenderer>();
        // 透明度を変える
        meshrenderRed.material.color  = new Color(a, 0, 0);
        meshrenderBlue.material.color = new Color(0, 0, a);
        
    }
}