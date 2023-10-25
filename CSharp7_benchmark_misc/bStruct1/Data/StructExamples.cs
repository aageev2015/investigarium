namespace bStruct1.Data
{
	internal struct StructTinyExample
	{
		public DateTime Date { get; set; }
		public int Value { get; set; }

		public StructTinyExample() { Value = 0; Date = DateTime.Now; }
		public StructTinyExample(DateTime date, int value) { Date = date; Value = value; }
	}

	internal struct StructWithStringExample
	{
		public string Name { get; set; }
		public int Value { get; set; }

		public StructWithStringExample() { Name = String.Empty; Value = 0; }
		public StructWithStringExample(string name, int value) { Name = name; Value = value; }
	}

	internal struct StructHuge20Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;

		public int Value { get; set; }

		public StructHuge20Example() { Value = 0; }
		public StructHuge20Example(int value) { Value = value; }
	}

	internal struct StructHuge36Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public Guid Id2 { get; set; } = Guid.Empty;

		public int Value { get; set; }

		public StructHuge36Example() { Value = 0; }
		public StructHuge36Example(int value) { Value = value; }
	}

	internal struct StructHuge52Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public Guid Id2 { get; set; } = Guid.Empty;
		public Guid Id3 { get; set; } = Guid.Empty;

		public int Value { get; set; }

		public StructHuge52Example() { Value = 0; }
		public StructHuge52Example(int value) { Value = value; }
	}

	internal struct StructHuge116Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public Guid Id2 { get; set; } = Guid.Empty;
		public Guid Id3 { get; set; } = Guid.Empty;
		public Guid Id4 { get; set; } = Guid.Empty;
		public Guid Id5 { get; set; } = Guid.Empty;
		public Guid Id6 { get; set; } = Guid.Empty;
		public Guid Id7 { get; set; } = Guid.Empty;

		public int Value { get; set; }

		public StructHuge116Example() { Value = 0; }
		public StructHuge116Example(int value) { Value = value; }
	}
}
