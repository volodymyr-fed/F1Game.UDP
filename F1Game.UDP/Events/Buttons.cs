using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

public sealed record Buttons : IEventDetails, IByteParsable<Buttons>
{
	public ButtonFlag ButtonStatus { get; init; } // Bit flags specifying which buttons are being pressed

	static Buttons IByteParsable<Buttons>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ButtonStatus = reader.GetNextUIntEnum<ButtonFlag>(),
		};
	}
}
