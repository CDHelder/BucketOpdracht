using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketOpdracht.Models
{
    public class OilBarrel : Container
    {
        public OilBarrel() : base(159)
        {

        }
        public OilBarrel(int content) : base(159, content)
        {

        }
    }
}
