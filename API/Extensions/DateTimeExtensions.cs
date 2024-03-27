namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculatAge(this DateOnly dob)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);

            int age = today.Year - dob.Year;

            if(dob.AddYears(age) > today) { age--; }

            return age;
        }
    }
}
