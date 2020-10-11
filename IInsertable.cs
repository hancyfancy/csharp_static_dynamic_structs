using System;

interface IInsertable<T> {
    void Insert(Int32 index, T toBeInserted);
}
