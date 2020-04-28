using Cryptography.ECDSA;

namespace Ditch.Hive
{
    public class Config
    {
        public static byte[] ChainId { get; set; } = new byte[32];
        public static string KeyPrefix { get; set; } = "STM";
        public const string MinVersion = "0.23.0";

        public const string Hive = "HIVE";
        public const string Hbd = "HBD";
        public const string Vests = "VESTS";

        public const int HiveAssetSymbolPrecisionBits = 4;
        public const uint SmtMaxNai = 99999999;
        public const byte HivePrecisionHbd = 3;
        public const byte HivePrecisionHive = 3;
        public const byte HivePrecisionVests = 6;

        public const byte HiveNaiHbd = 1;
        public const byte HiveNaiHive = 2;
        public const byte HiveNaiVests = 3;

        public const uint HiveAssetNumHbd = ((SmtMaxNai + HiveNaiHbd) << HiveAssetSymbolPrecisionBits) | HivePrecisionHbd;
        public const uint HiveAssetNumHive = ((SmtMaxNai + HiveNaiHive) << HiveAssetSymbolPrecisionBits) | HivePrecisionHive;
        public const uint HiveAssetNumVests = ((SmtMaxNai + HiveNaiVests) << HiveAssetSymbolPrecisionBits) | HivePrecisionVests;

        //public const UInt64 VestsSymbolU64 = 0x0000005354534556; //((UInt64)'V' | ((UInt64)'E' << 8) | ((UInt64)'S' << 16) | ((UInt64)'T' << 24) | ((UInt64)'S' << 32));
        //public const UInt64 SteemSymbolU64 = 0x0000004d45455453; //((UInt64)'S' | ((UInt64)'T' << 8) | ((UInt64)'E' << 16) | ((UInt64)'E' << 24) | ((UInt64)'M' << 32));
        //public const UInt64 SbdSymbolU64 = 0x0000000000444253; //((UInt64)'S' | ((UInt64)'B' << 8) | ((UInt64)'D' << 16));

        public const ulong VestsSymbolSer = 0x0000535453455606; //((UInt64)6 | (VestsSymbolU64 << 8)); // < VESTS|VESTS with 6 digits of precision;
        public const ulong HiveSymbolSer = 0x00004d4545545303; //((UInt64)3 | (SteemSymbolU64 << 8)); // < STEEM|TESTS with 3 digits of precision;
        public const ulong HbdSymbolSer = 0x0000000044425303; //((UInt64)3 | (SbdSymbolU64 << 8));     // < SBD|TBD with 3 digits of precision;

        //public const UInt64 VestsSymbolU64 = 0x0000005354534556; // ((UInt64)'V' | ((UInt64)'E' << 8) | ((UInt64)'S' << 16) | ((UInt64)'T' << 24) | ((UInt64)'S' << 32));
        //public const UInt64 SteemSymbolU64 = 0x0000005354534554; // ((UInt64)'T' | ((UInt64)'E' << 8) | ((UInt64)'S' << 16) | ((UInt64)'T' << 24) | ((UInt64)'S' << 32));
        //public const UInt64 SbdSymbolU64 = 0x0000000000444254;   // ((UInt64)'T' | ((UInt64)'B' << 8) | ((UInt64)'D' << 16));

        //public const UInt64 VestsSymbolSer = 0x0000535453455606; //((UInt64)6 | (VestsSymbolU64 << 8)); // < VESTS|VESTS with 6 digits of precision;
        //public const UInt64 SteemSymbolSer = 0x0000535453455403; //((UInt64)3 | (SteemSymbolU64 << 8)); // < STEEM|TESTS with 3 digits of precision;
        //public const UInt64 SbdSymbolSer = 0x0000000044425403;   //((UInt64)3 | (SbdSymbolU64 << 8));   // < SBD|TBD with 3 digits of precision;

        public string[] ChainFieldName { get; set; } = { "HIVE_CHAIN_ID" };
    }
}