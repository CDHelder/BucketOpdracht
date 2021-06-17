namespace BucketOpdracht.Models
{
    public enum BucketSize : int
    {
        Small = 10,
        Medium = 11,
        Large = 12
    }
    public class Bucket : Container
    {
        public Bucket(BucketSize size, bool allowOverflow) : base((int)size, allowOverflow)
        {

        }
        public Bucket(BucketSize size, int content, bool allowOverflow) : base((int)size, content, allowOverflow)
        {

        }
    }
}
