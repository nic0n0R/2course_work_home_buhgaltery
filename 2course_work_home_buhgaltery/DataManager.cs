using _2course_work_home_buhgaltery.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    public static class DataManager
    {
        public static void UserSerialize(List<User> users)
        {
            string filePath = "users.json";
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Converters = { new AccountConverter() }
            };
            string newUsersJson = JsonConvert.SerializeObject(users, Formatting.Indented, settings);
            File.WriteAllText(filePath, newUsersJson);
        }

        public static List<User> UserDeserialize()
        {
            List<User> users = new List<User>();
            string filePath = "users.json";

            if (File.Exists(filePath))
            {
                string usersJson = File.ReadAllText(filePath);

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Converters = { new AccountConverter() }
                };

                users = JsonConvert.DeserializeObject<List<User>>(usersJson, settings);
            }
            return users;
        }

        public static void CategoriesSerialize(string category)
        {
            string categoriesJsonPath = "categories.json";
            List<string> categories = CategoriesDeserialize();

            if (categories.Find(c => c == category) == null)
            {
                categories.Add(category);
            }
            string categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(categoriesJsonPath, categoriesJson);
        }


        public static List<string> CategoriesDeserialize() {

            string categoriesJsonPath = "categories.json";
            List<string> categories = new List<string>();

            if (File.Exists(categoriesJsonPath))
            {
                string categoriesJson = File.ReadAllText(categoriesJsonPath);
                categories = JsonConvert.DeserializeObject<List<string>>(categoriesJson);
            }

            return categories;
        }
    }
}
