using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketOpdracht.Models
{
    public delegate void ContainerStatusDelegate(object sender, ContainerStatusEvent e);


    public enum ContainerStatus
    {
        NotFull,
        Full,
        Overflowing
    }
    public abstract class Container
    {
        public event ContainerStatusDelegate ContainerStatusEvent;

        public Container(int capacity) : this(capacity, 0)
        {

        }
        public Container(int capacity, int content)
        {
            Capacity = capacity;
            Content = content;

            Random random = new Random();
            AllowOverflowing = random.Next(10) <= 5 ? true : false;
        }

        public bool AllowOverflowing { get; init; }
        public ContainerStatus ContainerStatus { get; protected set; }
        public int Capacity { get; init; }
        public int Overflowed { get; set; }

        private int content;
        public int Content
        {
            get => content;
            protected set
            {
                if (value < 0)
                    value = 0;

                content = value;

                CheckStatusContainer();

                ContainerStatusEvent?.Invoke(this, new ContainerStatusEvent(ContainerStatus, AllowOverflowing));
            }
        }

        private void CheckStatusContainer()
        {
            if (Content == Capacity)
            {
                ContainerStatus = ContainerStatus.Full;
            }
            else if (Content == Capacity && Overflowed > 0)
            {
                ContainerStatus = ContainerStatus.Overflowing;
            }
            else if (Content < Capacity)
            {
                ContainerStatus = ContainerStatus.NotFull;
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
    }
}
