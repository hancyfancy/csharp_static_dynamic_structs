using System;

public class DynamicUniqueStore<T> : DynamicStore<T>
{
    public DynamicUniqueStore() : base()
    {
    }

    internal override void SetItem(Item<T> newItem)
    {
        if (base.GetIndex(newItem) == -1) {
            Item<T>[] newItems = null;
            Int32 currentIndex = base.CurrentIndex;
            Item<T>[] items = base.Items;
            Int32 itemsLength = items.Length;
            newItems = new Item<T>[itemsLength + 1];
            for (Int32 i = 0; i < itemsLength; i++) {
                Item<T> currentItem = items[i];
                if (currentItem != null) {
                    newItems[i] = currentItem;
                }
            }
            newItems[currentIndex] = newItem;
            base.Items = newItems;
            base.CurrentIndex = currentIndex + 1;
        }
    }
}
