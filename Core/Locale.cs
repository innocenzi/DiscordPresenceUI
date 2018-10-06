using System.Collections.ObjectModel;

namespace DiscordPresenceUI.Core
{

    /// <summary>
    /// Locale handler class.
    /// </summary>
    internal class Locale
    {

        /// <summary>
        /// Locale identifier.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Locale name for friendly usage.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets the <seealso cref="Locale"/> class for the given identifier.
        /// </summary>
        public static Locale GetLocale(string identifier)
        {
            switch (identifier)
            {
                case "fr-FR":
                    return new Locale()
                    {
                        Identifier = "fr-FR",
                        FriendlyName = "Français"
                    };

                default:
                    return new Locale()
                    {
                        Identifier = "",
                        FriendlyName = "English"
                    };
            }
        }

        /// <summary>
        /// Returns a list of handled locales.
        /// </summary>
        public static ObservableCollection<Locale> GetLocales()
        {
            return new ObservableCollection<Locale>()
            {
                Locale.GetLocale(""),
                Locale.GetLocale("fr-FR")
            };
        }
    }
}
