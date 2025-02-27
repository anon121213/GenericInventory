using System;
using UnityEngine;

namespace _Scripts.Data.Configs.Items.Items.Item
{
  using UnityEngine;

  public abstract class ItemConfig : ScriptableObject, IConfigWithSubType
  {
    public abstract Enum SubType { get; }
    public abstract ItemDataBase ItemDataBase { get; }
  }

} 