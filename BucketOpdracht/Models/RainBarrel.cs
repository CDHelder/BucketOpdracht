namespace BucketOpdracht.Models
{
    public enum RainBarrelSize : int
    {
        Small = 80,
        Medium = 100,
        Large = 120
    }
    public class RainBarrel : Container
    {
        public RainBarrel(RainBarrelSize size, bool allowOverflow) : base((int)size, allowOverflow)
        {

        }

        public RainBarrel(RainBarrelSize size, int content, bool allowOverflow) : base((int)size, content, allowOverflow)
        {

        }
    }
}
