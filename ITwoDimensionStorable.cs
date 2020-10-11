using System;

interface ITwoDimensionStorable<K,V> {
    K GetKeyAtPosition(Int32 index);
    V GetValueAtPosition(Int32 index);
    K GetKey(V val);
    V GetValue(K key);
    void Add(K key, V val);
}
