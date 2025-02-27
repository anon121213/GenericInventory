using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Data.Configs.Items.Items.Item;

namespace _Scripts.Gameplay.Items.PlayerBackpack
{
  public class Backpack : IBackpack
  {
    private readonly Dictionary<ItemType, Dictionary<object, List<ItemStack>>> _items = new();

    public bool TryAddItem<T>(ItemType type, T subType, int count, ItemDataBase itemData, out List<ItemStack> stacks)
      where T : Enum
    {
      stacks = null;
      if (!_items.TryGetValue(type, out var subTypeDict))
        _items[type] = subTypeDict = new Dictionary<object, List<ItemStack>>();

      if (!subTypeDict.TryGetValue(subType, out stacks))
        subTypeDict[subType] = stacks = new List<ItemStack>();

      int remainingCount = count;

      for (int i = 0; i < stacks.Count && remainingCount > 0; i++)
      {
        int addToStack = Math.Min(stacks[i].StackSize - stacks[i].Count, remainingCount);

        if (addToStack <= 0)
          continue;

        stacks[i].Weight = ((stacks[i].Weight * stacks[i].Count) + (itemData.Weight * addToStack)) /
                           (stacks[i].Count + addToStack);
        stacks[i].Count += addToStack;
        remainingCount -= addToStack;
      }

      while (remainingCount > 0)
      {
        int addToStack = Math.Min(remainingCount, itemData.Stack);
        stacks.Add(new ItemStack(addToStack, itemData.Stack, itemData.Weight, itemData));
        remainingCount -= addToStack;
      }

      return true; 
    }

    public bool TryRemoveItemCount<T>(ItemType type, T subType, int count, out List<ItemStack> stacks) where T : Enum
    {
      stacks = null;
      if (!_items.TryGetValue(type, out var subTypeDict) || !subTypeDict.TryGetValue(subType, out stacks) ||
          stacks.Count == 0)
        return false; 

      int remainingCount = count;

      for (int i = 0; i < stacks.Count && remainingCount > 0; i++)
      {
        if (stacks[i].Count <= remainingCount)
        {
          remainingCount -= stacks[i].Count;
          stacks.RemoveAt(i--);
        }
        else
        {
          stacks[i].Weight *= (float)(stacks[i].Count - remainingCount) / stacks[i].Count;
          stacks[i].Count -= remainingCount;
          remainingCount = 0;
        }
      }

      if (stacks.Count == 0)
      {
        subTypeDict.Remove(subType);
        if (subTypeDict.Count == 0) _items.Remove(type);
        stacks = null;
      }

      return true; 
    }

    public bool TryGetItemCount<T>(ItemType type, T subType, out int totalCount) where T : Enum
    {
      totalCount = 0;
      return _items.TryGetValue(type, out var subTypeDict) &&
             subTypeDict.TryGetValue(subType, out var stacks) &&
             (totalCount = stacks.Sum(stack => stack.Count)) > 0;
    }

    public bool TryRemoveStack<T>(ItemType type, T subType, int stackIndex) where T : Enum
    {
      if (!_items.TryGetValue(type, out var subTypeDict) || !subTypeDict.TryGetValue(subType, out var stacks) ||
          stackIndex < 0 || stackIndex >= stacks.Count)
        return false;

      stacks.RemoveAt(stackIndex);

      if (stacks.Count == 0)
      {
        subTypeDict.Remove(subType);
        if (subTypeDict.Count == 0) _items.Remove(type);
      }

      return true;
    }
  }

  public class ItemStack
  {
    public int Count;
    public readonly int StackSize;
    public float Weight;
    public ItemDataBase ItemData;

    public ItemStack(int count, int stackSize, float weight, ItemDataBase itemData)
    {
      Count = count;
      StackSize = stackSize;
      Weight = weight;
      ItemData = itemData;
    }
  }
}