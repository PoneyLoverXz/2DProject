using System;
using UnityEngine;

public class EventBus<T>
{
    private Action<T> action;

    public void Connect(Action<T> unityAction)
    {
        action = unityAction;
    }

    public void Disconnect(Action<T> listener)
    {
        action = null;
    }

    public void Invoke(params object[] args)
    {
        action.DynamicInvoke(args);
    }

    public static readonly EventBus<AudioType> ShootEventBus = new EventBus<AudioType>();
}