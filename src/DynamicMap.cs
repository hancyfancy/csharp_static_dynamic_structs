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

public class DynamicMap<K,V> : ITwoDimensionIterable<K,V>, ITwoDimensionStorable<K,V>
{
    private DynamicUniqueStore<K> _keys;
    private DynamicStore<V> _values;
    public DynamicMap()
    {
        Keys = new DynamicUniqueStore<K>();
        Values = new DynamicStore<V>();
    }
    internal DynamicUniqueStore<K> Keys
    {
        get
        {
            return _keys;
        }
        set
        {
            _keys = value;
        }
    }
    internal DynamicStore<V> Values
    {
        get
        {
            return _values;
        }
        set
        {
            _values = value;
        }
    }
    public Int32 Length
    {
        get
        {
            return Keys.Length;
        }
    }
    public Int32 GetKeyIndex(K key)
    {
        return Keys.GetIndex(key);
    }
    public Int32 GetValueIndex(V val)
    {
        return Values.GetIndex(val);
    }
    public K GetKeyAtPosition(Int32 index)
    {
        if ((index > -1) && (index < Length))
        {
            return Keys.Get(index);
        }
        else
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            throw new ArgumentException(m.ReflectedType.Name + "." + m.Name + ": Index must be non negative and less than length of Dynamic Map.", "index");
        }
    }
    public V GetValueAtPosition(Int32 index)
    {
        if ((index > -1) && (index < Length))
        {
            return Values.Get(index);
        }
        else
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            throw new ArgumentException(m.ReflectedType.Name + "." + m.Name + ": Index must be non negative and less than length of Dynamic Map.", "index");
        }
    }
    public K GetKey(V val)
    {
        K key = default(K);
        Int32 indexOfVal = GetValueIndex(val);
        if (Values.Length > indexOfVal)
        {
            key = GetKeyAtPosition(indexOfVal);
        }
        return key;
    }
    public V GetValue(K key)
    {
        V val = default(V);
        Int32 indexOfKey = GetKeyIndex(key);
        if (Keys.Length > indexOfKey)
        {
            val = GetValueAtPosition(indexOfKey);
        }
        return val;
    }
    public void Add(K key, V val)
    {
        Keys.Add(key);
        Int32 indexOfKey = GetKeyIndex(key);
        if (Keys.Length > indexOfKey)
        {
            try
            {
                Values.Replace(indexOfKey, val);
            }
            catch (Exception e)
            {
                if (e is IndexOutOfRangeException || e is InvalidOperationException)
                {
                    Values.Add(val);
                }
            }
        }
    }
    public override String ToString()
    {
        String output = "";
        for (Int32 i = 0; i < Length; i++)
        {
            output = output + "Index " + Convert.ToString(i) + ": Key -> " + Convert.ToString(GetKeyAtPosition(i)) + ", Value -> " + Convert.ToString(GetValueAtPosition(i)) + "\n";
        }
        return output;
    }
}
