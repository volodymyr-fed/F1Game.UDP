using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

public sealed record WeatherForecastSample : IByteParsable<WeatherForecastSample>, IByteWritable
{
	// 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
	// 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2
	// 12 = R3, 13 = Time Trial
	public SessionType SessionType { get; init; }
	// Time in minutes the forecast is for
	public byte TimeOffset { get; init; }
	// Weather - 0 = clear, 1 = light cloud, 2 = overcast
	// 3 = light rain, 4 = heavy rain, 5 = storm
	public Weather Weather { get; init; }
	// Track temp. in degrees Celsius
	public sbyte TrackTemperature { get; init; }
	// Track temp. change – 0 = up, 1 = down, 2 = no change
	public sbyte TrackTemperatureChange { get; init; }
	// Air temp. in degrees celsius
	public sbyte AirTemperature { get; init; }
	// Air temp. change – 0 = up, 1 = down, 2 = no change
	public sbyte AirTemperatureChange { get; init; }
	// Rain percentage (0-100)
	public byte RainPercentage { get; init; }

	static WeatherForecastSample IByteParsable<WeatherForecastSample>.Parse(ref BytesReader reader)
	{
		return new()
		{
			SessionType = reader.GetNextEnum<SessionType>(),
			TimeOffset = reader.GetNextByte(),
			Weather = reader.GetNextEnum<Weather>(),
			TrackTemperature = reader.GetNextSbyte(),
			TrackTemperatureChange = reader.GetNextSbyte(),
			AirTemperature = reader.GetNextSbyte(),
			AirTemperatureChange = reader.GetNextSbyte(),
			RainPercentage = reader.GetNextByte()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(SessionType);
		writer.WriteByte(TimeOffset);
		writer.WriteEnum(Weather);
		writer.WriteSByte(TrackTemperature);
		writer.WriteSByte(TrackTemperatureChange);
		writer.WriteSByte(AirTemperature);
		writer.WriteSByte(AirTemperatureChange);
		writer.WriteByte(RainPercentage);
	}
}
