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
        public RainBarrel(RainBarrelSize size) : base((int)size)
        {

        }

        public RainBarrel(RainBarrelSize size, int content) : base((int)size, content)
        {

        }
    }
}
