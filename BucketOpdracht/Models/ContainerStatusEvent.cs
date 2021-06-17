using System;

namespace BucketOpdracht.Models
{
    public class ContainerStatusEvent : EventArgs
    {
        public ContainerStatusEvent(Bucket bucket, int overflow = 0)
        {
            Bucket = bucket;
            Overflow = overflow;
        }

        public Bucket Bucket { get; set; }
        public int Overflow { get; }
    }
}
