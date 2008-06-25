/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/11
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Lextm.SharpSnmpLib;
using System.Net;
using System.IO;
using Lextm.SharpSnmpLib.Mib;

namespace TestWalk
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (StreamWriter writer = new StreamWriter(File.OpenWrite("result.txt")))
			{
				IList<Variable> list = new List<Variable>();
				try {
					Manager.Walk(VersionCode.V1, IPAddress.Parse("127.0.0.1"), "public", new ObjectIdentifier(new uint[] { 1, 3, 6, 1, 2, 1, 2, 2 }), list, 1000);
				} catch (SharpTimeoutException ex) {
					Console.WriteLine(ex.Details);
				}
				foreach (Variable v in list)
				{
					writer.WriteLine(v);
				}
				writer.Close();
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}    