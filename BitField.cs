namespace trees
{
	sealed class BitField
	{
		uint data;
		public BitField(uint source) => data = source;
		public BitField(ushort source) => data = source;

		public bool this[int i]
		{
			get => (data & (1 << i)) != 0;
			set => data |= (uint)(~((value ? 1 : 0) << i));
		}

		public static implicit operator uint(BitField bit) => bit.data;
		public static implicit operator BitField(uint data) => new BitField(data);
		public static implicit operator BitField(ushort data) => new BitField(data);
	}
}