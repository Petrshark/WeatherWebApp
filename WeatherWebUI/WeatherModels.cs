using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("wario")]
public class Wario
{
    [XmlAttribute("degree")]
    public string? Degree { get; set; }
    [XmlAttribute("pressure")]
    public string? Pressure { get; set; }
    [XmlAttribute("serial_number")]
    public string? SerialNumber { get; set; }
    [XmlAttribute("model")]
    public string? Model { get; set; }
    [XmlAttribute("firmware")]
    public string? Firmware { get; set; }
    [XmlAttribute("runtime")]
    public string? Runtime { get; set; }
    [XmlAttribute("freemem")]
    public string? Freemem { get; set; }
    [XmlAttribute("date")]
    public string? Date { get; set; }
    [XmlAttribute("time")]
    public string? Time { get; set; }

    [XmlElement("input")]
    public SensorData? Input { get; set; }
    [XmlElement("output")]
    public SensorData? Output { get; set; }
    [XmlElement("variable")]
    public Variables? Variables { get; set; }
    [XmlElement("minmax")]
    public MinMax? MinMax { get; set; }
}
public class SensorData
{
    [XmlElement("sensor")]
    public List<Sensor>? Sensors { get; set; }
}
public class Sensor
{
    [XmlElement("type")]
    public string? Type { get; set; }
    [XmlElement("id")]
    public string? Id { get; set; }
    [XmlElement("name")]
    public string? Name { get; set; }
    [XmlElement("place")]
    public string? Place { get; set; }
    [XmlElement("value")]
    public string? Value { get; set; }
}

public class Variables
{
    [XmlElement("sunrise")]
    public string? Sunrise { get; set; }
    [XmlElement("sunset")]
    public string? Sunset { get; set; }
    [XmlElement("civstart")]
    public string? Civstart { get; set; }
    [XmlElement("civend")]
    public string? Civend { get; set; }
    [XmlElement("nautstart")]
    public string? Nautstart { get; set; }
    [XmlElement("nautend")]
    public string? Nautend { get; set; }
    [XmlElement("astrostart")]
    public string? Astrostart { get; set; }
    [XmlElement("astroend")]
    public string? Astroend { get; set; }
    [XmlElement("daylen")]
    public string? Daylen { get; set; }
    [XmlElement("civlen")]
    public string? Civlen { get; set; }
    [XmlElement("nautlen")]
    public string? Nautlen { get; set; }
    [XmlElement("astrolen")]
    public string? Astrolen { get; set; }
    [XmlElement("moonphase")]
    public string? Moonphase { get; set; }
    [XmlElement("isday")]
    public string? Isday { get; set; }
    [XmlElement("bio")]
    public string? Bio { get; set; }
    [XmlElement("pressure_old")]
    public string? PressureOld { get; set; }
    [XmlElement("temperature_avg")]
    public string? TemperatureAvg { get; set; }
    [XmlElement("agl")]
    public string? Agl { get; set; }
    [XmlElement("fog")]
    public string? Fog { get; set; }
    [XmlElement("lsp")]
    public string? Lsp { get; set; }
}

public class MinMax
{
    [XmlElement("s")]
    public List<MinMaxSensor>? Sensors { get; set; }
}

public class MinMaxSensor
{
    [XmlAttribute("id")]
    public string? Id { get; set; }
    [XmlAttribute("min")]
    public string? Min { get; set; }
    [XmlAttribute("max")]
    public string? Max { get; set; }
}