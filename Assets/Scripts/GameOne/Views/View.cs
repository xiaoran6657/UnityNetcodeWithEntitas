using Entitas;
using Entitas.Unity;
using Unity.Netcode;
using UnityEngine;

public abstract class UnityView : MonoBehaviour
{
    protected Contexts Contexts;
    protected GameEntity LinkedEntity;

    public virtual void Link(Contexts contexts, GameEntity e)
    {
        Contexts = contexts;
        LinkedEntity = e;
        gameObject.Link(e);
        
    }
    
    public virtual void DestroyView()
    {
        Destroy(gameObject);
    }
}

public abstract class UnityNetworkView : NetworkBehaviour
{
    protected Contexts Contexts;
    protected GameEntity LinkedEntity;

    public virtual void Link(Contexts contexts,GameEntity e)
    {
        Contexts = contexts;
        LinkedEntity = e;
        gameObject.Link(e);
    }
    
    public virtual void DestroyView()
    {
        Destroy(gameObject);
    }
}