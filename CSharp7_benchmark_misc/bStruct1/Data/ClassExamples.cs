using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bStruct1.Data
{
	internal class ClassTinyExample
	{
		public int Value { get; set; }

		public ClassTinyExample(int value) { Value = value; }
	}

	internal class ClassWithStringExample
	{
		public string Name { get; set; }
		public int Value { get; set; }

		public ClassWithStringExample(string name, int value) { Name = name; Value = value; }
	}

	internal class ClassHuge20Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public int Value { get; set; }

		public ClassHuge20Example(int value) { Value = value; }
	}

	internal class ClassHuge36Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public Guid Id2 { get; set; } = Guid.Empty;
		public int Value { get; set; }

		public ClassHuge36Example(int value) { Value = value; }
	}

	internal class ClassHuge52Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public Guid Id2 { get; set; } = Guid.Empty;
		public Guid Id3 { get; set; } = Guid.Empty;
		public int Value { get; set; }

		public ClassHuge52Example(int value) { Value = value; }
	}

	internal class ClassHuge116Example
	{
		public Guid Id1 { get; set; } = Guid.Empty;
		public Guid Id2 { get; set; } = Guid.Empty;
		public Guid Id3 { get; set; } = Guid.Empty;
		public Guid Id4 { get; set; } = Guid.Empty;
		public Guid Id5 { get; set; } = Guid.Empty;
		public Guid Id6 { get; set; } = Guid.Empty;
		public Guid Id7 { get; set; } = Guid.Empty;
		
		public int Value { get; set; }

		public ClassHuge116Example(int value) { Value = value; }
	}

}
