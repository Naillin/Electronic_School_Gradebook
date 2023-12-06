using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatabaseTools_MSSQL.DBBase;

namespace DatabaseTools_MSSQL
{
	public interface IDBBase
	{
		int countRows(string table);
		int countRows(string table, string conditions);
		ColumnsNames[] columnsNames(string table);
		string[] tableNames(string database, bool flag);
		string currentUser();
		string datebaseName();
	}
}
