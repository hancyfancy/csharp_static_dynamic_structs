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
using System.Threading;

public abstract class ItemStore<T> : ISortable<T>
{
    private Int32 _currentIndex;
    private Item<T>[] _items;
    public ItemStore()
    {
        CurrentIndex = 0;
    }
    protected Int32 CurrentIndex
    {
        get
        {
            return _currentIndex;
        }
        set
        {
            _currentIndex = value;
        }
    }
    internal Item<T>[] Items
    {
        get
        {
            return _items;
        }
        set
        {
            _items = value;
        }
    }
    public virtual Int32 Length
    {
        get
        {
            return Items.Length;
        }
        set
        {
            
        }
    }
    internal Item<T> GetItem(Int32 index)
    {
        return Items[index];
    }
    public T Get(Int32 index)
    {
        return GetItem(index).Content;
    }
    internal void ReplaceAllItems(Item<T> newItem)
    {
        Item<T>[] items = Items;
        for (Int32 i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                items[i] = newItem;
            }
            else
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                throw new InvalidOperationException(m.ReflectedType.Name + "." + m.Name + ": Null items cannot be replaced, try adding or inserting instead.");
            }
        }
        Items = items;
    }
    public void ReplaceAll(T toBeReplaced)
    {
        ReplaceAllItems(new Item<T>(toBeReplaced));
    }
    private void Merge(Item<T>[] sortedDivision, Int32 l, Int32 m, Int32 r) {
        Int32 n1 = m - l + 1;
        Int32 n2 = r - m;
        Item<T>[] left = new Item<T>[n1];
        Item<T>[] right = new Item<T>[n2];
        for (Int32 i = 0; i < n1; ++i) {
            left[i] = sortedDivision[l + i];
        }
        for (Int32 j = 0; j < n2; ++j) {
            right[j] = sortedDivision[m + 1 + j];
        }
        Int32 x = 0, y = 0;
        Int32 k = l;
        while (x < n1 && y < n2) {
            if (left[x] > right[y]) {
                sortedDivision[k] = right[y];
                y++;
            } else {
                sortedDivision[k] = left[x];
                x++;
            }
            k++;
        }
        while (x < n1) {
            sortedDivision[k] = left[x];
            x++;
            k++;
        }
        while (y < n2) {
            sortedDivision[k] = right[y];
            y++;
            k++;
        }
    }
    private Item<T>[] MergeSort(Item<T>[] unsortedDivision, Int32 l, Int32 r)
    {
        if (l < r) {
            Int32 m = (l + r) / 2;
            MergeSort(unsortedDivision, l, m);
            MergeSort(unsortedDivision, m + 1, r);
            Merge(unsortedDivision, l, m, r);
        }
        return unsortedDivision;
    }
    public void Sort()
    {
        Item<T>[] unsortedItems = Items;
        Items = MergeSort(Items, 0, Items.Length-1);
    }
    public override String ToString()
    {
        String output = "";
        Item<T>[] items = Items;
        output = output + "[";
        for (Int32 i = 0; i < items.Length; i++)
        {
            output = output + "{Index " + Convert.ToString(i) + ": " + Convert.ToString(items[i]);
            if (i < items.Length - 1)
            {
                output = output + "}, ";
            }
            else
            {
                output = output + "}";
            }
        }
        output = output + "]\n";
        return output;
    }
}
