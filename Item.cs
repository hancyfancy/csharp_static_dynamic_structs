using System;

internal class Item<T>
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
    public override bool Equals(object compareContent)
    {
        //return base.Equals(compareContent);
        string thisContent = ToString();
        string contentToCompare = Convert.ToString(compareContent);
        return thisContent.Equals(contentToCompare);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public int ToInt()
    {
        return Convert.ToInt32(ToString());
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
