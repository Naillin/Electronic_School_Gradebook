using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Интерфейс базового набора инструментов для работы с базой данных MS SQL.
	/// </summary>
	internal interface IDBBase
	{
		/// <summary>
		/// Выполнение SQL-функции COUNT(*) без условий и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <returns></returns>
		int countRows(string table);

		/// <summary>
		/// Выполнение SQL-функции COUNT(*) с условием и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		int countRows(string table, string conditions);

		/// <summary>
		/// Возвращает массив информации о всех стлбцах таблицы.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <returns></returns>
		ColumnsNames[] columnsNames(string table);

		/// <summary>
		/// Возвращает массив имен всех таблиц базы данных.
		/// </summary>
		/// <param name="database">Целевая база данных.</param>
		/// <param name="flag">Включение или отвключение отображения в строке родителя.</param>
		/// <returns></returns>
		string[] tableNames(string database, bool flag);

		/// <summary>
		/// Возвращает имя текущего пользователя базы данных.
		/// </summary>
		/// <returns></returns>
		string currentUser();

		/// <summary>
		/// Возвращает название базы данных используемой в данный момент.
		/// </summary>
		/// <returns></returns>
		string datebaseName();
	}
}
