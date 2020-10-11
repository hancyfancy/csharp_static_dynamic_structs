using System;

public class StructTests
{
	public static void Main(string[] args)
    {
        Random random = new Random();

        Console.WriteLine("--------------------Items");

        Item<Byte> myByte = new Item<Byte>(10);
        Console.WriteLine(myByte);
        Item<Int16> myShort = new Item<Int16>(20);
        Console.WriteLine(myShort);
        Item<Int32> myInteger = new Item<Int32>(-1);
        Console.WriteLine(myInteger);
        Item<Int64> myLong = new Item<Int64>(1L);
        Console.WriteLine(myLong);
        Item<Single> myFloat = new Item<Single>(894.236f);
        Console.WriteLine(myFloat);
        Item<Double> myDouble = new Item<Double>(-7.5d);
        Console.WriteLine(myDouble);
        Item<Char> myChar = new Item<Char>('c');
        Console.WriteLine(myChar);
        Item<Boolean> myBoolean = new Item<Boolean>(false);
        Console.WriteLine(myBoolean);
        Item<String> myString = new Item<String>("Hello");
        Console.WriteLine(myString);
        Item<Object> myObject = new Item<Object>(null);
        Console.WriteLine(myObject);

        Console.WriteLine("--------------------Static store");
        
        StaticStore<Byte> staticByteStore = new StaticStore<Byte>(4);
        staticByteStore.Add(Byte.MinValue);
        staticByteStore.Add(Byte.MaxValue);
        staticByteStore.Add(1);
        staticByteStore.Add(8);
        //staticByteStore.Add(5);
        Console.WriteLine(staticByteStore);

        //StaticStore<Int16> staticInvalidShortStore = new StaticStore<Int16>(-1);
        StaticStore<Int16> staticShortStore = new StaticStore<Int16>(4);
        staticShortStore.Add(Int16.MinValue);
        staticShortStore.Add(Int16.MaxValue);
        staticShortStore.Add(2);
        staticShortStore.Add(16);
        Console.WriteLine(staticShortStore);

        StaticStore<Int32> staticIntegerStore = new StaticStore<Int32>(4);
        staticIntegerStore.Add(Int32.MinValue);
        staticIntegerStore.Add(Int32.MaxValue);
        staticIntegerStore.Add(4);
        staticIntegerStore.Add(32);
        Console.WriteLine(staticIntegerStore);

        StaticStore<Int64> staticLongStore = new StaticStore<Int64>(4);
        staticLongStore.Add(Int64.MinValue);
        staticLongStore.Add(Int64.MaxValue);
        staticLongStore.Add(8);
        staticLongStore.Add(64);
        Console.WriteLine(staticLongStore);

        StaticStore<Single> staticFloatStore = new StaticStore<Single>(6);
        staticFloatStore.Add(Single.MinValue);
        staticFloatStore.Add(Single.MaxValue);
        staticFloatStore.Add(Single.NegativeInfinity);
        staticFloatStore.Add(Single.PositiveInfinity);
        staticFloatStore.Add(Single.Epsilon);
        staticFloatStore.Add(Single.NaN);
        Console.WriteLine(staticFloatStore);

        StaticStore<Double> staticDoubleStore = new StaticStore<Double>(6);
        staticDoubleStore.Add(Double.MinValue);
        staticDoubleStore.Add(Double.MaxValue);
        staticDoubleStore.Add(Double.NegativeInfinity);
        staticDoubleStore.Add(Double.PositiveInfinity);
        staticDoubleStore.Add(Double.Epsilon);
        staticDoubleStore.Add(Double.NaN);
        Console.WriteLine(staticDoubleStore);

        StaticStore<Char> staticCharacterStore = new StaticStore<Char>(2);
        staticCharacterStore.Add(Char.MinValue);
        staticCharacterStore.Add(Char.MaxValue);
        Console.WriteLine(staticCharacterStore);

        StaticStore<Boolean> staticBooleanStore = new StaticStore<Boolean>(2);
        staticBooleanStore.Add(false);
        staticBooleanStore.Add(true);
        Console.WriteLine(staticBooleanStore);

        StaticStore<String> staticStringStore = new StaticStore<String>(4);
        staticStringStore.Add("Fellow");
        staticStringStore.Add("Mellow");
        staticStringStore.Add("Yellow");
        staticStringStore.Add("Bellow");
        Console.WriteLine(staticStringStore);

        StaticStore<Object> staticObjectStore = new StaticStore<Object>(2);
        staticObjectStore.Add(null);
        staticObjectStore.Add(new Object());
        Console.WriteLine(staticObjectStore);

        Console.WriteLine("--------------------Static store replace item");

        StaticStore<Int32> staticReplacedIntegerStore = new StaticStore<Int32>(4);
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
        Console.WriteLine("Index of 9 = " + Convert.ToString(staticReplacedIntegerStore.GetIndex(9)));
        Console.WriteLine("Item at index 3 = " + Convert.ToString(staticReplacedIntegerStore.Get(3)));

        Console.WriteLine("--------------------Dynamic store");

        DynamicStore<Byte> dynamicByteStore = new DynamicStore<Byte>();
        dynamicByteStore.Add(Byte.MinValue);
        dynamicByteStore.Add(Byte.MaxValue);
        dynamicByteStore.Add(1);
        dynamicByteStore.Add(8);
        Console.WriteLine(dynamicByteStore);

        DynamicStore<Int16> dynamicShortStore = new DynamicStore<Int16>();
        dynamicShortStore.Add(Int16.MinValue);
        dynamicShortStore.Add(Int16.MaxValue);
        dynamicShortStore.Add(2);
        dynamicShortStore.Add(16);
        Console.WriteLine(dynamicShortStore);

        DynamicStore<Int32> dynamicIntegerStore = new DynamicStore<Int32>();
        dynamicIntegerStore.Add(Int32.MinValue);
        dynamicIntegerStore.Add(Int32.MaxValue);
        dynamicIntegerStore.Add(4);
        dynamicIntegerStore.Add(32);
        Console.WriteLine(dynamicIntegerStore);

        DynamicStore<Int64> dynamicLongStore = new DynamicStore<Int64>();
        dynamicLongStore.Add(Int64.MinValue);
        dynamicLongStore.Add(Int64.MaxValue);
        dynamicLongStore.Add(8);
        dynamicLongStore.Add(64);
        Console.WriteLine(dynamicLongStore);

        DynamicStore<Single> dynamicFloatStore = new DynamicStore<Single>();
        dynamicFloatStore.Add(Single.MinValue);
        dynamicFloatStore.Add(Single.MaxValue);
        dynamicFloatStore.Add(Single.NegativeInfinity);
        dynamicFloatStore.Add(Single.PositiveInfinity);
        dynamicFloatStore.Add(Single.Epsilon);
        dynamicFloatStore.Add(Single.NaN);
        Console.WriteLine(dynamicFloatStore);

        DynamicStore<Double> dynamicDoubleStore = new DynamicStore<Double>();
        dynamicDoubleStore.Add(Double.MinValue);
        dynamicDoubleStore.Add(Double.MaxValue);
        dynamicDoubleStore.Add(Double.NegativeInfinity);
        dynamicDoubleStore.Add(Double.PositiveInfinity);
        dynamicDoubleStore.Add(Double.Epsilon);
        dynamicDoubleStore.Add(Double.NaN);
        Console.WriteLine(dynamicDoubleStore);

        DynamicStore<Char> dynamicCharacterStore = new DynamicStore<Char>();
        dynamicCharacterStore.Add(Char.MinValue);
        dynamicCharacterStore.Add(Char.MaxValue);
        Console.WriteLine(dynamicCharacterStore);

        DynamicStore<Boolean> dynamicBooleanStore = new DynamicStore<Boolean>();
        dynamicBooleanStore.Add(false);
        dynamicBooleanStore.Add(true);
        Console.WriteLine(dynamicBooleanStore);

        DynamicStore<String> dynamicStringStore = new DynamicStore<String>();
        dynamicStringStore.Add("Fellow");
        dynamicStringStore.Add("Mellow");
        dynamicStringStore.Add("Yellow");
        dynamicStringStore.Add("Bellow");
        Console.WriteLine(dynamicStringStore);

        DynamicStore<Object> dynamicObjectStore = new DynamicStore<Object>();
        dynamicObjectStore.Add(null);
        dynamicObjectStore.Add(new Object());
        Console.WriteLine(dynamicObjectStore);

        Console.WriteLine("--------------------Dynamic sorted store");

        DynamicStore<Int32> dynamicSortedIntegerStore = new DynamicStore<Int32>();
        for (Int32 i = 0; i < 4; i++)
        {
            dynamicSortedIntegerStore.Add(random.Next(2000));
        }
        dynamicSortedIntegerStore.Sort();
        Console.WriteLine(dynamicSortedIntegerStore);

        DynamicStore<String> dynamicSortedStringStore = new DynamicStore<String>();
        dynamicSortedStringStore.Add("Fellow");
        dynamicSortedStringStore.Add("Mellow");
        dynamicSortedStringStore.Add("Yellow");
        dynamicSortedStringStore.Add("Bellow");
        dynamicSortedStringStore.Sort();
        Console.WriteLine(dynamicSortedStringStore);

        Console.WriteLine("--------------------Dynamic store replace item");
        
        DynamicStore<Int32> dynamicReplacedIntegerStore = new DynamicStore<Int32>();
        dynamicReplacedIntegerStore.Add(1);
        dynamicReplacedIntegerStore.Add(3);
        //dynamicReplacedIntegerStore.Replace(2, 7);
        dynamicReplacedIntegerStore.Add(9);
        dynamicReplacedIntegerStore.Add(5);
        Console.WriteLine(dynamicReplacedIntegerStore);
        dynamicReplacedIntegerStore.Replace(2, 7);
        Console.WriteLine(dynamicReplacedIntegerStore);

        Console.WriteLine("--------------------Dynamic store insert item");
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
        
        DynamicUniqueStore<Int32> dynamicUniqueIntegerStore = new DynamicUniqueStore<Int32>();
        dynamicUniqueIntegerStore.Add(1);
        dynamicUniqueIntegerStore.Add(2);
        dynamicUniqueIntegerStore.Add(1);
        dynamicUniqueIntegerStore.Add(3);
        Console.WriteLine(dynamicUniqueIntegerStore);

        Console.WriteLine("--------------------Dynamic key value store");

        DynamicMap<String,Int32> dynamicKeyValueStore = new DynamicMap<String,Int32>();
        dynamicKeyValueStore.Add("Yukon", 8);
        dynamicKeyValueStore.Add("Bicker", 9);
        dynamicKeyValueStore.Add("Shulz", 7);
        dynamicKeyValueStore.Add("Jems", 3);
        Console.WriteLine(dynamicKeyValueStore);

        DynamicMap<Int32,ItemStore<Int32>> dynamicKeyValueStoreWithListValue = new DynamicMap<Int32,ItemStore<Int32>>();
        dynamicKeyValueStoreWithListValue.Add(1, new StaticStore<Int32>(4));
        dynamicKeyValueStoreWithListValue.Add(2, new DynamicStore<Int32>());
        dynamicKeyValueStoreWithListValue.Add(3, new DynamicUniqueStore<Int32>());
        Console.WriteLine(dynamicKeyValueStoreWithListValue);

        Console.WriteLine("--------------------Dynamic sorted key value store");

        DynamicMap<Int32,String> dynamicSortedIntegerKeyValueStore = new DynamicMap<Int32,String>();
        dynamicSortedIntegerKeyValueStore.Add(88, "Yukon");
        dynamicSortedIntegerKeyValueStore.Add(832, "Bicker");
        //dynamicSortedIntegerKeyValueStore.Add(832, "Blitzer");
        dynamicSortedIntegerKeyValueStore.Add(7, "Shulz");
        //dynamicSortedIntegerKeyValueStore.Add(17, "Shulz");
        dynamicSortedIntegerKeyValueStore.Add(3, "Jems");
        dynamicSortedIntegerKeyValueStore.Sort();
        Console.WriteLine(dynamicSortedIntegerKeyValueStore);
        Console.WriteLine("7 -> " + Convert.ToString(dynamicSortedIntegerKeyValueStore.GetValue(7)));
        Console.WriteLine("Bicker <- " + Convert.ToString(dynamicSortedIntegerKeyValueStore.GetKey("Bicker")));
        Console.WriteLine();

        DynamicMap<String,Int32> dynamicSortedStringKeyValueStore = new DynamicMap<String,Int32>();
        dynamicSortedStringKeyValueStore.Add("Yukon", 8);
        dynamicSortedStringKeyValueStore.Add("Bicker", 9);
        dynamicSortedStringKeyValueStore.Add("Shulz", 7);
        dynamicSortedStringKeyValueStore.Add("Jems", 3);
        dynamicSortedStringKeyValueStore.Sort();
        Console.WriteLine(dynamicSortedStringKeyValueStore);
        Console.WriteLine("Yukon -> " + Convert.ToString(dynamicSortedStringKeyValueStore.GetValue("Yukon")));
        Console.WriteLine("3 <- " + Convert.ToString(dynamicSortedStringKeyValueStore.GetKey(3)));
        Console.WriteLine();
    }
}
