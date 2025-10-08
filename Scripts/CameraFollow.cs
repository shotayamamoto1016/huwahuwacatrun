using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //カメラがプレイヤーを追従する仕組みを実装
    public Transform target;

    //カメラがどの位置で配置するか決めるオフセット
    //カメラがプレイヤの前に配置されないようにz軸を負の値に設定
    public Vector3 offset = new Vector3(0, 2, -10);
   
    //LateUpdate()はUpdate()の後に毎フレーム呼ばれる
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = target.position + offset;
            //カメラが上下しすぎないように制御する
            //Clamp(value, min, max) は、指定範囲に制限する関数
            newPos.y = Mathf.Clamp(newPos.y, 0f, 10f);
            //カメラの位置を更新する
            transform.position = newPos;
        }
    }
}
