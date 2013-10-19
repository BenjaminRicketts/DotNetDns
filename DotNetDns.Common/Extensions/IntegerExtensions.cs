namespace DotNetDns.Common.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsNegative(this int number)
        {
            return number < 0;
        }
    }
}