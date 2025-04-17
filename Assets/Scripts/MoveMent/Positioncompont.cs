using UnityEngine;
using Unity.Netcode;

public class Positioncompont : NetworkBehaviour
{
    public float moveSpeed = 10f; // 移动速度
    public Vector3 position;     // 当前位置

    public NetworkVariable<Vector3> Networkposition = new NetworkVariable<Vector3>(Vector3.zero);

    private void Update()
    {
        // 如果不是本地玩家，则从网络变量获取位置并应用
        if (!IsOwner)
        {
            transform.position = Networkposition.Value;
        }
    }
}