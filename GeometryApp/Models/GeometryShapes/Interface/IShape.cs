namespace GeometryApp.Models.GeometryShapes.Interface
{
	public interface IShape
	{
		/// <summary>
		///     Возвращает инфу о фигуре.
		/// </summary>
		/// <returns>Строковая информаця об объекте</returns>
		string GetShapeInfo();

		/// <summary>
		///     Возвращает имя фигуры
		/// </summary>
		/// <returns></returns>
		string GetShapeName();
	}
}