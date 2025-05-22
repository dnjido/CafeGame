using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage
{
    public int itemCount { get; private set; }

    public delegate void ChangeCountDelegate(int count);
    public event ChangeCountDelegate ChangeCountEvent;

    public void Add()
    {
        itemCount++;
        ChangeCountEvent?.Invoke(itemCount);
    }

    public void Set(int count)
    {
        itemCount = count;
        ChangeCountEvent?.Invoke(itemCount);
    }
}
