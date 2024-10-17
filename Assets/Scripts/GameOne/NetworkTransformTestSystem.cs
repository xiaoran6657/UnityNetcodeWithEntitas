using Entitas;
using Unity.Netcode;
using UnityEngine;

public class NetworkTransformTestSystem : IExecuteSystem
{
    private Contexts _contexts;
    private PhysicsObjectView _physicsObjectView;

    public NetworkTransformTestSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var tick = NetworkManager.Singleton.NetworkTickSystem.ServerTime.Tick;
        var group = _contexts.game.GetGroup(GameMatcher.NetworkPosition);
        foreach (var e in group)
        {
            // 如果是客户端的实体，则进行插值
            // if is a client entity, we interpolate the position, because the remote data is dispersed
            if (e.isClient)
            {
                var remotePosition = e.networkPosition.Value.Get();
                var localPosition = e.localPosition.Value.Get();
                var lerpPosition = Vector3.Lerp(localPosition, remotePosition, 0.2f);
                e.networkPosition.Value.Set(lerpPosition);
            }
            else
            {
                e.networkPosition.Value.Set(new Vector3(2 * Mathf.Cos(tick * 0.1f), 2 * Mathf.Sin(tick * 0.1f), 0));
            }
        }
    }
}