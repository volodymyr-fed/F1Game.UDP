using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
public readonly record struct ButtonsEvent() : IByteParsable<ButtonsEvent>, IByteWritable
{
	public ButtonFlag ButtonStatus { get; init; } // Bit flags specifying which buttons are being pressed

	static ButtonsEvent IByteParsable<ButtonsEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ButtonStatus = reader.GetNextUIntEnum<ButtonFlag>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(ButtonStatus);
	}
}
