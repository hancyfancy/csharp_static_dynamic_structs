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
using System.Diagnostics;

public class StructTests
{
	public static void Main()
    {
        Stopwatch sw0 = new Stopwatch();
        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        Random random = new Random();

        Console.WriteLine("--------------------Static store");
        
        IOneDimensionStorable<Byte> staticByteStore = new StaticStore<Byte>(4);
        staticByteStore.Add(Byte.MinValue);
        staticByteStore.Add(Byte.MaxValue);
        staticByteStore.Add(1);
        staticByteStore.Add(8);
        //staticByteStore.Add(5);
        Console.WriteLine(staticByteStore);

        //StaticStore<Int16> staticInvalidShortStore = new StaticStore<Int16>(-1);
        IOneDimensionStorable<Int16> staticShortStore = new StaticStore<Int16>(4);
        staticShortStore.Add(Int16.MinValue);
        staticShortStore.Add(Int16.MaxValue);
        staticShortStore.Add(2);
        staticShortStore.Add(16);
        Console.WriteLine(staticShortStore);

        IOneDimensionStorable<Int32> staticIntegerStore = new StaticStore<Int32>(4);
        staticIntegerStore.Add(Int32.MinValue);
        staticIntegerStore.Add(Int32.MaxValue);
        staticIntegerStore.Add(4);
        staticIntegerStore.Add(32);
        Console.WriteLine(staticIntegerStore);

        IOneDimensionStorable<Int64> staticLongStore = new StaticStore<Int64>(4);
        staticLongStore.Add(Int64.MinValue);
        staticLongStore.Add(Int64.MaxValue);
        staticLongStore.Add(8);
        staticLongStore.Add(64);
        Console.WriteLine(staticLongStore);

        IOneDimensionStorable<Single> staticFloatStore = new StaticStore<Single>(6);
        staticFloatStore.Add(Single.MinValue);
        staticFloatStore.Add(Single.MaxValue);
        staticFloatStore.Add(Single.NegativeInfinity);
        staticFloatStore.Add(Single.PositiveInfinity);
        staticFloatStore.Add(Single.Epsilon);
        staticFloatStore.Add(Single.NaN);
        Console.WriteLine(staticFloatStore);

        IOneDimensionStorable<Double> staticDoubleStore = new StaticStore<Double>(6);
        staticDoubleStore.Add(Double.MinValue);
        staticDoubleStore.Add(Double.MaxValue);
        staticDoubleStore.Add(Double.NegativeInfinity);
        staticDoubleStore.Add(Double.PositiveInfinity);
        staticDoubleStore.Add(Double.Epsilon);
        staticDoubleStore.Add(Double.NaN);
        Console.WriteLine(staticDoubleStore);

        IOneDimensionStorable<Char> staticCharacterStore = new StaticStore<Char>(2);
        staticCharacterStore.Add(Char.MinValue);
        staticCharacterStore.Add(Char.MaxValue);
        Console.WriteLine(staticCharacterStore);

        IOneDimensionStorable<Boolean> staticBooleanStore = new StaticStore<Boolean>(2);
        staticBooleanStore.Add(false);
        staticBooleanStore.Add(true);
        Console.WriteLine(staticBooleanStore);

        IOneDimensionStorable<String> staticStringStore = new StaticStore<String>(4);
        staticStringStore.Add("Fellow");
        staticStringStore.Add("Mellow");
        staticStringStore.Add("Yellow");
        staticStringStore.Add("Bellow");
        Console.WriteLine(staticStringStore);

        IOneDimensionStorable<Object> staticObjectStore = new StaticStore<Object>(2);
        staticObjectStore.Add(null);
        staticObjectStore.Add(new Object());
        Console.WriteLine(staticObjectStore);

        Console.WriteLine("--------------------Static store replace item");

        IOneDimensionStorable<Int32> staticReplacedIntegerStore = new StaticStore<Int32>(4);
        Console.WriteLine(staticReplacedIntegerStore);
        //staticReplacedIntegerStore.ReplaceAll(0);
        //Console.WriteLine(staticReplacedIntegerStore);
        staticReplacedIntegerStore.Add(1);
        //staticReplacedIntegerStore.Replace(1, 7);
        staticReplacedIntegerStore.Add(3);
        staticReplacedIntegerStore.Add(9);
        staticReplacedIntegerStore.Add(5);
        Console.WriteLine(staticReplacedIntegerStore);
        staticReplacedIntegerStore.ReplaceAll(0);
        Console.WriteLine(staticReplacedIntegerStore);
        staticReplacedIntegerStore.Replace(1, 7);
        Console.WriteLine(staticReplacedIntegerStore);
        //Console.WriteLine("Index of 9 = " + Convert.ToString(staticReplacedIntegerStore.GetIndex(9)));
        Console.WriteLine("Item at index 3 = " + Convert.ToString(staticReplacedIntegerStore.Get(3)));

        Console.WriteLine("--------------------Dynamic store");

        IOneDimensionStorable<Byte> dynamicByteStore = new DynamicStore<Byte>();
        dynamicByteStore.Add(Byte.MinValue);
        dynamicByteStore.Add(Byte.MaxValue);
        dynamicByteStore.Add(1);
        dynamicByteStore.Add(8);
        Console.WriteLine(dynamicByteStore);

        IOneDimensionStorable<Int16> dynamicShortStore = new DynamicStore<Int16>();
        dynamicShortStore.Add(Int16.MinValue);
        dynamicShortStore.Add(Int16.MaxValue);
        dynamicShortStore.Add(2);
        dynamicShortStore.Add(16);
        Console.WriteLine(dynamicShortStore);

        IOneDimensionStorable<Int32> dynamicIntegerStore = new DynamicStore<Int32>();
        dynamicIntegerStore.Add(Int32.MinValue);
        dynamicIntegerStore.Add(Int32.MaxValue);
        dynamicIntegerStore.Add(4);
        dynamicIntegerStore.Add(32);
        Console.WriteLine(dynamicIntegerStore);

        IOneDimensionStorable<Int64> dynamicLongStore = new DynamicStore<Int64>();
        dynamicLongStore.Add(Int64.MinValue);
        dynamicLongStore.Add(Int64.MaxValue);
        dynamicLongStore.Add(8);
        dynamicLongStore.Add(64);
        Console.WriteLine(dynamicLongStore);

        IOneDimensionStorable<Single> dynamicFloatStore = new DynamicStore<Single>();
        dynamicFloatStore.Add(Single.MinValue);
        dynamicFloatStore.Add(Single.MaxValue);
        dynamicFloatStore.Add(Single.NegativeInfinity);
        dynamicFloatStore.Add(Single.PositiveInfinity);
        dynamicFloatStore.Add(Single.Epsilon);
        dynamicFloatStore.Add(Single.NaN);
        Console.WriteLine(dynamicFloatStore);

        IOneDimensionStorable<Double> dynamicDoubleStore = new DynamicStore<Double>();
        dynamicDoubleStore.Add(Double.MinValue);
        dynamicDoubleStore.Add(Double.MaxValue);
        dynamicDoubleStore.Add(Double.NegativeInfinity);
        dynamicDoubleStore.Add(Double.PositiveInfinity);
        dynamicDoubleStore.Add(Double.Epsilon);
        dynamicDoubleStore.Add(Double.NaN);
        Console.WriteLine(dynamicDoubleStore);

        IOneDimensionStorable<Char> dynamicCharacterStore = new DynamicStore<Char>();
        dynamicCharacterStore.Add(Char.MinValue);
        dynamicCharacterStore.Add(Char.MaxValue);
        Console.WriteLine(dynamicCharacterStore);

        IOneDimensionStorable<Boolean> dynamicBooleanStore = new DynamicStore<Boolean>();
        dynamicBooleanStore.Add(false);
        dynamicBooleanStore.Add(true);
        Console.WriteLine(dynamicBooleanStore);

        IOneDimensionStorable<String> dynamicStringStore = new DynamicStore<String>();
        dynamicStringStore.Add("Fellow");
        dynamicStringStore.Add("Mellow");
        dynamicStringStore.Add("Yellow");
        dynamicStringStore.Add("Bellow");
        Console.WriteLine(dynamicStringStore);

        IOneDimensionStorable<Object> dynamicObjectStore = new DynamicStore<Object>();
        dynamicObjectStore.Add(null);
        dynamicObjectStore.Add(new Object());
        Console.WriteLine(dynamicObjectStore);

        Console.WriteLine("--------------------Static sorted store");

        Int32 n = 1000000;
        Console.WriteLine("size of array = " + Convert.ToString(n) + "\n");
        Int32[] intArr = new Int32[n];
        IOneDimensionStorable<Int32> staticSortedIntegerStoreOne = new StaticStore<Int32>(n);
        IOneDimensionStorable<Int32> staticSortedIntegerStoreTwo = new StaticStore<Int32>(n);
        for (Int32 i = 0; i < n; i++)
        {
            Int32 rand = random.Next(100000000);
            staticSortedIntegerStoreOne.Add(rand);
            staticSortedIntegerStoreTwo.Add(rand);
            intArr[i] = rand;
        }
        //Console.WriteLine(staticSortedIntegerStoreOne);
        sw0.Start();
        Array.Sort(intArr);
        sw0.Stop();
        Console.WriteLine("Array sort elapsed time: " + Convert.ToString(sw0.ElapsedMilliseconds) + " ms\n");
        IOneDimensionSortable<Int32> staticSortedIntegerStoreOneSingularSorter = new OneDimensionSorter<Int32>(staticSortedIntegerStoreOne);
        sw1.Start();
        staticSortedIntegerStoreOneSingularSorter.Sort();
        sw1.Stop();
        Console.WriteLine("Singular merge sort elapsed time: " + Convert.ToString(sw1.ElapsedMilliseconds) + " ms\n");
        IOneDimensionSortable<Int32> staticSortedIntegerStoreTwoParallelSorter = new OneDimensionSorter<Int32>(staticSortedIntegerStoreTwo);
        sw2.Start();
        staticSortedIntegerStoreTwoParallelSorter.ParallelSort();
        sw2.Stop();
        Console.WriteLine("Parallel merge sort elapsed time: " + Convert.ToString(sw2.ElapsedMilliseconds) + " ms\n");
        //Console.WriteLine(staticSortedIntegerStoreTwo);

        IOneDimensionStorable<String> dynamicSortedStringStore = new DynamicStore<String>();
        dynamicSortedStringStore.Add("Fellow");
        dynamicSortedStringStore.Add("Mellow");
        dynamicSortedStringStore.Add("Yellow");
        dynamicSortedStringStore.Add("Bellow");
        IOneDimensionSortable<String> dynamicSortedStringStoreSingularSorter = new OneDimensionSorter<String>(dynamicSortedStringStore);
        dynamicSortedStringStoreSingularSorter.Sort();
        Console.WriteLine(dynamicSortedStringStore);

        Console.WriteLine("--------------------Dynamic store replace item");
        
        IOneDimensionStorable<Int32> dynamicReplacedIntegerStore = new DynamicStore<Int32>();
        dynamicReplacedIntegerStore.Add(1);
        dynamicReplacedIntegerStore.Add(3);
        //dynamicReplacedIntegerStore.Replace(2, 7);
        dynamicReplacedIntegerStore.Add(9);
        dynamicReplacedIntegerStore.Add(5);
        Console.WriteLine(dynamicReplacedIntegerStore);
        dynamicReplacedIntegerStore.Replace(2, 7);
        Console.WriteLine(dynamicReplacedIntegerStore);

        Console.WriteLine("--------------------Dynamic store insert item");
        //If object implements multiple interfaces and functions from other interfaces are called, object must be instantiator 
        DynamicStore<Int32> dynamicInsertedIntegerStore = new DynamicStore<Int32>();
        dynamicInsertedIntegerStore.Add(1);
        dynamicInsertedIntegerStore.Add(3);
        dynamicInsertedIntegerStore.Add(9);
        dynamicInsertedIntegerStore.Add(5);
        Console.WriteLine(dynamicInsertedIntegerStore);
        dynamicInsertedIntegerStore.Insert(2, 7);
        Console.WriteLine(dynamicInsertedIntegerStore);
        dynamicInsertedIntegerStore.Insert(0, 8);
        Console.WriteLine(dynamicInsertedIntegerStore);
        dynamicInsertedIntegerStore.Insert(6, 4);
        Console.WriteLine(dynamicInsertedIntegerStore);
        //dynamicInsertedIntegerStore.Insert(9, 0);
        //Console.WriteLine(dynamicInsertedIntegerStore);
        //dynamicInsertedIntegerStore.Insert(-1, 6);
        //Console.WriteLine(dynamicInsertedIntegerStore);
        Console.WriteLine("Index of 9 = " + Convert.ToString(dynamicInsertedIntegerStore.GetIndex(9)));
        Console.WriteLine("Item at index 3 = " + Convert.ToString(dynamicInsertedIntegerStore.Get(3)));
        Console.WriteLine();

        Console.WriteLine("--------------------Dynamic unique item store");
        
        IOneDimensionStorable<Int32> dynamicUniqueIntegerStore = new DynamicUniqueStore<Int32>();
        dynamicUniqueIntegerStore.Add(1);
        dynamicUniqueIntegerStore.Add(2);
        dynamicUniqueIntegerStore.Add(1);
        dynamicUniqueIntegerStore.Add(3);
        Console.WriteLine(dynamicUniqueIntegerStore);

        Console.WriteLine("--------------------Dynamic key value store");

        ITwoDimensionStorable<String,Int32> dynamicKeyValueStore = new DynamicMap<String,Int32>();
        dynamicKeyValueStore.Add("Yukon", 8);
        dynamicKeyValueStore.Add("Bicker", 9);
        dynamicKeyValueStore.Add("Shulz", 7);
        dynamicKeyValueStore.Add("Jems", 3);
        Console.WriteLine(dynamicKeyValueStore);

        ITwoDimensionStorable<Int32,IOneDimensionStorable<Int32>> dynamicKeyValueStoreWithListValue = new DynamicMap<Int32,IOneDimensionStorable<Int32>>();
        dynamicKeyValueStoreWithListValue.Add(1, new StaticStore<Int32>(4));
        dynamicKeyValueStoreWithListValue.Add(2, new DynamicStore<Int32>());
        dynamicKeyValueStoreWithListValue.Add(3, new DynamicUniqueStore<Int32>());
        Console.WriteLine(dynamicKeyValueStoreWithListValue);

        Console.WriteLine("--------------------Dynamic sorted key value store");

        ITwoDimensionStorable<Int32,String> dynamicSortedIntegerKeyValueStore = new DynamicMap<Int32,String>();
        dynamicSortedIntegerKeyValueStore.Add(88, "Yukon");
        dynamicSortedIntegerKeyValueStore.Add(832, "Bicker");
        dynamicSortedIntegerKeyValueStore.Add(832, "Blitzer");
        dynamicSortedIntegerKeyValueStore.Add(7, "Shulz");
        dynamicSortedIntegerKeyValueStore.Add(17, "Shulz");
        dynamicSortedIntegerKeyValueStore.Add(3, "Jems");
        ITwoDimensionSortable<Int32,String> dynamicSortedIntegerKeyValueStoreSingularSorter = new TwoDimensionSorter<Int32,String>(dynamicSortedIntegerKeyValueStore);
        dynamicSortedIntegerKeyValueStoreSingularSorter.Sort(TwoDimensionConstants.KEY);
        Console.WriteLine(dynamicSortedIntegerKeyValueStore);
        Console.WriteLine("7 -> " + Convert.ToString(dynamicSortedIntegerKeyValueStore.GetValue(7)));
        //Console.WriteLine("Bicker <- " + Convert.ToString(dynamicSortedIntegerKeyValueStore.GetKey("Bicker")));
        Console.WriteLine("Blitzer <- " + Convert.ToString(dynamicSortedIntegerKeyValueStore.GetKey("Blitzer")));
        Console.WriteLine();

        ITwoDimensionStorable<String,Int32> dynamicSortedStringKeyValueStoreOne = new DynamicMap<String,Int32>();
        ITwoDimensionStorable<String,Int32> dynamicSortedStringKeyValueStoreTwo = new DynamicMap<String,Int32>();
        dynamicSortedStringKeyValueStoreOne.Add("Yukon", 8);
        dynamicSortedStringKeyValueStoreOne.Add("Bicker", 9);
        dynamicSortedStringKeyValueStoreOne.Add("Shulz", 7);
        dynamicSortedStringKeyValueStoreOne.Add("Jems", 3);
        dynamicSortedStringKeyValueStoreTwo.Add("Yukon", 8);
        dynamicSortedStringKeyValueStoreTwo.Add("Bicker", 9);
        dynamicSortedStringKeyValueStoreTwo.Add("Shulz", 7);
        dynamicSortedStringKeyValueStoreTwo.Add("Jems", 3);
        ITwoDimensionSortable<String,Int32> dynamicSortedStringKeyValueStoreOneSingularSorter = new TwoDimensionSorter<String,Int32>(dynamicSortedStringKeyValueStoreOne);
        dynamicSortedStringKeyValueStoreOneSingularSorter.Sort(TwoDimensionConstants.VALUE);
        Console.WriteLine(dynamicSortedStringKeyValueStoreOne);
        ITwoDimensionSortable<String,Int32> dynamicSortedStringKeyValueStoreTwoParallelSorter = new TwoDimensionSorter<String,Int32>(dynamicSortedStringKeyValueStoreTwo);
        dynamicSortedStringKeyValueStoreTwoParallelSorter.ParallelSort(TwoDimensionConstants.VALUE);
        Console.WriteLine(dynamicSortedStringKeyValueStoreTwo);
        Console.WriteLine("Yukon -> " + Convert.ToString(dynamicSortedStringKeyValueStoreOne.GetValue("Yukon")));
        Console.WriteLine("3 <- " + Convert.ToString(dynamicSortedStringKeyValueStoreOne.GetKey(3)));
        Console.WriteLine();
    }
}
