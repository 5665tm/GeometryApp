namespace GeometryApp.Models.GeometryShapes.Interface
{
	/// <summary>
	///     Интерфейс для фигур
	///     Интерфейс - соглашение которому должны следовать
	///     все классы которые используют этот интерфейс
	/// </summary>
	public interface IShape
	{
		/// <summary>
		///     Реализация этого метода должна возвращать информацию о фигуре
		/// </summary>
		/// <returns>Строковая информаця о фигуре</returns>
		string GetInfo();
	}
}