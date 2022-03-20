using System.Text;

namespace Identity_API.UI.BLL
{
    public class AppManager
    {
        public static string CreateAccessToken()
        {
            StringBuilder strBuilder = new();
            Random random = new();

            char letter;
            char upperOrLowerLetter;
            string? accessToken;
            int tokenLength = 20;

            for (int i = 0; i < tokenLength; i++)
            {
                int randomNum = random.Next(1,6);
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);

                if (randomNum % 2 == 0)
                {
                    upperOrLowerLetter = Char.ToLower(letter);
                }
                else
                {
                    upperOrLowerLetter = letter;
                }
                strBuilder.Append(upperOrLowerLetter);

            }
            return accessToken = strBuilder.ToString();
        }
    }
}
