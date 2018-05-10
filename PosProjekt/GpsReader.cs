using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosProjekt
{
    class GpsReader
    {
        public static List<TrackPoint> getGpsInfo(string filePath)
        {
            List<TrackPoint> trackPointList = new List<TrackPoint>();
            TrackPoint newTp = new TrackPoint();
            string lat = null, lon = null, ele = null, speed = null, course = null, time = null;
            System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
            while (sr.Peek() >= 0)
            {
                string gps = sr.ReadLine();
                string[] paramOfGps = null;
                if (gps != null)
                {
                    string[] separator = new string[] { "," };
                    paramOfGps = gps.Split(separator, StringSplitOptions.None);
                    if (paramOfGps[0].Equals("$GPRMC"))
                    {
                        char[] latChar = paramOfGps[3].ToCharArray();
                        char[] lonChar = paramOfGps[5].ToCharArray();
                        lat = latChar[0].ToString() + latChar[1].ToString() + "." + latChar[2].ToString() + latChar[3].ToString();
                        lon = lonChar[1].ToString() + lonChar[2].ToString() + "." + lonChar[3].ToString() + lonChar[4].ToString();
                        speed = paramOfGps[7];
                        course = paramOfGps[8];
                        char[] date = paramOfGps[9].ToCharArray();
                        char[] utc = paramOfGps[1].ToCharArray();
                        time = "20" + date[4] + date[5] + "-" + date[2] + date[3] + "-" + date[0] + date[1] + "T" + utc[0] + utc[1] + ":" + utc[2] + utc[3] + ":" + utc[4] + utc[5] + "Z";
                    }
                    else if (paramOfGps[0].Equals("$GPGGA"))
                    {
                        ele = paramOfGps[9];
                    }
                    if (lat != null && lon != null && ele != null && speed != null && course != null && time != null)
                    {
                        newTp.lat = lat;
                        newTp.lon = lon;
                        newTp.ele = ele;
                        newTp.speed = speed;
                        newTp.course = course;
                        newTp.time = time;
                        trackPointList.Add(newTp);
                        lat = null;
                        lon = null;
                        ele = null;
                        speed = null;
                        course = null;
                        time = null;
                    }
                }
            }
            return trackPointList;
        }
    }
}
