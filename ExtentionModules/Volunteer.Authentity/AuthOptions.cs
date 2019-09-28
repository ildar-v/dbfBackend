namespace Volunteer.Authentity
{
    public static class AuthOptions
    {
        public const string Issuer = "Volunteer"; // издатель токена
        public const string Audience = "Client"; // потребитель токена
        public const string Key = "somethink_secret_key";   // ключ для шифрации
        public const int LifeTimeInMinutes = 100; // время жизни токена - 100 минута
    }
}
