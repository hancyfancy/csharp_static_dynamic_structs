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
using System.Collections.Generic;
using System.Reflection;

public class DynamicStore<T> : ItemStore<T>, IInsertable<T>, IOneDimensionIterable<T>, IOneDimensionStorable<T>
{
    public DynamicStore() : base()
    {
        base.Items = new T[]{};
    }
    public Int32 GetIndex(T item)
    {
        Int32 index = -1;
        T[] items = base.Items;
        for (Int32 i = 0; i < items.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(items[i], item) || (items[i].ToString() == item.ToString()))
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
    private T GetCurrent()
    {
        return base.Items[base.CurrentIndex];
    }
    public virtual void Add(T newItem)
    {
        T[] newItems = null;
        Int32 currentIndex = base.CurrentIndex;
        T[] items = base.Items;
        Int32 itemsLength = items.Length;
        newItems = new T[itemsLength + 1];
        for (Int32 i = 0; i < itemsLength; i++)
        {
            T currentItem = items[i];
            if (currentItem != null)
            {
                newItems[i] = currentItem;
            }
        }
        newItems[currentIndex] = newItem;
        base.Items = newItems;
        base.CurrentIndex = currentIndex + 1;
    }
    public void Replace(Int32 index, T newItem)
    {
        T[] items = Items;
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
    public void Insert(Int32 index, T newItem)
    {
        T[] newItems = null;
        T[] items = Items;
        Int32 itemsLength = items.Length;
        if (index > -1)
        {
            if (index == itemsLength)
            {
                base.CurrentIndex = itemsLength;
                Add(newItem);
            }
            else if (index > itemsLength)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                throw new ArgumentException(m.ReflectedType.Name + "." + m.Name + ": Index must be less than or equal to length of Dynamic Store.", "index");
            }
            else
            {
                newItems = new T[itemsLength+1];
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
}
