using System.Collections.Generic;

namespace Katas.FizzBuzz
{
    public class FizzBuzzer
    {
        private List<GeneratedString> genStrings;

        public List<GeneratedString> GetGeneratedStrings()
        {
            genStrings = new List<GeneratedString>();

            CreateGeneratedStringList();

            return genStrings;
        }

        private void CreateGeneratedStringList()
        {
            var min = FizzBuzzConstants.Min;
            var max = FizzBuzzConstants.Max;

            for (int i = min; i <= max; i++)
            {
                string fb;

                switch (
                    i % 3 == 0 && i % 5 == 0 ? FizzBuzz.FizzBuzz :
                    i % 3 == 0 ? FizzBuzz.Fizz :
                    i % 5 == 0 ? FizzBuzz.Buzz : FizzBuzz.None)
                {
                    case FizzBuzz.FizzBuzz:
                        fb = FizzBuzz.FizzBuzz.ToString();
                        break;
                    case FizzBuzz.Fizz:
                        fb = FizzBuzz.Fizz.ToString();
                        break;
                    case FizzBuzz.Buzz:
                        fb = FizzBuzz.Buzz.ToString();
                        break;
                    default:
                        fb = i.ToString();
                        break;
                }

                GeneratedString genString = new GeneratedString(i, fb);
                genStrings.Add(genString);

            }
        }
    }
}