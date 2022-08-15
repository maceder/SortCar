// Developed by Ahmet Nazim Macit - 2018

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for other type of messages.
/// Extend any class from Message to customize for own use case
/// </summary>
public class Message {

    /// <summary>
    /// Handler database 
    /// </summary>
    /// <returns></returns>
    private static Dictionary<EventName, List<Delegate>> handlers = new Dictionary<EventName, List<Delegate>> ();

    protected Message () { }

    /// <summary>
    /// Add listener to database
    /// </summary>
    /// <param name="eventName">The name of an event that you want to subscribe for </param>
    /// <param name="callback"> Callback to receive when triggered </param>
    public static void AddListener (EventName eventName, Action callback) {
        registerListener (eventName, callback);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventName">EventName to register</param>
    /// <param name="callback"> Add callback </param>
    /// <typeparam name="T">has to be extended from Message.cs</typeparam>
    public static void AddListener<T> (EventName eventName, Action<T> callback)  {
        registerListener (eventName, callback);
    }

    public static void RemoveListener (EventName eventName, Action callback) {
        unregisterListener (eventName, callback);
    }

    public static void RemoveListener<T> (EventName eventName, Action<T> callback)  {
        unregisterListener (eventName, callback);
    }

    private static void registerListener (EventName eventName, Delegate callback) {
        if (callback == null) {
            Debug.LogError ("Given callback is null");
            return;
        }
        if (!handlers.ContainsKey (eventName))
            handlers.Add (eventName, new List<Delegate> ());

        List<Delegate> allDelegates = handlers[eventName];
        allDelegates.Add (callback);
    }

    private static void unregisterListener (EventName eventName, Delegate callback) {
        if (!handlers.ContainsKey (eventName)) {
            Debug.LogError ("Given callback is null");
            return;
        }

        List<Delegate> allDelegates = handlers[eventName];
        Delegate handler = allDelegates.Find (x => x.Method == callback.Method && x.Target == callback.Target);
        if (handler == null) return;
        allDelegates.Remove (handler);
    }

    public static void Send (EventName eventName) {
        sendMessage<Message> (eventName, null);
    }

    public static void Send<T> (EventName eventName, T message)  {
        if (message == null) Debug.Log (" message is null");

        sendMessage (eventName, message);
    }

    
    private static void sendMessage<T> (EventName eventName, T e)  {
        if (!handlers.ContainsKey (eventName)) return;

        List<Delegate> allHandlers = handlers[eventName];
        Delegate[] handlersArr = allHandlers.ToArray ();

        foreach (Delegate handler in handlersArr) {

            if (typeof (T) == typeof (Message)) {
                var action = (Action) handler;
                action ();
            } else {
                var action = (Action<T>) handler;
                action (e);
            }

        }
    }

    internal static void AddListener(EventName textStoryEnd)
    {
        throw new NotImplementedException();
    }
}