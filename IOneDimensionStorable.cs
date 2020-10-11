using System;

interface IOneDimensionStorable<T> {
    T Get(Int32 index);
    void Add(T toBeAdded);
    void Replace(Int32 index, T toBeReplaced);
    void ReplaceAll(T toBeReplaced);
}
