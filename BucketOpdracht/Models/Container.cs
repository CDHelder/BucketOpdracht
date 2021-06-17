using System;

namespace BucketOpdracht.Models
{
    public delegate void ContainerStatusDelegate(object sender, ContainerStatusEvent e);

    public enum ContainerStatus
    {
        NotFull, Full, Overflowing
    }

    public abstract class Container
    {
        public event ContainerStatusDelegate ContainerStatusEvent;

        public Container(int capacity, bool allowOverflow) : this(capacity, 0, allowOverflow)
        {

        }
        public Container(int capacity, int content, bool allowOverflow)
        {
            Capacity = capacity;
            Content = content;
            AllowOverflowing = allowOverflow;
        }

        public bool AllowOverflowing { get; init; }
        // TODO: ContainerStatus weghalen?
        //      --> Wordt al meegegeven via Overflow prop in ContainerStatusEvent
        public ContainerStatus ContainerStatus { get; protected set; }
        public int Capacity { get; init; }

        private int content;
        public int Content
        {
            get => content;
            private set
            {
                if (value < 0)
                    value = 0;

                content = value;
            }
        }

        private void CheckStatusContainer(Bucket bucket)
        {
            if (bucket.Content == bucket.Capacity)
            {
                bucket.ContainerStatus = ContainerStatus.Full;
            }
            else if (bucket.Content < bucket.Capacity)
            {
                bucket.ContainerStatus = ContainerStatus.NotFull;
            }
        }

        public void Fill(int amount)
        {
            Content += amount;
        }
        public void Empty()
        {
            Content = 0;
        }
        public void Empty(int amount)
        {
            Content -= amount;
        }
        // TODO: Moet deze niet in bucket?
        public void Fill(int amount, Bucket bucket)
        {
            if (this.Content < amount)
            {
                Console.WriteLine($"Bucket doesn't have enough content to fill another bucket with amount {amount}");
                return;
            }

            if ((bucket.Content + amount) > bucket.Capacity
                || bucket.ContainerStatus == ContainerStatus.Overflowing
                || bucket.ContainerStatus == ContainerStatus.Full && amount > 0)
            {
                bucket.ContainerStatus = ContainerStatus.Overflowing;
                if (bucket.AllowOverflowing == true)
                {
                    int Overflowed = (bucket.Content + amount) - bucket.Capacity;
                    bucket.Content = bucket.Capacity;
                    Content -= amount;
                    ContainerStatusEvent?.Invoke(this, new ContainerStatusEvent(bucket, Overflowed));
                    return;
                }
                else if (bucket.AllowOverflowing == false)
                {
                    int Overflowed = 0;
                    Content -= bucket.Capacity - bucket.Content;
                    bucket.Content = bucket.Capacity;
                    ContainerStatusEvent?.Invoke(this, new ContainerStatusEvent(bucket, Overflowed));
                    return;
                }
            }

            Content -= amount;
            bucket.Content += amount;
            CheckStatusContainer(bucket);
            return;
        }
    }
}
