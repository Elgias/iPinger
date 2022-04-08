using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingList.Model
{
    internal class GridHostStatusItemModel
    {
        public int InnerId { get; set; }

        public string Host { get; set; }

        public long ResponseTime { get; set; }

        public Image StatusImage { get; set; }

        public GridHostStatusItemModel(int id, string host, Image statusImage)
        {
            InnerId = id;
            Host = host;
            StatusImage = statusImage;
            ResponseTime = 0;
        }

        public GridHostStatusItemModel(int id, string host, Image statusImage, long responseTime)
            : this(id,host, statusImage)
        {
            ResponseTime = responseTime;
        }
    }
}
