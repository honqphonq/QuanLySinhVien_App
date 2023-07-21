using QuanLySinhVien.Debugging;

namespace QuanLySinhVien
{
    public class QuanLySinhVienConsts
    {
        public const string LocalizationSourceName = "QuanLySinhVien";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7d887cc470d04727860c0f43c13769b9";
    }
}
