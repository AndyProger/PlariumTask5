using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetterSpace;
using UserSpace;

namespace CollectionOfUsers
{
    class UsersCollection 
    {
        // ключ - пользователь, значение - список писем
        public static Dictionary<User, List<Letter>> _dictionary;
        public static Dictionary<User, List<Letter>> Dictionary 
        {
            get => new Dictionary<User, List<Letter>>(_dictionary);
        }

        // статический к-ор для инициализации словаря 
        static UsersCollection() => _dictionary = new Dictionary<User, List<Letter>>();

        public static void AddUser(User user) => _dictionary.Add(user, user.Letters);

        // пользователь с самым коротким письмом
        public static User FindUserWithTheShortesLetter()
        {
            var minLength = int.MaxValue;
            User soughtUser = null;

            foreach(var item in Dictionary)
            {
                foreach(var letter in item.Value)
                {
                    if(letter.Text.Length < minLength)
                    {
                        minLength = letter.Text.Length;
                        soughtUser = item.Key; 
                    }
                }
            }

            return soughtUser;
        }

        // информация о пользователях и их количестве полученных / отправленных писем
        public static string GetUsersInfo()
        {
            StringBuilder info = new StringBuilder();

            foreach(var item in Dictionary)
            {
                info.Append(item.Key + $"Sent letters: {item.Key.LettersSent}\n" +
                    $"Received letters: {item.Key.LettersReceived}\n\n");
            }

            return info.ToString();
        }

        // информация о пользователях, которые получили хотя бы одно сообщение с заданной темой
        public static string GetUsersWithSuchTopic(string topic)
        {
            StringBuilder info = new StringBuilder();

            foreach (var item in Dictionary)
            {
                foreach (var letter in item.Value)
                {
                    if (letter.Topic == topic)
                    {
                        info.Append(item.Key + "\n");
                    }
                }
            }

            return info.ToString();
        }

        // информация о пользователях, которые не получали сообщения с заданной темой.
        public static string GetUsersWithoutSuchTopic(string topic)
        {
            StringBuilder info = new StringBuilder();
            bool hasSuchTopic;

            foreach (var item in Dictionary)
            {
                hasSuchTopic = false;

                if (!item.Value.Any())
                {
                    info.Append(item.Key + "\n");
                    break;
                }

                foreach (var letter in item.Value)
                {
                    if (letter.Topic == topic)
                    {
                        hasSuchTopic = true;
                    }
                }

                if(!hasSuchTopic)
                    info.Append(item.Key + "\n");
            }

            return info.ToString();
        }

        // индексатор, возвращает копию письма пользователя по указанному индексу
        public Letter this[User user, int letterIndex]
        {
            get => new Letter(_dictionary [user][letterIndex]);
        }

        // индексатор, возвращает копию списка писем указанного пользователя
        public List<Letter> this[User user]
        {
            get => new List<Letter>(_dictionary[user]);
        }

        // итератор по пользователям
        public IEnumerator GetEnumerator() => _dictionary.Keys.GetEnumerator();

    }
}
