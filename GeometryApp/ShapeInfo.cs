using System;

namespace GeometryApp
{
	public class ShapeInfo
	{
		public ShapeInfo(Guid guid, ShapeType type, string info, string coordinates)
		{
			Guid = guid;
			Type = type;
			Info = info;
			Coordinates = coordinates;
		}

		public Guid Guid { get; set; }
		public ShapeType Type { get; set; }
		public string Info { get; set; }
		public string Coordinates { get; set; }

		public enum ShapeType
		{
			Circle,
			Rectangle,
		}
	}
}