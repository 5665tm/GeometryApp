using System;

namespace GeometryApp.Models.Base
{
	/// <summary>
	///     Базовая модель для всех сущностей
	///     abstract - означает что нельзя создавать экземпляры этого класса
	/// </summary>
	public abstract class BaseModel
	{
		/// <summary>
		///     Id записи GUID
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		///     Конструктор базовой модели
		/// </summary>
		public BaseModel()
		{
			// Генерация нового GUID использующегося в качестве ID
			Id = Guid.NewGuid();
		}
	}
}