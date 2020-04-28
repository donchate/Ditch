using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Ditch.Hive.Models;
using Ditch.Hive.Operations;

namespace Ditch.Hive.Converters
{
    public class NewJsonConverter : CondenserJsonConverter
    {

        protected override void InitDictionary()
        {
            ExtendedTypeNames = new Dictionary<string, (Func<JsonReader, Type, object, JsonSerializer, object>, Action<JsonWriter, JsonSerializer, object>)>
            {
                {nameof(Asset), (ReadAsset, WriteAsset)},
                {nameof(LegacyAsset), (ReadLegacyAsset, WriteLegacyAsset)},
                {nameof(Operation), (ReadOperation,WriteOperation)},
                {nameof(CommentPayoutBeneficiaries), (ReadCommentPayoutBeneficiaries, WriteCommentPayoutBeneficiaries)},
            };
        }

        #region Asset

        protected override void WriteAsset(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (Asset)obj;
            writer.WriteStartObject();

            writer.WritePropertyName("amount");
            writer.WriteValue(value.Amount);

            writer.WritePropertyName("precision");
            writer.WriteValue(value.Symbol.Decimals());

            writer.WritePropertyName("nai");
            writer.WriteValue(value.Symbol.ToNaiString());

            writer.WriteEndObject();
        }

        protected override Asset ReadAsset(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var asset = new Asset();

            // Asset as JSON object such as from condenser_api
            if (reader.TokenType == JsonToken.StartObject)
            {
                reader.Read();
                var val = reader.ReadAsString();
                var amount = long.Parse(val);
                reader.Read();
                var decimalPlaces = (byte)reader.ReadAsInt32();
                reader.Read();
                var nai = reader.ReadAsString();
                reader.Read();

                asset.FromNewFormat(amount, decimalPlaces, nai);

            }
            // Asset as string such as from hivemind
            else if (reader.TokenType == JsonToken.String)
            {
                //reader.Read();
                var val = reader.Value.ToString();
                asset.FromOldFormat(val);
            }
            else
            {
                throw new InvalidCastException($"{reader.TokenType} to Asset");
            }

            return asset;
        }

        #endregion

        #region LegacyAsset

        protected override void WriteLegacyAsset(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (Asset)obj;
            writer.WriteStartObject();

            writer.WritePropertyName("amount");
            writer.WriteValue(value.Amount);

            writer.WritePropertyName("precision");
            writer.WriteValue(value.Symbol.Decimals());

            writer.WritePropertyName("nai");
            writer.WriteValue(value.Symbol.ToNaiString());

            writer.WriteEndObject();
        }

        protected override LegacyAsset ReadLegacyAsset(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new InvalidCastException($"{reader.TokenType} to Asset");

            reader.Read();
            var val = reader.ReadAsString();
            var amount = long.Parse(val);
            reader.Read();
            var decimalPlaces = (byte)reader.ReadAsInt32();
            reader.Read();
            var nai = reader.ReadAsString();
            reader.Read();

            var asset = new LegacyAsset();
            asset.FromNewFormat(amount, decimalPlaces, nai);


            return asset;
        }

        #endregion

        #region Operation

        protected override void WriteOperation(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            BaseOperation value = (Operation)obj;
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteValue(value.TypeName);
            writer.WritePropertyName("value");
            serializer.Serialize(writer, value);
            writer.WriteEndObject();
        }

        protected override Operation ReadOperation(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var opName = reader.ReadAsString();
            reader.Read();
            reader.Read();

            var op = DeserializeOperation(reader, serializer, opName);

            reader.Read();

            return new Operation(op);
        }

        #endregion

        #region CommentPayoutBeneficiaries

        protected virtual void WriteCommentPayoutBeneficiaries(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (CommentPayoutBeneficiaries)obj;
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteValue(CommentPayoutBeneficiaries.OperationName);
            writer.WritePropertyName("value");

            writer.WriteStartObject();
            writer.WritePropertyName("beneficiaries");
            serializer.Serialize(writer, value.Beneficiaries);
            writer.WriteEndObject();

            writer.WriteEndObject();
        }

        protected virtual CommentPayoutBeneficiaries ReadCommentPayoutBeneficiaries(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var beneficiaries = serializer.Deserialize<Beneficiary[]>(reader);
            return new CommentPayoutBeneficiaries(beneficiaries);
        }

        #endregion
    }
}
