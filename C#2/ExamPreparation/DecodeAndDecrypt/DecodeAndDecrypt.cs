using System;
using System.Text;

class DecodeAndDecrypt
{
    static void Main()
    {
        string whole = Console.ReadLine();
        DateTime start = DateTime.Now;
        whole=Decode(whole);
        DateTime end = DateTime.Now;
        Console.WriteLine("Decode:{0}",end-start);

         start = DateTime.Now;
        int cypherLength=int.Parse(FindCypherLength(whole));
        end = DateTime.Now;
        Console.WriteLine("Cypher length:{0}", cypherLength);

        Console.ReadLine();
        start = DateTime.Now;
        Console.WriteLine(whole.Length - cypherLength - 1);
        string cypher=whole.Substring(whole.Length-cypherLength-1,cypherLength);

        end = DateTime.Now;
        Console.WriteLine("Cypher:{0}", end - start);

        Console.ReadLine();
        start = DateTime.Now;
        string message = whole.Remove(whole.Length - cypherLength - 1);
        end = DateTime.Now;
        Console.WriteLine("Message:{0}", end - start);

        start = DateTime.Now;
        Console.WriteLine(Encrypt(message,cypher));
        end = DateTime.Now;
        Console.WriteLine("Encryption:{0}", end - start);

    }

    static string Encode(string message)
    {
        string newMessage = "";
        for (int i = 0; i < message.Length; i++)
        {
             newMessage = message;
            int equal = 0;
            for (int j = i+1; j < message.Length; j++)
            {
                if(message[i]==message[j])
                {
                    equal++;
                }
            }
            if(equal>1)
            {
                string repeated=message[i].ToString();
                newMessage=newMessage.Remove(i, equal + 1);
                newMessage = newMessage.Insert(i, repeated);
                newMessage = newMessage.Insert(i, (equal+1).ToString());
                
            }
            message = newMessage;
        }
        return newMessage;
    }
    static string Encrypt(string message,string cypher)
    {
        int messageLength = message.Length;
        int cypherLength = cypher.Length;

        string result = string.Empty;
        StringBuilder sb=new StringBuilder();

        if(messageLength>=cypherLength)
        {
            for (int i = 0; i < cypherLength; i++)
            {
                int charInt = 0;
                int firstChar = (int)message[i] - 65;
                int secondChar = (int)cypher[i] - 65;
                charInt = ((firstChar ^ secondChar) + 65);
                sb.Append((char)charInt);
            }
            for (int i = 0; i < messageLength-cypherLength; i++)
            {
                int charInt = 0;
                int firstChar = (int)message[i+cypherLength] - 65;
                int secondChar = (int)cypher[(i+cypherLength)%cypherLength] - 65;
                //Console.WriteLine((char)((firstChar ^ secondChar) + 65));
                charInt = ((firstChar ^ secondChar) + 65);
                sb.Append((char)charInt);
            }
            result=sb.ToString();
            return result;
        }
        else if(messageLength<cypherLength)
        {
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < messageLength; i++)
            {
                int charInt = 0;
                int firstChar = (int)message[i] - 65;
                int secondChar = (int)cypher[i] - 65;
                //Console.WriteLine((char)((firstChar ^ secondChar) + 65));
                charInt = ((firstChar ^ secondChar) + 65);
                sb2.Append((char)charInt);

            }


             message = sb2.ToString();
            for (int i = 0; i < cypherLength-messageLength; i++)
            {
                int charInt = 0;
                int firstChar = (int)message[i] - 65;
                int secondChar = (int)cypher[i + messageLength] - 65;
                //Console.WriteLine((char)((firstChar ^ secondChar) + 65));
                charInt = ((firstChar ^ secondChar) + 65);
                sb2.Append((char)charInt);
            }
            result = sb2.ToString();
            return result;
        }
        return "0";
    }

    static string Decode(string encoded)
    {
        string result = "";
        for (int i = 0; i < encoded.Length-1; i++)
        {
            StringBuilder sb1 = new StringBuilder();
            if (((int)encoded[i]) >= 48 && ((int)encoded[i]) <= 57)
            {
                
                string timesString="";
                sb1.Append(encoded[i]);
                //timesString+=encoded[i];
                for (int j = i+1; j < encoded.Length-1; i++)
                {
                    if(((int)encoded[j]) >= 48 && ((int)encoded[j]) <= 57)
                    {
                        sb1.Append(encoded[j]);
                        //timesString += encoded[j];
                    }
                    else
                    { 
                        break; 
                    }

                }
                timesString = sb1.ToString();
                sb1 = new StringBuilder();

                int timesInt = int.Parse(timesString);
                char ch=encoded[i+1];
                sb1.Insert(0, result);
                for (int j = 0;  j< timesInt-1; j++)
                {
                    sb1.Append(ch);
                    //result += ch.ToString();
                }
                
            }
            else
            {
                sb1.Append(encoded[i]);
                //result += encoded[i];
            }
            result = sb1.ToString();
        }
        result += encoded[encoded.Length - 1];
        return result;
    }

    static string FindCypherLength(string whole)
    {
        string cypherLength = "";
        for (int i = whole.Length - 1; i > 0; i--)
        {
            if (((int)whole[i]) >= 48 && ((int)whole[i]) <= 57)
            {
                cypherLength += whole[i];
            }
            else
            {
                break;
            }
        }
        string cypherLength2 = "";
        for (int i = cypherLength.Length - 1; i >= 0; i--)
        {
            cypherLength2 += cypherLength[i];
        }
        return cypherLength2;
    }
}