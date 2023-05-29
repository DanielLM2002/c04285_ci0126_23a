using System;

namespace LabCleanCode
{
    class Letters
    {
        public static void Count()
        {
            Console.WriteLine("Enter the Length of the sentence  \n");
            string strCaptured = Console.ReadLine();
            char[] sentence = strCaptured.ToCharArray();


            for (int i = 0; i< sentence.Length; i++)
            {
                int vowels = 0, consonants = 0, special = 0;
                if ((sentence[i] == 'a' || sentence[i] == 'e' || sentence[i] ==
                'i' || sentence[i] == 'o' || sentence[i] == 'u') ||
                (sentence[i] == 'A' || sentence[i] == 'E' || sentence[i] ==
                'I' || sentence[i] == 'O' || sentence[i] == 'U'))
                {
                    vowels = vowels + 1;
                }
                else
                {
                    consonants = consonants + 1;
                }
                if (sentence[i] == 't' || sentence[i] == '\0' || sentence[i] == ' ')
                {
                    special = special + 1;
                }
            }

            consonants = consonants - special;
            Console.WriteLine("No. of vowels {0}", vowels);
            Console.WriteLine("No. of consonants {0}", consonants);
            Console.ReadLine();
        }
    }
}
