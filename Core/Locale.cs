using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordPresenceUI.Core
{
    public class Locale
    {
        public string Identifier { get; set; }
        public string FriendlyName { get; set; }

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
