using System;
using System.Reflection;

public class StaticStore<T> : ItemStore<T>, IOneDimensionIterable<T>, IOneDimensionStorable<T>
{
    private Int32 _length;
    public StaticStore(Int32 length) : base()
    {
        Length = length;
        base.Items = new Item<T>[length];
    }
    public override Int32 Length
    {
        get
        {
            return _length;
        }
        set
        {
            if (value > 0)
            {
                _length = value;
            }
            else
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                throw new InvalidOperationException(m.ReflectedType.Name + "." + m.Name + ": Length of static store must be greater than zero.");
            }
        }
    }
    private Int32 GetIndex(Item<T> item)
    {
        Int32 index = -1;
        Item<T>[] items = base.Items;
        for (int i = 0; i < Length; i++)
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
        return GetIndex(new Item<T>(obj));
    }
    private Item<T> GetCurrentItem()
    {
        return base.Items[base.CurrentIndex];
    }
    private void SetItem(Item<T> newItem)
    {
        Int32 currentIndex = base.CurrentIndex;
        Item<T>[] items = base.Items;
        if (currentIndex < Length)
        {
            if (items[currentIndex] == null)
            {
                items[currentIndex] = newItem;
            }
            else
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                throw new InvalidOperationException(m.ReflectedType.Name + "." + m.Name + ": Length of static store is " + Convert.ToString(Length) + ", cannot add extra items.");
            }
        }
        base.Items = items;
        Int32 nextIndex = currentIndex + 1;
        if (nextIndex < Length) {
            base.CurrentIndex = nextIndex;
        }
    }
    public void Add(T toBeAdded)
    {
        this.SetItem(new Item<T>(toBeAdded));
    }
    private void ReplaceItem(Int32 index, Item<T> newItem)
    {
        if (index < Length)
        {
            Item<T>[] items = Items;
            if (items[index] != null)
            {
                items[index] = newItem;
            }
            else
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                throw new InvalidOperationException(m.ReflectedType.Name + "." + m.Name + ": Null items cannot be replaced, try adding instead.");
            }
            base.Items = items;
        }
    }
    public void Replace(Int32 index, T toBeReplaced)
    {
        this.ReplaceItem(index, new Item<T>(toBeReplaced)); 
    }
}
