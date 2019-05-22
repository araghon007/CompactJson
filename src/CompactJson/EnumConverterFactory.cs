﻿using System;
using System.Reflection;

namespace CompactJson
{
    internal class EnumConverterFactory : IConverterFactory
    {
        public bool CanConvert(Type type)
        {
            return type.IsEnum;
        }

        public IConverter Create(Type type, ConverterParameters converterParameters)
        {
            if (!type.IsEnum)
                throw new ArgumentException($"Type '{type}' was expected to be an enum.");

            return new EnumConverter(type);
        }
    }
}
