namespace F1Game.UDP;

interface IByteParsable<T> where T : IByteParsable<T>
{
	internal abstract static T Parse(ref BytesReader reader);
}
