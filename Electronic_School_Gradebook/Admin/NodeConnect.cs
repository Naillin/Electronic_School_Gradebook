using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_School_Gradebook.Admin
{
	/// <summary>
	/// Структура для хранения связи узлов с элементами базы данных.
	/// </summary>
	internal struct NodeConnect
	{
		/// <summary>
		/// Типы записей.
		/// </summary>
		public enum Types
		{
			NONE = 0,
			TEACHER = 1,
			STUDENT = 2,
			CLASS = 3,
			SUBJECT = 4,
			PARENT = 5
		}

		public TreeNode node;
		public int id;
		public Types type;

		/// <summary>
		/// Инициализирует новый экземпляр класса NodeConnect.
		/// </summary>
		/// <param name="node">Узел дерева.</param>
		/// <param name="id">Идендификатор соотвествующий записи в базе данных.</param>
		/// <param name="type">Тип записи.</param>
		public NodeConnect(TreeNode node = null, int id = -1, Types type = Types.NONE)
		{
			this.node = node;
			this.id = id;
			this.type = type;
		}
	}
}
