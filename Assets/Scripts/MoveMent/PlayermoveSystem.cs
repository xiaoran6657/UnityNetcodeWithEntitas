using UnityEngine;
using Unity.Netcode;

public class PlayermoveSystem : NetworkBehaviour
{
    private void Update()
    {
        // 获取所有具有 InputRecive 和 MoveController 组件的玩家
        Inputcompont[] inputcomponts = FindObjectsOfType<Inputcompont>();
        Positioncompont[] positioncomponts = FindObjectsOfType<Positioncompont>();

        // 遍历所有玩家
        for (int i = 0; i < inputcomponts.Length; i++)
        {
            Inputcompont inputcompont = inputcomponts[i];
            Positioncompont positioncompont = positioncomponts[i];

            // 检查是否是本地玩家并且有输入
            //if (inputcompont.IsLocalPlayer && inputcompont.inputVector != Vector3.zero && positioncompont.IsOwner)
            if (inputcompont.inputVector != Vector3.zero && positioncompont.IsOwner)
            {
                Debug.Log("IsOwner and inputVector is not zero");
                positioncompont.position += inputcompont.inputVector * positioncompont.moveSpeed * Time.deltaTime;
                positioncompont.transform.position = positioncompont.position;

                // 同步位置到服务器和其他客户端
                positioncompont.Networkposition.Value = positioncompont.position;
            }
        }
    }
}