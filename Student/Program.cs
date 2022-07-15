using System.Reflection;

namespace Student
{
    internal class Program
    {
        public static void DisplayPublicProperties()
        {
            var student = Activator.CreateInstance<Student>();
            
            foreach (var property in typeof(Student).GetProperties(BindingFlags.Instance | BindingFlags.Public)) 
            {
                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(student, RandomString(new Random().Next(4, 10)), null);
                }
                else if (property.PropertyType == typeof(int))
                {
                    property.SetValue(student, new Random().Next(0, 10), null);
                }
            }
            var displayInfo = student.GetType().GetMethod("DisplayInfo");
            displayInfo?.Invoke(student, null);
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            for(int i = 0; i < 3; i++) // 1x só estava pobre :D
            {
                DisplayPublicProperties();
            }            
        }
    }
}