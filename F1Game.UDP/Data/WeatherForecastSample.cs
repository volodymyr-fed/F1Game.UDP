using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct WeatherForecastSample() : IByteParsable<WeatherForecastSample>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 8;

	/// <summary>
	/// The session type.
	/// </summary>
	public SessionType SessionType { get; init; }
	/// <summary>
	/// Time in minutes the forecast is for.
	/// </summary>
	public byte TimeOffset { get; init; }
	/// <summary>
	/// The weather condition.
	/// </summary>
	public Weather Weather { get; init; }
	/// <summary>
	/// Track temperature in degrees Celsius.
	/// </summary>
	public sbyte TrackTemperature { get; init; }
	/// <summary>
	/// Track temperature change.
	/// </summary>
	public TemperatureChange TrackTemperatureChange { get; init; }
	/// <summary>
	/// Air temperature in degrees Celsius.
	/// </summary>
	public sbyte AirTemperature { get; init; }
	/// <summary>
	/// Air temperature change.
	/// </summary>
	public TemperatureChange AirTemperatureChange { get; init; }
	/// <summary>
	/// Rain percentage (0-100).
	/// </summary>
	public byte RainPercentage { get; init; }

	static WeatherForecastSample IByteParsable<WeatherForecastSample>.Parse(ref BytesReader reader)
	{
		return new()
		{
			SessionType = reader.GetNextEnum<SessionType>(),
			TimeOffset = reader.GetNextByte(),
			Weather = reader.GetNextEnum<Weather>(),
			TrackTemperature = reader.GetNextSbyte(),
			TrackTemperatureChange = reader.GetNextEnum<TemperatureChange>(),
			AirTemperature = reader.GetNextSbyte(),
			AirTemperatureChange = reader.GetNextEnum<TemperatureChange>(),
			RainPercentage = reader.GetNextByte()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(SessionType);
		writer.Write(TimeOffset);
		writer.WriteEnum(Weather);
		writer.Write(TrackTemperature);
		writer.WriteEnum(TrackTemperatureChange);
		writer.Write(AirTemperature);
		writer.WriteEnum(AirTemperatureChange);
		writer.Write(RainPercentage);
	}
}
