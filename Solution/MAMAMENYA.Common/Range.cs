namespace MAMAMENYA
{
    public class Range<T>
    {
        public Range()
        {

        }
        public Range(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }
        public T Start { get; set; }
        public T End { get; set; }

        public static Range<T> Create(T start, T end)
        {
            return new Range<T>(start, end);
        }
    }



   
}
