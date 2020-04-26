using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Asset : ICustomSerializer
    {
        private static readonly Regex MultyZeroRegex = new Regex("^0{2,}");


        public long Amount { get; private set; }

        public AssetSymbolType Symbol { get; private set; }


        public Asset()
        {
        }

        public Asset(long amount, uint assetNum)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(assetNum);
        }


        public void FromNewFormat(long amount, byte decimalPlaces, string value)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(decimalPlaces, value);
        }

        public void FromOldFormat(string asset)
        {
            FromOldFormat(asset, CultureInfo.InvariantCulture);
        }

        public void FromOldFormat(string asset, CultureInfo cultureInfo)
        {
            asset = MultyZeroRegex.Replace(asset, "0");
            var args = asset.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length != 2)
                throw new InvalidCastException($"Error cast {asset} to Asset");

            switch (args[1])
            {
                case Config.Hbd:
                    Symbol = new AssetSymbolType(Config.HiveAssetNumHbd);
                    break;
                case Config.Hive:
                    Symbol = new AssetSymbolType(Config.HiveAssetNumHive);
                    break;
                case Config.Vests:
                    Symbol = new AssetSymbolType(Config.HiveAssetNumVests);
                    break;
                default:
                    throw new InvalidCastException($"Error cast {asset} to Asset");
            }

            var val = args[0].Replace(cultureInfo.NumberFormat.NumberGroupSeparator, "");
            var dec = val.IndexOf(cultureInfo.NumberFormat.NumberDecimalSeparator, StringComparison.Ordinal);

            string amount;
            if (dec > -1)
            {
                dec = val.Length - dec - 1;
                if (dec > Symbol.Decimals())
                    throw new InvalidCastException($"Error cast {asset} to Asset");

                amount = val.Replace(cultureInfo.NumberFormat.NumberDecimalSeparator, "");
                if (dec != Symbol.Decimals())
                {
                    amount += new string('0', Symbol.Decimals() - dec);
                }
            }
            else
            {
                amount = val + new string('0', Symbol.Decimals());
            }

            Amount = long.Parse(amount);
        }


        public override string ToString()
        {
            var dig = ToDoubleString(CultureInfo.CurrentCulture);

            string currency;
            switch (Symbol.AssetNum)
            {
                case Config.HiveAssetNumHbd:
                    {
                        currency = Config.Hbd;
                        break;
                    }
                case Config.HiveAssetNumHive:
                    {
                        currency = Config.Hive;
                        break;
                    }
                case Config.HiveAssetNumVests:
                    {
                        currency = Config.Vests;
                        break;
                    }
                default:
                    return $"{Amount}{Symbol.ToNaiString()}";
            }

            return string.IsNullOrEmpty(currency) ? dig : $"{dig} {currency}";
        }

        public string ToOldFormatString()
        {
            return ToOldFormatString(CultureInfo.InvariantCulture);
        }

        public string ToOldFormatString(CultureInfo cultureInfo)
        {
            var dig = ToDoubleString(cultureInfo);

            string currency;
            switch (Symbol.AssetNum)
            {
                case Config.HiveAssetNumHbd:
                    {
                        currency = Config.Hbd;
                        break;
                    }
                case Config.HiveAssetNumHive:
                    {
                        currency = Config.Hive;
                        break;
                    }
                case Config.HiveAssetNumVests:
                    {
                        currency = Config.Vests;
                        break;
                    }
                default:
                    throw new InvalidCastException();
            }

            return string.IsNullOrEmpty(currency) ? dig : $"{dig} {currency}";
        }


        public string ToDoubleString()
        {
            return ToDoubleString(CultureInfo.InvariantCulture);
        }

        public string ToDoubleString(CultureInfo cultureInfo)
        {
            var dig = Amount.ToString();
            var precision = Symbol.Decimals();
            if (precision > 0)
            {
                if (dig.Length <= precision)
                {
                    var prefix = new string('0', precision - dig.Length + 1);
                    dig = prefix + dig;
                }

                dig = dig.Insert(dig.Length - precision, cultureInfo.NumberFormat.NumberDecimalSeparator);
            }

            return dig;
        }


        public double ToDouble()
        {
            return ToDouble(CultureInfo.InvariantCulture);
        }

        public double ToDouble(CultureInfo cultureInfo)
        {
            return double.Parse(ToDoubleString(cultureInfo), cultureInfo);
        }


        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            serializeHelper.AddToMessageStream(stream, typeof(long), Amount);
            Symbol.Serializer(stream, serializeHelper);
        }

        #endregion
    }
}