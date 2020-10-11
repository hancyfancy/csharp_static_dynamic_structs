using System;
using System.Reflection;

public class DynamicStore<T> : ItemStore<T>, IInsertable<T>, IOneDimensionIterable<T>, IOneDimensionStorable<T>
{
    public DynamicStore() : base()
    {
        base.Items = new Item<T>[]{};
    }
    internal Int32 GetIndex(Item<T> item)
    {
        Int32 index = -1;
        Item<T>[] items = base.Items;
        for (Int32 i = 0; i < items.Length; i++)
        {
            if (items[i].Equals(item))
            {
                index = i;
                break;
            }
        }
        return index;
    }
    public Int32 GetIndex(T obj)
    {
        return this.GetIndex(new Item<T>(obj));
    }
    private Item<T> GetCurrentItem()
    {
        return base.Items[base.CurrentIndex];
    }
    internal virtual void SetItem(Item<T> newItem)
    {
        Item<T>[] newItems = null;
        Int32 currentIndex = base.CurrentIndex;
        Item<T>[] items = base.Items;
        Int32 itemsLength = items.Length;
        newItems = new Item<T>[itemsLength + 1];
        for (Int32 i = 0; i < itemsLength; i++)
        {
            Item<T> currentItem = items[i];
            if (currentItem != null)
            {
                newItems[i] = currentItem;
            }
        }
        newItems[currentIndex] = newItem;
        base.Items = newItems;
        base.CurrentIndex = currentIndex + 1;
    }
    public void Add(T toBeAdded)
    {
        this.SetItem(new Item<T>(toBeAdded));
    }
    private void ReplaceItem(Int32 index, Item<T> newItem)
    {
        Item<T>[] items = Items;
        if (items[index] != null)
        {
            items[index] = newItem;
        }
        base.Items = items;
    }
    public void Replace(Int32 index, T toBeReplaced)
    {
        this.ReplaceItem(index, new Item<T>(toBeReplaced)); 
    }
    private void InsertItem(Int32 index, Item<T> newItem)
    {
        Item<T>[] newItems = null;
        Item<T>[] items = Items;
        Int32 itemsLength = items.Length;
        if (index > -1)
        {
            if (index == itemsLength)
            {
                base.CurrentIndex = itemsLength;
                SetItem(newItem);
            }
            else if (index > itemsLength)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                throw new ArgumentException(m.ReflectedType.Name + "." + m.Name + ": Index must be less than or equal to length of Dynamic Store.", "index");
            }
            else
            {
                newItems = new Item<T>[itemsLength+1];
                if (index == 0)
                {
                    newItems[index] = newItem;
                    for (Int32 i = index+1; i < newItems.Length; i++)
                    {
                        newItems[i] = items[i-1];
                    }
                }
                else
                { //index > 0 && index < itemsLength
                    for (Int32 j = 0; j < index; j++)
                    {
                        newItems[j] = items[j];
                    }
                    newItems[index] = newItem;
                    for (Int32 k = index; k < items.Length; k++)
                    {
                        newItems[k+1] = items[k];
                    }
                }
                base.Items = newItems;
            }
        }
        else
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            throw new ArgumentException(m.ReflectedType.Name + "." + m.Name + ": Index must be non negative.", "index");
        }
    }
    public void Insert(Int32 index, T toBeInserted)
    {
        this.InsertItem(index, new Item<T>(toBeInserted));
    }
}
