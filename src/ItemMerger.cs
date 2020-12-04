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

internal class ItemMerger<T>
{
    private T[] _unmergedItems;
    protected ItemMerger(T[] newArray)
    {
        UnmergedItems = newArray;
    }
    protected T[] UnmergedItems
    {
        get
        {
            return _unmergedItems;
        }
        set
        {
            _unmergedItems = value;
        }
    }
    protected void Merge(Int32 l, Int32 m, Int32 r)
    {
        T[] sortedDivision = UnmergedItems;
        Int32 n1 = m - l + 1;
        Int32 n2 = r - m;
        T[] left = new T[n1];
        T[] right = new T[n2];
        for (Int32 i = 0; i < n1; ++i) {
            left[i] = sortedDivision[l + i];
        }
        for (Int32 j = 0; j < n2; ++j) {
            right[j] = sortedDivision[m + 1 + j];
        }
        Int32 x = 0, y = 0;
        Int32 k = l;
        while (x < n1 && y < n2) {
            if (Comparer<T>.Default.Compare(left[x], right[y]) > 0) {
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
}
