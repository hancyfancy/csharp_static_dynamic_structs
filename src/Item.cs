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

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Reflection;

internal class Item<T> : IEquatable<Item<T>>
{
    private T _content;
    internal Item(T newContent)
    {
        Content = newContent;
    }
    internal T Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
        }
    }
    public static bool operator == (Item<T> lhs, Item<T> rhs)
    {
        if (Object.ReferenceEquals(lhs, null))
        {
            if (Object.ReferenceEquals(rhs, null))
            {
                return true;
            }

            return false;
        }
        return lhs.Equals(rhs);
    }
    public static bool operator != (Item<T> lhs, Item<T> rhs)
    {
       return !(lhs == rhs);
    }
    public static bool operator < (Item<T> lhs, Item<T> rhs)
    {
        return Comparer<T>.Default.Compare(lhs.Content, rhs.Content) < 0;
    }
    public static bool operator > (Item<T> lhs, Item<T> rhs)
    {
        return Comparer<T>.Default.Compare(lhs.Content, rhs.Content) > 0;
    }
    public static bool operator <= (Item<T> lhs, Item<T> rhs)
    {
        return Comparer<T>.Default.Compare(lhs.Content, rhs.Content) <= 0;
    }
    public static bool operator >= (Item<T> lhs, Item<T> rhs)
    {
        return Comparer<T>.Default.Compare(lhs.Content, rhs.Content) >= 0;
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as Item<T>);
    }
    public bool Equals(Item<T> p)
    {
        if ((Object.ReferenceEquals(p, null)) || (this.GetType() != p.GetType()))
        {
            return false;
        }
        else if (Object.ReferenceEquals(this, p))
        {
            return true;
        }
        return EqualTo(Content, p.Content);
    }
    private static bool EqualTo<TType>(TType x, TType y) {
        bool status;
        dynamic dx = x, dy = y;
        try
        {   
            status = (dx == dy);
        }
        catch (RuntimeBinderException)
        {
            status = (Comparer<T>.Default.Compare(dx, dy) == 0);
        }
        return status;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public override string ToString()
    {
        return Convert.ToString(Content);
    }
    public object ToObject()
    {
        return (object)Content;
    }
}
