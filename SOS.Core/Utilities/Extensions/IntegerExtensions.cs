﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Utilities.Extensions
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int? ToInt(this object value)
        {
            if (value == null)
                return null;
            if (value is int)
                return (int)value;

            int result;
            if (int.TryParse(value.ToString(), out result))
                return result;

            return null;
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int ToInt(this object value, int defaultValue)
        {
            var result = value.ToInt();
            return result ?? defaultValue;
        }
    }
}
