using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Server;
//MS_Sql
using DatabaseTools_MSSQL;

namespace DatabaseORM_MSSQL
{
	internal class Former
	{
		static private string connectionStringReceiver;
		public Former(string connectionString)
		{
			connectionStringReceiver = connectionString;
		}

		//public Database GetDatabase()
		//{
		//	DBTools dBTools = new DBTools(connectionStringReceiver);

		//	string[] tableNames = dBTools.tableNames(dBTools.datebaseName());
		//	SqlDataAdapter[] adapterMass = new SqlDataAdapter[tableNames.Length];
		//	DataSet dataSet = new DataSet();

		//	dataSet.Clear();
		//	using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
		//	{
		//		sqlConnection.Open();

		//		for (int i = 0; i < tableNames.Length; i++)
		//		{
		//			string sql = $"SELECT * FROM {tableNames[i]}";
		//			adapterMass[i] = new SqlDataAdapter(@sql, sqlConnection);
		//			adapterMass[i].Fill(dataSet, tableNames[i]);
		//		}

		//		sqlConnection.Close();
		//	}

		//	//все херня!!!!
		//	//нельзя хранить в памяти данные
		//	//реализовать работу через хранение знаков и составление команды знаками
		//	//в памяти хранить только важные параметры ввиде образов
		//	//все вычисления на стороне базы данных
		//	Database result = new Database();
		//	Table[] tables = new Table[tableNames.Length];
		//	for(int i = 0; i < tables.Length; i++)
		//	{
		//		tables[i] = new Table();

		//		//for(int j = 0; j < dataSet.Tables)
		//	}
		//	result.table = tables;


		//	Record[] records = new Record[10000];

		//	dataSet.Clear();
		//	return result;
		//}
	}
}
