using System;

public class WeatherDataRecord
{
    public int Id { get; set; }
    public DateTime DownloadTimestamp { get; set; }
    public bool IsStationOnline { get; set; }
    public string? JsonData { get; set; }
}