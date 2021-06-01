using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketOpdracht.Models
{
    public class ContainerStatusEvent : EventArgs
    {
        public ContainerStatusEvent(ContainerStatus containerStatus, bool allowOverflow)
        {
            ContainerStatus = containerStatus;
            AllowOverflow = allowOverflow;
        }

        public ContainerStatus ContainerStatus { get; }
        public bool AllowOverflow { get; }
    }
}
