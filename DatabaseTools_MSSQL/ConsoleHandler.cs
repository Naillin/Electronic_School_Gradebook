using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Класс консольного обработчика.
	/// </summary>
	internal class ConsoleHandler
	{
		/// <summary>
		/// Класс консольного обработчика.
		/// </summary>
		public ConsoleHandler() { }

		/// <summary>
		/// Принимает текст и отображает его в консоли Windows.
		/// </summary>
		/// <param name="text">Текст для отображения.</param>
		public void ConsoleWriteText(string text)
		{
			// Запускаем консоль.
			if (AllocConsole())
			{
				System.Console.WriteLine(text);
				System.Console.WriteLine("---------------------------------" + Environment.NewLine);

				System.Console.WriteLine("Для выхода наберите exit.");
				while (true)
				{
					// Считываем данные.
					string output = System.Console.ReadLine();
					if (output == "exit")
						break;
				}

				// Закрываем консоль.
				FreeConsole();
			}
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool AllocConsole();

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FreeConsole();
	}
}
