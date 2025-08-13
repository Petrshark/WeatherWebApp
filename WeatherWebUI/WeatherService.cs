using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Xml.Serialization;

public class WeatherService
{
    private readonly string _url;
    private readonly HttpClient _httpClient;

    public WeatherService(string url)
    {
        _url = url;
        _httpClient = new HttpClient();
    }

    public async Task<string> GetWeatherDataAsync()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_url);
            response.EnsureSuccessStatusCode();
            string xmlContent = await response.Content.ReadAsStringAsync();
            return xmlContent;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Chyba při stahování dat z meteostanice: {ex.Message}");
            return null;
        }
    }

    
    public string ParseXmlToJson(string xmlContent)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Wario));
            Wario? warioData;
            using (TextReader reader = new StringReader(xmlContent))
            {
                warioData = (Wario?)serializer.Deserialize(reader);
            }

            string jsonString = JsonSerializer.Serialize(warioData, new JsonSerializerOptions { WriteIndented = true });

            return jsonString;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba při parsování XML a převodu na JSON: {ex.Message}");
            return null;
        }
    }
}