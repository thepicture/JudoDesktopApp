using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace JudoDesktopApp.Models.Entities
{
    public partial class User : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(UserName))
                    if (string.IsNullOrWhiteSpace(UserName))
                        return "Введите имя пользователя";
                if (columnName == nameof(PlainPassword))
                    if (string.IsNullOrWhiteSpace(PlainPassword))
                        return "Введите пароль";
                return string.Empty;
            }
        }

        public string PlainPassword { get; set; }

        public string Error
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                foreach (PropertyInfo property in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!string.IsNullOrEmpty(this[property.Name]))
                    {
                        errors.AppendLine(this[property.Name]);
                    }
                }

                return errors.ToString();
            }
        }
    }
}
