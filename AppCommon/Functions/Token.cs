using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCommon.Functions
{
    public static class Token
    {
        public static string GeneratePoolerToken()
        {
            return Generate("05", "01", "03", "09", "00", "01");
        }

        public static bool ValidatePoolerToken(string token)
        {
            return Validate(token, Encrypter.Encrypt("050103090001"));
        }

        private static bool Validate(string token, string correctToken)
        {
            if (token.Length < 28) return false;

            int i1 = Convert.ToInt32(token.Substring(22, 1));
            int i2 = Convert.ToInt32(token.Substring(23, 1));

            int i3 = Convert.ToInt32(token.Substring(24, 1));
            int i4 = Convert.ToInt32(token.Substring(25, 1));

            int i5 = Convert.ToInt32(token.Substring(26, 1));
            int i6 = Convert.ToInt32(token.Substring(27, 1));

            string v1 = token.Substring(i1 * 2, 2);
            string v2 = token.Substring(i2 * 2, 2);

            string v3 = token.Substring(i3 * 2, 2);
            string v4 = token.Substring(i4 * 2, 2);

            string v5 = token.Substring(i5 * 2, 2);
            string v6 = token.Substring(i6 * 2, 2);

            return v1 + v2 + v3 + v4 + v5 + v6 == Encrypter.Decrypt(correctToken);
        }

        private static string Generate(string value1, string value2, string value3, string value4, string value5, string value6)
        {
            try
            {
                Random random = new Random(DateTime.Now.Millisecond);

                string[] token = new string[14];

                IList<int> tokenPos = new List<int>();

                string t1 = random.Next(0, 99).ToString();
                string t2 = random.Next(0, 99).ToString();
                string t3 = random.Next(0, 99).ToString();
                string t4 = random.Next(0, 99).ToString();
                string t5 = random.Next(0, 99).ToString();

                int i = 1;
                while (i <= 6)
                {
                    int pos = Convert.ToInt32(random.Next(0, 9).ToString());
                    if (tokenPos.All(it => it != pos))
                    {
                        tokenPos.Add(pos);
                        i++;
                    }
                }

                int iValue = 1;
                string tokenEnd1 = string.Empty;
                string tokenEnd2 = string.Empty;
                string tokenEnd3 = string.Empty;
                string tokenEnd4 = string.Empty;
                string tokenEnd5 = string.Empty;
                string tokenEnd6 = string.Empty;

                foreach (int tokenPo in tokenPos)
                {
                    string value = string.Empty;

                    switch (iValue)
                    {
                        case 1:
                            value = value1;
                            tokenEnd1 = tokenPo.ToString();
                            break;
                        case 2:
                            value = value2;
                            tokenEnd2 = tokenPo.ToString();
                            break;
                        case 3:
                            value = value3;
                            tokenEnd3 = tokenPo.ToString();
                            break;
                        case 4:
                            value = value4;
                            tokenEnd4 = tokenPo.ToString();
                            break;
                        case 5:
                            value = value5;
                            tokenEnd5 = tokenPo.ToString();
                            break;
                        case 6:
                            value = value6;
                            tokenEnd6 = tokenPo.ToString();
                            break;
                    }

                    token[tokenPo] = value;
                    iValue++;
                }

                iValue = 1;
                int iRandom = 0;
                while (iRandom <= 9)
                {
                    if (string.IsNullOrEmpty(token[iRandom]))
                    {

                        string value = string.Empty;

                        switch (iValue)
                        {
                            case 1:
                                value = "0" + t1;
                                break;
                            case 2:
                                value = "0" + t2;
                                break;
                            case 3:
                                value = "0" + t3;
                                break;
                            case 4:
                                value = "0" + t4;
                                break;
                        }

                        if (value.Length >= 3)
                            value = value.Substring(1, 2);

                        token[iRandom] = value;
                        iValue++;
                    }

                    iRandom++;
                }

                string valueEnd = "0" + t5;
                if (valueEnd.Length >= 3)
                    valueEnd = valueEnd.Substring(1, 2);

                token[10] = valueEnd;
                token[11] = tokenEnd1 + tokenEnd2;
                token[12] = tokenEnd3 + tokenEnd4;
                token[13] = tokenEnd5 + tokenEnd6;

                string final = string.Empty;

                foreach (string s in token)
                    final = final + s;

                return final;
            }
            catch (Exception)
            {
                return "0000000000000000000000000000";
            }
        }

    }
}
