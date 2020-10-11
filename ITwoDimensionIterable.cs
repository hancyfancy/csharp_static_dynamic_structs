using System;

interface ITwoDimensionIterable<K,V> {
    Int32 GetKeyIndex(K key);
    Int32 GetValueIndex(V val);
}
