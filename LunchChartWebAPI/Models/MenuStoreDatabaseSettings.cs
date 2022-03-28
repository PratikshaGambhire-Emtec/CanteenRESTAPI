namespace LunchChartWebAPI.Models
{
    public class MenuStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MenuCollectionName { get; set; } = null!;
    }
}
