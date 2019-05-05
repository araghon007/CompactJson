﻿using System;

namespace CompactJson
{
#if COMPACTJSON_PUBLIC
    public
#endif
    class JsonValueConverter : ConverterBase
    {
        private readonly bool mAllowJsonNull;
        private readonly bool mAllowJsonArray;
        private readonly bool mAllowJsonFloat;
        private readonly bool mAllowJsonLong;
        private readonly bool mAllowJsonString;
        private readonly bool mAllowJsonBoolean;
        private readonly bool mAllowJsonObject;
        private readonly bool mAcceptNull;

        public JsonValueConverter(Type type, bool allowJsonNull = false, bool allowJsonArray = false, bool allowJsonFloat = false, bool allowJsonLong = false, bool allowJsonString = false, bool allowJsonBoolean = false, bool allowJsonObject = false, bool acceptNull = false)
            : base(type)
        {
            mAllowJsonNull = allowJsonNull;
            mAllowJsonArray = allowJsonArray;
            mAllowJsonFloat = allowJsonFloat;
            mAllowJsonLong = allowJsonLong;
            mAllowJsonString = allowJsonString;
            mAllowJsonBoolean = allowJsonBoolean;
            mAllowJsonObject = allowJsonObject;
            mAcceptNull = acceptNull;
        }

        public override object FromNull()
        {
            if (mAllowJsonNull)
                return new JsonNull();

            if (mAcceptNull)
                return null;

            return base.FromNull();
        }

        public override IJsonArrayConsumer FromArray(Action<object> whenDone)
        {
            if (!mAllowJsonArray)
                return base.FromArray(whenDone);

            return new JsonArray(whenDone);
        }

        public override object FromBoolean(bool value)
        {
            if (!mAllowJsonBoolean)
                return base.FromBoolean(value);

            return new JsonBoolean(value);
        }

        public override object FromNumber(double value)
        {
            if (!mAllowJsonFloat)
                return base.FromNumber(value);

            return new JsonFloat(value);
        }

        public override object FromNumber(long value)
        {
            if (!mAllowJsonLong)
                return base.FromNumber(value);

            return new JsonLong(value);
        }

        public override object FromString(string value)
        {
            if (!mAllowJsonString)
                return base.FromString(value);

            return new JsonString(value);
        }

        public override IJsonObjectConsumer FromObject(Action<object> whenDone)
        {
            if (!mAllowJsonObject)
                return base.FromObject(whenDone);

            return new JsonObject(whenDone);
        }

        public override void Write(object value, IJsonConsumer writer)
        {
            ((JsonValue)value).Write(writer);
        }
    }
}