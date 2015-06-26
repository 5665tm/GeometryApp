using System;

namespace GeometryApp
{
	public class ShapeInfo
	{
		public ShapeInfo(Guid guid, ShapeType type, string info, string coordinates, string color)
		{
			Guid = guid;
			Type = type;
			Info = info;
			Coordinates = coordinates;
			Color = color;
		}

		public Guid Guid { get; set; }
		public ShapeType Type { get; set; }
		public string Info { get; set; }
		public string Coordinates { get; set; }
		public string Color { get; set; }

		public enum ShapeType
		{
			Circle,
			Rectangle,
		}
	}
}