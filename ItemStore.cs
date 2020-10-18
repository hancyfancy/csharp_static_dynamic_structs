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
    private Boolean IsNumericString(String stringToBeChecked)
    {
        Boolean isNumeric = true;
        if (stringToBeChecked != null && stringToBeChecked.Length > 0)
        {
            foreach (Char c in stringToBeChecked.ToCharArray())
            {
                if (!Char.IsDigit(c))
                {
                    isNumeric = false;
                }
            }
        }
        else
        {
            isNumeric = false;
        }
        return isNumeric;
    }
    private Boolean IsPrimeNumber(Int32 num)
    {
        Boolean flag = true;
        for(Int32 i = 2; i <= num/2; ++i)
        {
            if(num % i == 0)
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
    private Int32[] GeneratePrimeNumbers(Int32 n)
    {
        Int32[] primeNumbers = null;
        if (n <= 1)
        {
            primeNumbers = new Int32[]{1};
        }
        else if (n == 2)
        {
            primeNumbers = new Int32[]{2};
        }
        else
        {
            String primeNumbersAsString = "";
            for (Int32 i = 2; i <= n; i++)
            {
                if (i <= n)
                {	 		  
                    if (IsPrimeNumber(i))
                    {
                        primeNumbersAsString = primeNumbersAsString + Convert.ToString(i) + ",";
                    }
                }
            }
            String[] primeNumbersSplit = primeNumbersAsString.Split(",");
            Int32 primeNumbersSplitLength = primeNumbersSplit.Length;
            primeNumbers = new Int32[primeNumbersSplitLength];
            for (Int32 j = 0; j < primeNumbersSplitLength-1; j++)
            {
                primeNumbers[j] = Int32.Parse(primeNumbersSplit[j]);
            }
        }
        return primeNumbers;
    }
    private Int32 CalculatePrimeDivisions(Item<T>[] unsortedItems)
    {
        Int32 unsortedItemsLength = unsortedItems.Length;
        Int32[] primeNumbers = GeneratePrimeNumbers(unsortedItemsLength/2);
        Int32 requiredPrime = -1;
        for (Int32 i = primeNumbers.Length-1; i > -1; i--)
        {
            Int32 currentPrime = primeNumbers[i];
            if (currentPrime > 0)
            {
                if (unsortedItemsLength % currentPrime == 0)
                {
                    requiredPrime = currentPrime;
                    break;
                }
            }
        }
        return (requiredPrime == -1 ? 1 : requiredPrime);
    }
    private String MinString(String firstString, String secondString)
    {
        String minString = null;
        Int32 counter = 0;
        Int32 maxLength = -1;
        if (this.IsNumericString(firstString) && this.IsNumericString(secondString))
        {
            Int32 first = Int32.Parse(firstString);
            Int32 second = Int32.Parse(secondString);
            if (first < second)
            {
                minString = firstString;
            }
            else if (second <= first)
            {
                minString = secondString;
            }
        }
        else
        {
            if (firstString.Length >= secondString.Length)
            {
                maxLength = firstString.Length;
            }
            else if (secondString.Length > firstString.Length)
            {
                maxLength = secondString.Length;
            }
            for (Int32 i = 0; i < maxLength; i++)
            {
                if (((Int32)firstString[i]) < ((Int32)secondString[i]))
                {
                    minString = firstString;
                    break;
                }
                else if (((Int32)secondString[i]) <= ((Int32)firstString[i]))
                {
                    minString = secondString;
                    break;
                }
                counter++;
            }
            if (counter == maxLength-1)
            {
                minString = firstString;
            }
        }
        return minString;
    }
    private String MaxString(String firstString, String secondString)
    {
        String maxString = null;
        Int32 counter = 0;
        Int32 maxLength = -1;
        if (this.IsNumericString(firstString) && this.IsNumericString(secondString))
        {
            Int32 first = Int32.Parse(firstString);
            Int32 second = Int32.Parse(secondString);
            if (first > second)
            {
                maxString = firstString;
            }
            else if (second >= first)
            {
                maxString = secondString;
            }
        }
        else
        {
            if (firstString.Length >= secondString.Length)
            {
                maxLength = firstString.Length;
            }
            else if (secondString.Length > firstString.Length)
            {
                maxLength = secondString.Length;
            }
            for (Int32 i = 0; i < maxLength; i++)
            {
                if (((Int32)firstString[i]) > ((Int32)secondString[i]))
                {
                    maxString = firstString;
                    break;
                }
                else if (((Int32)secondString[i]) >= ((Int32)firstString[i]))
                {
                    maxString = secondString;
                    break;
                }
                counter++;
            }
            if (counter == maxLength-1)
            {
                maxString = firstString;
            }
        }
        return maxString;
    }
    private Int32 LinearSearchMin(Item<T>[] array)
    {
        String min = "";
        for (Int32 j = 0; j < array[0].ToString().Length; j++)
        {
            min += 'z';
        }
        Int32 minIndex = -1;
        for (Int32 i = 0; i < array.Length; i++)
        {
            String current = ((Item<T>)array[i]).ToString();
            if (MinString(current, min).Equals(current))
            {
                min = current;
                minIndex = i;
            }
        }
        return minIndex;
    }
    private Int32 LinearSearchMax(Item<T>[] array)
    {
        String max = "";
        for (Int32 j = 0; j < array[0].ToString().Length; j++)
        {
            max += '0';
        }
        Int32 maxIndex = -1;
        for (Int32 j = 0; j < array.Length; j++)
        {
            String current = ((Item<T>)array[j]).ToString();
            if (MaxString(current, max).Equals(current))
            {
                max = current;
                maxIndex = j;
            }
        }
        return maxIndex;
    }
    private Item<T>[] RemoveSortedDivision(Item<T>[] unsortedDivision, Int32 index)
    {
        Int32 newUnsortedDivisionLength = unsortedDivision.Length - 1;
        Item<T>[] newUnsortedDivision = new Item<T>[newUnsortedDivisionLength];
        for (Int32 i = 0; i < index; i++)
        {
            newUnsortedDivision[i] = unsortedDivision[i];
        }
        for (Int32 i = index+1; i <= newUnsortedDivisionLength; i++)
        {
            newUnsortedDivision[i-1] = unsortedDivision[i];
        }
        return newUnsortedDivision;     
    }
    private Item<T>[] MultisortFrame(Item<T>[] unsortedDivision, Int32 numberOfDivisions)
    {
        Item<T>[] sortedDivision = new Item<T>[numberOfDivisions];
        Int32 sortedArrayLength = sortedDivision.Length;
        Int32 halfSortedArrayLength = sortedArrayLength/2;
        Int32 minDivisionIndex = 0;
        Int32 maxDivisionIndex = numberOfDivisions - 1;
        if (sortedArrayLength == 1)
        {
            sortedDivision[0] = unsortedDivision[0];
        }
        else if (sortedArrayLength == 2)
        {
            Item<T> firstItem = (Item<T>)unsortedDivision[0];
            Item<T> secondItem = (Item<T>)unsortedDivision[1];
            if (MinString(firstItem.ToString(),secondItem.ToString()).Equals(firstItem.ToString()))
            {
                sortedDivision[0] = firstItem;
                sortedDivision[1] = secondItem;
            }
            else
            {
                sortedDivision[0] = secondItem;
                sortedDivision[1] = firstItem;
            }
        }
        else
        {
            while ((minDivisionIndex < halfSortedArrayLength) && (maxDivisionIndex > sortedArrayLength-1-halfSortedArrayLength))
            {
                Int32 indexOfMin = LinearSearchMin(unsortedDivision);
                sortedDivision[minDivisionIndex] = unsortedDivision[indexOfMin];
                minDivisionIndex++;
                unsortedDivision = RemoveSortedDivision(unsortedDivision, indexOfMin);
                Int32 indexOfMax = LinearSearchMax(unsortedDivision);
                sortedDivision[maxDivisionIndex] = unsortedDivision[indexOfMax];
                maxDivisionIndex--;
                unsortedDivision = RemoveSortedDivision(unsortedDivision, indexOfMax);
            }
            if (sortedArrayLength % 2 != 0)
            {
                sortedDivision[halfSortedArrayLength] = unsortedDivision[0];
            }
        }
        return sortedDivision;
    }
    private Item<T>[] PopulateUnsortedSubarray(Item<T>[] unsorted, Int32 index, Int32 numberOfDivisions)
    {
        Item<T>[] unsortedSubarray = new Item<T>[numberOfDivisions];
        Int32 unsortedSubarrayIndex = 0;
        for (Int32 i = index; i < numberOfDivisions+index; i++)
        {
            unsortedSubarray[unsortedSubarrayIndex] = unsorted[i];
            unsortedSubarrayIndex++;
        }
        return unsortedSubarray;
    }
    private Item<T>[][] GetSortedSubarrays(Item<T>[] unsorted, Int32 numberOfDivisions, Int32 divisor)
    {
        Int32 unsortedLength = unsorted.Length;
        Item<T>[][] sortedSubarrays = new Item<T>[divisor][];
        Int32 sortedSubarraysIndex = 0;
        for (Int32 i = 0; i < unsortedLength; i+=numberOfDivisions)
        {
            Item<T>[] unsortedSubarray = PopulateUnsortedSubarray(unsorted, i, numberOfDivisions);
            Item<T>[] sortedSubarray = MultisortFrame(unsortedSubarray, numberOfDivisions);
            sortedSubarrays[sortedSubarraysIndex] = sortedSubarray;
            sortedSubarraysIndex++;
        }
        return sortedSubarrays;
    }
    private Item<T>[][] GetSortOrder(Item<T>[][] sortedSubarrays, Int32 numberOfDivisions, Int32 divisor)
    {
        Item<T>[][] sortedOrderedSubarrays = new Item<T>[numberOfDivisions][];
        Int32 sortLevelIndex = 0;
        while (sortLevelIndex < numberOfDivisions)
        {
            Item<T>[] unsortedSortLevel = new Item<T>[divisor];
            for (Int32 i = 0; i < unsortedSortLevel.Length; i++)
            {
                unsortedSortLevel[i] = sortedSubarrays[i][sortLevelIndex];
            }
            Item<T>[] sortedSortLevel = MultisortFrame(unsortedSortLevel, unsortedSortLevel.Length);
            sortedOrderedSubarrays[sortLevelIndex] = sortedSortLevel;
            sortLevelIndex++;
        }
        return sortedOrderedSubarrays;
    }
    private Item<T>[] Subsort(Item<T>[] firstSortOrderLevel, Item<T>[] secondSortOrderLevel)
    {
        Item<T>[] subsorted = null;
        if (!(firstSortOrderLevel.Length > 0))
        {
            subsorted = (Item<T>[])secondSortOrderLevel;
        }
        else if (!(secondSortOrderLevel.Length > 0))
        {
            subsorted = (Item<T>[])firstSortOrderLevel;
        }
        else
        {
            subsorted = new Item<T>[firstSortOrderLevel.Length+secondSortOrderLevel.Length];
            Int32 subsortedIndex = 0;
            Int32 firstSortOrderIndex = 0;
            Int32 secondSortOrderIndex = 0;
            while ((firstSortOrderIndex < firstSortOrderLevel.Length) && (secondSortOrderIndex < secondSortOrderLevel.Length))
            {
                if (MinString(((Item<T>)firstSortOrderLevel[firstSortOrderIndex]).ToString(),((Item<T>)secondSortOrderLevel[secondSortOrderIndex]).ToString()).Equals(((Item<T>)firstSortOrderLevel[firstSortOrderIndex]).ToString()))
                {
                    subsorted[subsortedIndex] = (Item<T>)firstSortOrderLevel[firstSortOrderIndex];
                    firstSortOrderIndex++;
                    subsortedIndex++;
                }
                else if (MaxString(((Item<T>)firstSortOrderLevel[firstSortOrderIndex]).ToString(),((Item<T>)secondSortOrderLevel[secondSortOrderIndex]).ToString()).Equals(((Item<T>)firstSortOrderLevel[firstSortOrderIndex]).ToString()))
                {
                    subsorted[subsortedIndex] = (Item<T>)secondSortOrderLevel[secondSortOrderIndex];
                    secondSortOrderIndex++;
                    subsortedIndex++;
                }
                else
                {
                    subsorted[subsortedIndex] = (Item<T>)firstSortOrderLevel[firstSortOrderIndex];
                    firstSortOrderIndex++;
                    subsorted[subsortedIndex+1] = (Item<T>)secondSortOrderLevel[secondSortOrderIndex];
                    secondSortOrderIndex++;
                    subsortedIndex+=2;
                }
            }
            for (Int32 j = secondSortOrderIndex; j < secondSortOrderLevel.Length; j++)
            {
                subsorted[subsortedIndex] = (Item<T>)secondSortOrderLevel[j];
                subsortedIndex++;
            }
            for (Int32 k = firstSortOrderIndex; k < firstSortOrderLevel.Length; k++)
            {
                subsorted[subsortedIndex] = (Item<T>)firstSortOrderLevel[k];
                subsortedIndex++;
            }
        }
        return subsorted;
    }
    private Item<T>[] SortTruncate(Item<T>[][] sortOrder, Int32 numberOfDivisions, Int32 divisor)
    {
        Item<T>[] sorted = new Item<T>[0];
        for (Int32 i = 0; i < sortOrder.Length; i++)
        {
            sorted = Subsort(sorted, (Item<T>[])sortOrder[i]);
        }
        return sorted;
    }
    protected void Sort(Boolean createSortOrder)
    {
        Item<T>[] unsortedItems = Items;
        Int32 primeDivisions = this.CalculatePrimeDivisions(unsortedItems);
        Int32 divisor = unsortedItems.Length/primeDivisions;
        Item<T>[][] sortedSubarrays = this.GetSortedSubarrays(unsortedItems, primeDivisions, divisor);
        Item<T>[] allSorted = null;
        if (createSortOrder)
        {
            Item<T>[][] sortOrder = this.GetSortOrder(sortedSubarrays, primeDivisions, divisor);
            allSorted = this.SortTruncate(sortOrder, primeDivisions, divisor);
        }
        else
        {
            allSorted = this.SortTruncate(sortedSubarrays, primeDivisions, divisor);
        }
        Items = allSorted;
    }
    public void Sort()
    {
        Sort(false);
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
