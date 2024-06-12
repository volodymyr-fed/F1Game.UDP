namespace F1Game.UDP.Internal;

interface IByteWritable
{
	void WriteBytes(ref BytesWriter writer);
}
