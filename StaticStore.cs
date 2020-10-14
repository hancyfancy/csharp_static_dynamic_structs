/*
BSD 3-Clause License

Copyright (c) 2020, hancyfancy
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

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
        if (index == -1)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            throw new ArgumentException(m.ReflectedType.Name + "." + m.Name + ": Specified item does not exist.", "item");
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
