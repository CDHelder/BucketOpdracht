namespace BucketOpdracht.Models
{
    public class OilBarrel : Container
    {
        public OilBarrel(bool allowOverflow) : base(159, allowOverflow)
        {

        }
        public OilBarrel(int content, bool allowOverflow) : base(159, content, allowOverflow)
        {

        }
    }
}
