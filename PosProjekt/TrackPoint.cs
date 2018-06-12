namespace PosProjekt
{
    /// <summary>
    /// Struktura przetrzymująca informacje z pliku GPS
    /// </summary>
    public struct TrackPoint
    {
        public string lat, lon, ele, speed, course, time;
        /// <param name="lat">Szerokosc geograficzna</param>
        /// <param name="lon">Dlugosc geograficzna</param>
        /// <param name="ele">Wysokosc</param>
        /// <param name="speed">Predkosc poruszania sie</param>
        /// <param name="course">Azymut</param>
        /// <param name="time">Data i czas</param>
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
