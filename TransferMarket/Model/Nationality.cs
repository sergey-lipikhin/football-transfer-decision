using System.Collections.Generic;

namespace Model
{
    public class Nationality
    {
        private Dictionary<string, string> NationalityDictionary;
        private string defaultImage = "/View/Images/CountryIcons/icons8_image_96px_1.png";

        public Nationality(Dictionary<string, string> nationality_dictionary)
        {
            NationalityDictionary = new Dictionary<string, string>(nationality_dictionary);
        }

        public string GetImage(string nationality)
        {
            return NationalityDictionary.ContainsKey(nationality) ? NationalityDictionary[nationality] : defaultImage;
        }
        public bool Contains(string nationality)
        {
            return NationalityDictionary.ContainsKey(nationality);
        }
        public Dictionary<string, string>.KeyCollection GetNames()
        {
            return NationalityDictionary.Keys;
        }
        public Dictionary<string, string>.ValueCollection GetImages()
        {
            return NationalityDictionary.Values;
        }
    }
}
