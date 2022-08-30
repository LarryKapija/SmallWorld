using System;
using System.Drawing;

namespace SmallWorld.Utils
{
	public static class Extensions
	{
        public static int IndexOf(this Array array, object element)
        {
            return Array.IndexOf(array, element);
        }
    }
}

