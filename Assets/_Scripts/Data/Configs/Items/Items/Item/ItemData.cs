using System;
using UnityEngine;

namespace _Scripts.Data.Configs.Items.Items.Item
{
  [Serializable]
  public class ItemDataBase
  {
    public ItemType ItemType;
    public Sprite Icon;
    public float Weight;
    public int Stack;
    public int Count;
  }

  [Serializable]
  public class ItemData<T> : ItemDataBase where T : Enum
  {
    public T SubType;

    public void AddSubType(T subType)
    {
      SubType = subType;
    }
  }
}