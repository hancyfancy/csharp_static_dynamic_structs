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

public abstract class ItemStore<T>
{
    private Int32 _currentIndex;
    private T[] _items;
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
    internal T[] Items
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
    public T Get(Int32 index)
    {
        return Items[index];
    }
    public void ReplaceAll(T newItem)
    {
        T[] items = Items;
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
    public override String ToString()
    {
        String output = "";
        T[] items = Items;
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
