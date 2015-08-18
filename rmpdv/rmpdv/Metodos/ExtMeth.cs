﻿using System;

namespace rmpdv
{
	public static class ExtMethods
	{
		public static bool Contains (this string source, string toCheck, StringComparison comparisonType)
		{
			return (source.IndexOf(toCheck, comparisonType) >= 0);
		}
	}

}

