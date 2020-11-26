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

public class TwoDimensionSorter<K,V> : ITwoDimensionSortable<K,V>
{    
    private DynamicMap<K,V> _map;
    private ItemSingularSorter<K> _singularKeySorter;
    private ItemSingularSorter<V> _singularValueSorter;
    private ItemParallelSorter<K> _parallelKeySorter;
    private ItemParallelSorter<V> _parallelValueSorter;
    public TwoDimensionSorter(DynamicMap<K,V> newMap)
    {
        Map = newMap;
    }
    protected DynamicMap<K,V> Map
    {
        get
        {
            return _map;
        }
        set
        {
            _map = value;
        }
    }
    private ItemSingularSorter<K> SingularKeySorter
    {
        get
        {
            return _singularKeySorter;
        }
        set
        {
            _singularKeySorter = value;
        }
    }
    private ItemSingularSorter<V> SingularValueSorter
    {
        get
        {
            return _singularValueSorter;
        }
        set
        {
            _singularValueSorter = value;
        }
    }
    private ItemParallelSorter<K> ParallelKeySorter
    {
        get
        {
            return _parallelKeySorter;
        }
        set
        {
            _parallelKeySorter = value;
        }
    }
    private ItemParallelSorter<V> ParallelValueSorter
    {
        get
        {
            return _parallelValueSorter;
        }
        set
        {
            _parallelValueSorter = value;
        }
    }
    public void Sort(TwoDimensionConstants by)
    {
        DynamicUniqueStore<K> keys = Map.Keys;
        DynamicStore<V> values = Map.Values;
        Int32[] sortedIndices = new Int32[Map.Length];
        if (by == TwoDimensionConstants.KEY)
        {
            DynamicUniqueStore<K> originalKeys = new DynamicUniqueStore<K>();
            for (Int32 i = 0; i < Map.Length; i++)
            {
                originalKeys.Add(keys.Get(i));
            }
            SingularKeySorter = new ItemSingularSorter<K>(Map.Keys.Items);
            Map.Keys.Items = SingularKeySorter.MergeSort(0, Map.Length-1);
            for (Int32 i = 0; i < Map.Length; i++)
            {
                sortedIndices[i] = originalKeys.GetIndex(keys.Get(i));
            }
            DynamicStore<V> sortedValues = new DynamicStore<V>();
            for (Int32 j = 0; j < Map.Length; j++)
            {
                sortedValues.Add(values.Get(sortedIndices[j]));
            }
            Map.Values = sortedValues;
        }
        else if (by == TwoDimensionConstants.VALUE)
        {
            DynamicStore<V> originalValues = new DynamicStore<V>();
            for (Int32 i = 0; i < Map.Length; i++)
            {
                originalValues.Add(values.Get(i));
            }
            SingularValueSorter = new ItemSingularSorter<V>(Map.Values.Items);
            Map.Values.Items = SingularValueSorter.MergeSort(0, Map.Length-1);
            for (Int32 i = 0; i < Map.Length; i++)
            {
                sortedIndices[i] = originalValues.GetIndex(values.Get(i));
            }
            DynamicUniqueStore<K> sortedKeys = new DynamicUniqueStore<K>();
            for (Int32 j = 0; j < Map.Length; j++)
            {
                sortedKeys.Add(keys.Get(sortedIndices[j]));
            }
            Map.Keys = sortedKeys;
        } 
    }
    public void ParallelSort(TwoDimensionConstants by)
    {
        DynamicUniqueStore<K> keys = Map.Keys;
        DynamicStore<V> values = Map.Values;
        Int32[] sortedIndices = new Int32[Map.Length];
        if (by == TwoDimensionConstants.KEY)
        {
            DynamicUniqueStore<K> originalKeys = new DynamicUniqueStore<K>();
            for (Int32 i = 0; i < Map.Length; i++)
            {
                originalKeys.Add(keys.Get(i));
            }
            ParallelKeySorter = new ItemParallelSorter<K>(Map.Keys.Items);
            Map.Keys.Items = ParallelKeySorter.MergeSort(0, Map.Length-1);
            for (Int32 i = 0; i < Map.Length; i++)
            {
                sortedIndices[i] = originalKeys.GetIndex(keys.Get(i));
            }
            DynamicStore<V> sortedValues = new DynamicStore<V>();
            for (Int32 j = 0; j < Map.Length; j++)
            {
                sortedValues.Add(values.Get(sortedIndices[j]));
            }
            Map.Values = sortedValues;
        }
        else if (by == TwoDimensionConstants.VALUE)
        {
            DynamicStore<V> originalValues = new DynamicStore<V>();
            for (Int32 i = 0; i < Map.Length; i++)
            {
                originalValues.Add(values.Get(i));
            }
            ParallelValueSorter = new ItemParallelSorter<V>(Map.Values.Items);
            Map.Values.Items = ParallelValueSorter.MergeSort(0, Map.Length-1);
            for (Int32 i = 0; i < Map.Length; i++)
            {
                sortedIndices[i] = originalValues.GetIndex(values.Get(i));
            }
            DynamicUniqueStore<K> sortedKeys = new DynamicUniqueStore<K>();
            for (Int32 j = 0; j < Map.Length; j++)
            {
                sortedKeys.Add(keys.Get(sortedIndices[j]));
            }
            Map.Keys = sortedKeys;
        }
    }
}
