using System;

namespace monohttphandler
{
	internal static class Helpers
	{
		/// <summary>
		/// Clamp the specified value to the min/max range.
		/// </summary>
		/// <param name="val">The value to clamp.</param>
		/// <param name="min">The minimum value allowed.</param>
		/// <param name="max">The maximum value allowed.</param>
		/// <typeparam name="T">The compared type must implement the IComparable interface.</typeparam>
		public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
		{
			if (val.CompareTo(min) < 0) return min;
			else if (val.CompareTo(max) > 0) return max;
			else return val;
		}
	}
}

