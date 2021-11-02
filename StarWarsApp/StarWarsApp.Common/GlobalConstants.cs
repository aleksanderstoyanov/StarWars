namespace StarWarsApp.Common
{
    public static class GlobalConstants
    {
        public const string Movies_Cache_Key = "movie_key";
        public const string Characters_Cache_Key = "characters_key";
        public static class Characters
        {
            public const int MinHeight = 1;
            public const int MaxHeight = 500;

            public const int MinMass = 1;
            public const  int MaxMass = 900;

            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;

            public const int MinHairColorLength = 3;
            public const int MaxHairColorLength = 40;

            public const int MinSkinColorLength = 3;
            public const int MaxSkinColorLength = 20;

            public const int MinEyeColor = 3;
            public const int MaxEyeColor = 20;

            public const int MinGenderLength = 2;
            public const int MaxGenderLength = 20;
        }
    }
}
