using UnityEngine;
using Unity.Netcode;

public class Inputcompont : NetworkBehaviour
{
    public Vector3 inputVector; // 存储输入向量

    private void Update()
    {
        // 如果是本地玩家，则获取输入
        if (IsOwner)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            inputVector = new Vector3(h,0,v);
        }
        else
        {
            inputVector = Vector3.zero; // 非本地玩家输入为零
        }
    }
}