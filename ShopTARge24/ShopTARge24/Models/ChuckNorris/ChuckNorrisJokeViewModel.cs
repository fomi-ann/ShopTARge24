namespace ShopTARge24.Models.ChuckNorris
{
    public class ChuckNorrisJokeViewModel
    {
        public string Value { get; set; } = string.Empty;
        public string Icon_url { get; set; } = string.Empty;
        public List<string> CategoriesList { get; set; } = new();
        public string SelectedCategory { get; set; } = string.Empty;
    }
}
