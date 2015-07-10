using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DylibInvoke
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			if (File.Exists("/System/Library/Frameworks/TestFramework.framework/TestFramework")) 
			{
				Console.WriteLine("The target already exists");
			} 
			Console.WriteLine(LibTestWrapper.CFNumberGetTypeID ());
			Console.WriteLine (LibTestWrapper.p);
			LibTestWrapper.VoidFunction ();

		}
	}
}
