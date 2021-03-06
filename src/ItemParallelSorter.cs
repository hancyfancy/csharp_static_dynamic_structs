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
using System.Threading;
using System.Threading.Tasks;

internal class ItemParallelSorter<T> : ItemMerger<T>
{
    private T[] _array;
    private volatile Int32 _threadCount;
    internal ItemParallelSorter(T[] newArray) : base(newArray)
    {
        Array = newArray;
        ThreadCount = 0;
    }
    protected T[] Array
    {
        get
        {
            return _array;
        }
        set
        {
            _array = value;
        }
    }
    private Int32 ThreadCount
    {
        get
        {
            return _threadCount;
        }
        set
        {
            _threadCount = value;
        }
    }
    internal T[] MergeSort(Int32 l, Int32 r)
    {
        T[] unsortedDivision = Array;
        if (l < r)
        {
            Int32 m = (l + r) / 2;
            if (ThreadCount < ConcurrencyConstants.CONCLIMIT)
            {
                Interlocked.Increment(ref _threadCount);
                Parallel.Invoke(() => MergeSort(l, m),() => MergeSort(m + 1, r));
                Interlocked.Decrement(ref _threadCount);
            }
            else
            {
                MergeSort(l, m);
                MergeSort(m + 1, r);
            }
            base.Merge(l, m, r);
        }
        return unsortedDivision;
    }
}
