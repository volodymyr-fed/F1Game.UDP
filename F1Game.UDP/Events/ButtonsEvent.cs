using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ButtonsEvent() : IByteParsable<ButtonsEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 4; // Size of the ButtonsEvent in bytes

	/// <summary>
	/// Bit flags specifying which buttons are being pressed
	/// </summary>
	public ButtonFlag ButtonStatus { get; init; } 

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
