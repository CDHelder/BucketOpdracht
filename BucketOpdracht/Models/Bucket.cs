using System;

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
        public Bucket(BucketSize size) : base((int)size)
        {

        }
        public Bucket(BucketSize size, int content) : base((int)size, content)
        {

        }


        public void Fill(int amount, Bucket bucket)
        {
            //TODO: check voor hoeveelheid erindoen en uithalen
            if (this.Content < amount)
            {
                Console.WriteLine($"Bucket doesn't have enough content to fill another bucket with amount {amount}");
                return;
            }
            
            //TODO: maak hier de afhandeling als hij overloopt
            if((bucket.Content + amount) > bucket.Capacity 
                || bucket.ContainerStatus == ContainerStatus.Overflowing 
                || bucket.ContainerStatus == ContainerStatus.Full && amount > 0)
            {
                bucket.ContainerStatus = ContainerStatus.Overflowing;
                if(bucket.AllowOverflowing == true)
                {
                    bucket.Overflowed = (bucket.Content + amount) - bucket.Capacity;
                    bucket.Content = bucket.Capacity;
                    Content -= amount;
                    return;
                }
                else if(bucket.AllowOverflowing == false)
                {
                    bucket.Overflowed = 0;
                    Content -= bucket.Capacity - bucket.Content;
                    bucket.Content = bucket.Capacity;
                    return;
                }
            }

            Content -= amount;
            bucket.Content += amount;
            return;
        }
    }
}
