﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MAMAMENYA
{

    public class RecordList<T> 
    {
        public RecordList()
        {

        }
        public RecordList(IList<T> data)
        {
            this.Data = data;
        }

        [JsonProperty("rows")]
        public IList<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        [JsonProperty("total")]
        public int RecordCount { get; set; }

        public int StartIndex
        {
            get { return (PageIndex - 1) * PageSize; }
        }

        public int EndIndex
        {
            get { return StartIndex + PageSize - 1; }
        }

        public int PageCount
        {
            get { return (int)Math.Ceiling(RecordCount * 1.0 / PageSize); }
        }



        public int IndexOf(T item)
        {
            return Data.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        public void Add(T item)
        {
            this.RecordCount++;
            
            Data.Add(item);
            //throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Data.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(T item)
        {
            return   Data.Remove(item);
            //throw new NotImplementedException();
        }

        public RecordList<T> Clone()
        {
            throw new NotImplementedException();
        }
 

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }



        //public IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{

        //    return Data.GetEnumerator();
        //}




        public static RecordList<T> FromIList(IList<T> list)
        {
            return new RecordList<T> { Data = list };
        }
    }
    //public class RecordList<T>
    //{

    //    public IList<T> Data { get; set; }
    //    public int PageIndex { get; set; }
    //    public int PageSize { get; set; }
    //    public int RecordCount { get; set; }


    //    public int StartIndex
    //    {
    //        get
    //        {
    //            return (PageIndex - 1) * PageSize;
    //        }


    //    }
    //    public int EndIndex
    //    {
    //        get
    //        {
    //            return StartIndex + PageSize - 1;
    //        }
    //    }

    //    public int PageCount
    //    {
    //        get
    //        {
    //            return (int)Math.Ceiling(RecordCount * 1.0 / PageSize);
    //        }
    //    }
    //}
}
