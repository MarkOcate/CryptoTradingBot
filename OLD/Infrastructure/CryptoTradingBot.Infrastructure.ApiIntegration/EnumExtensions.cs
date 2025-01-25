using System;
using System.ComponentModel;
using System.Reflection;

namespace CryptoTradingBot.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description of an enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The description if available; otherwise, the name of the enum.</returns>
        public static string GetDescription(this Enum value)
        {
            // Get the field representing the enum value
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                // Retrieve the DescriptionAttribute if it exists
                DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            // If no DescriptionAttribute exists, return the enum name
            return value.ToString();
        }
    }
}
