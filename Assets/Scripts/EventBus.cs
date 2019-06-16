using System;
using UnityEngine;

public class EventBus
{
    private event Action action;

    public void Connect(Action unityAction)
    {
        action += unityAction;
    }

    public void Disconnect(Action unityAction)
    {
        action -= unityAction;
    }

    public void Clear()
    {
        action = null;
    }

    public void Invoke()
    {
        var copy = action;
        action.Invoke();
    }
}

public class EventBus<T0>
{
    private event Action<T0> action;

    public void Connect(Action<T0> unityAction)
    {
        action += unityAction;
    }

    public void Disconnect(Action<T0> unityAction)
    {
        action -= unityAction;
    }

    public void Clear()
    {
        action = null;
    }

    public void Invoke(T0 t0)
    {
        var copy = action;
        action.Invoke(t0);
    }
}

public class EventBus<T0, T1>
{
    private event Action<T0, T1> action;

    public void Connect(Action<T0,T1> unityAction)
    {
        action += unityAction;
    }

    public void Disconnect(Action<T0,T1> unityAction)
    {
        action -= unityAction;
    }

    public void Clear()
    {
        action = null;
    }

    public void Invoke(T0 t0, T1 t1)
    {
        var copy = action;
        action.Invoke(t0, t1);
    }
}

public class EventBus<T0, T1, T2>
{
    private event Action<T0, T1, T2> action;

    public void Connect(Action<T0, T1, T2> unityAction)
    {
        action += unityAction;
    }

    public void Disconnect(Action<T0, T1, T2> unityAction)
    {
        action -= unityAction;
    }

    public void Clear()
    {
        action = null;
    }

    public void Invoke(T0 t0, T1 t1, T2 t2)
    {
        var copy = action;
        action.Invoke(t0, t1, t2);
    }
}

public class EventBus<T0, T1, T2, T3>
{
    private event Action<T0, T1, T2, T3> action;

    public void Connect(Action<T0, T1, T2, T3> unityAction)
    {
        action += unityAction;
    }

    public void Disconnect(Action<T0, T1, T2, T3> unityAction)
    {
        action -= unityAction;
    }

    public void Clear()
    {
        action = null;
    }

    public void Invoke(T0 t0, T1 t1, T2 t2, T3 t3)
    {
        var copy = action;
        action.Invoke(t0, t1, t2, t3);
    }
}

public interface IEventBus
{
    void Clear();
}

public class ProjectileEventBus : IEventBus
{
    public static readonly EventBus<AudioType> Shoot = new EventBus<AudioType>();

    public void Clear()
    {
        Shoot.Clear();
    }
}