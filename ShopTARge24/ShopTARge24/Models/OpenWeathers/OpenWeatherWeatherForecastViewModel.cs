namespace ShopTARge24.Models.OpenWeathers
{
    public class OpenWeatherWeatherForecastViewModel
    {
        //City Name
        public string Name { get; set; }
        public double Temp {  get; set; }
        public double FeelsLike { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        //Wind Speed
        public double Speed { get; set; }
        //Weather Conditions
        public string Desctiption { get; set; }
    }
}
