using System;
using System.IO;
using System.Text.RegularExpressions;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// asset_symbol_type
    /// libraries\protocol\include\steem\protocol\asset_symbol.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AssetSymbolType : ICustomSerializer
    {
        private static readonly Regex ValidateRegex = new Regex("(?<=^@@)[0-9]{9}$");

        /// <summary>
        /// API name: asset_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        public uint AssetNum { get; set; }


        public AssetSymbolType(uint assetNum)
        {
            AssetNum = assetNum;
        }

        public AssetSymbolType(byte decimalPlaces, string value)
        {
            var m = ValidateRegex.Match(value);
            if (!m.Success)
                throw new InvalidCastException();

            var assetNum = uint.Parse(m.Value);
            AssetNum = AssetNumFromNai(decimalPlaces, assetNum);
        }

        private static uint AssetNumFromNai(byte decimalPlaces, uint nai)
        {
            var naiDataDigits = nai / 10;

            switch (naiDataDigits)
            {
                case Config.HiveNaiHive:
                    return Config.HiveAssetNumHive;
                case Config.HiveNaiHbd:
                    return Config.HiveAssetNumHbd;
                case Config.HiveNaiVests:
                    return Config.HiveAssetNumVests;
                default:
                    return (naiDataDigits << 5) | 0x10 | decimalPlaces;
            }
        }

        public byte Decimals()
        {
            return (byte)(AssetNum & 0x0F);
        }

        public string ToNaiString()
        {
            var x = ToNai();
            return x.ToString("@@000000000");
        }

        private uint ToNai()
        {
            uint naiDataDigits;

            // Can be replaced with some clever bitshifting
            switch (AssetNum)
            {
                case Config.HiveAssetNumHive:
                    naiDataDigits = Config.HiveNaiHive;
                    break;
                case Config.HiveAssetNumHbd:
                    naiDataDigits = Config.HiveNaiHbd;
                    break;
                case Config.HiveAssetNumVests:
                    naiDataDigits = Config.HiveNaiVests;
                    break;
                default:
                    naiDataDigits = AssetNum >> 5;
                    break;
            }

            var naiCheckDigit = DammChecksum_8Digit(naiDataDigits);
            return naiDataDigits * 10 + naiCheckDigit;
        }

        private static byte DammChecksum_8Digit(uint value)
        {
            byte[] t =
            {
                0, 30, 10, 70, 50, 90, 80, 60, 40, 20,
                70, 0, 90, 20, 10, 50, 40, 80, 60, 30,
                40, 20, 0, 60, 80, 70, 10, 30, 50, 90,
                10, 70, 50, 0, 90, 80, 30, 40, 20, 60,
                60, 10, 20, 30, 0, 40, 50, 90, 70, 80,
                30, 60, 70, 40, 20, 0, 90, 50, 80, 10,
                50, 80, 60, 90, 70, 20, 0, 10, 30, 40,
                80, 90, 40, 50, 30, 60, 20, 0, 10, 70,
                90, 40, 30, 80, 60, 10, 70, 20, 0, 50,
                20, 50, 80, 10, 40, 30, 60, 70, 90, 0
            };

            var q0 = value / 10;
            var d0 = value % 10;
            var q1 = q0 / 10;
            var d1 = q0 % 10;
            var q2 = q1 / 10;
            var d2 = q1 % 10;
            var q3 = q2 / 10;
            var d3 = q2 % 10;
            var q4 = q3 / 10;
            var d4 = q3 % 10;
            var q5 = q4 / 10;
            var d5 = q4 % 10;
            var d6 = q5 % 10;
            var d7 = q5 / 10;

            var x = t[d7];
            x = t[x + d6];
            x = t[x + d5];
            x = t[x + d4];
            x = t[x + d3];
            x = t[x + d2];
            x = t[x + d1];
            x = t[x + d0];
            return (byte)(x / 10);
        }

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            switch (AssetNum)
            {
                case Config.HiveAssetNumHive:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(ulong), Config.SteemSymbolSer);
                        break;
                    }
                case Config.HiveAssetNumHbd:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(ulong), Config.SbdSymbolSer);
                        break;
                    }
                case Config.HiveAssetNumVests:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(ulong), Config.VestsSymbolSer);
                        break;
                    }
                default:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(ulong), AssetNum);
                        break;
                    }
            }
        }

        #endregion
    }
}
