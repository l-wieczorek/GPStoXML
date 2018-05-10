using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosProjekt
{
    public struct TrackPoint
    {
        public string lat, lon, ele, speed, course, time;

        public TrackPoint(string lat, string lon, string ele, string speed, string course, string time)
        {
            this.lat = lat;
            this.lon = lon;
            this.ele = ele;
            this.speed = speed;
            this.course = course;
            this.time = time;
        }
    }
}
