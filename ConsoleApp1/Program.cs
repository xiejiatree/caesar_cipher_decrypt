
using System.Security.Cryptography.X509Certificates;
using System.Text;
public class Solution{
    private static Dictionary<char, int> sub_cipher = new Dictionary<char, int>(){
        { 'a', 0 },
        { 'b', 1 },
        { 'c', 2 },
        { 'd', 3 },
        { 'e', 4 },
        { 'f', 5 },
        { 'g', 6 },
        { 'h', 7 },
        { 'i', 8 },
        { 'j', 9 },
        { 'k', 10 },
        { 'l', 11 },
        { 'm', 12 },
        { 'n', 13 },
        { 'o', 14 },
        { 'p', 15 },
        { 'q', 16 },
        { 'r', 17 },
        { 's', 18 },
        { 't', 19 },
        { 'u', 20 },
        { 'v', 21 },
        { 'w', 22 },
        { 'x', 23 },
        { 'y', 24 },
        { 'z', 25 }
    };
    private static Dictionary<int, char> modular_arithmetic = new Dictionary<int, char>(){
        { 0, 'a' },
        { 1, 'b' },
        { 2, 'c' },
        { 3, 'd'},
        { 4, 'e'},
        { 5, 'f'},
        { 6, 'g'},
        { 7, 'h'},
        { 8, 'i'},
        { 9, 'j'},
        { 10, 'k'},
        { 11, 'l'},
        { 12, 'm'},
        { 13, 'n'},
        { 14, 'o'},
        { 15, 'p' },
        { 16, 'q' },
        { 17, 'r' },
        { 18, 's' },
        { 19, 't' },
        { 20, 'u'},
        { 21, 'v' },
        { 22, 'w' },
        { 23, 'x' },
        { 24, 'y' },
        { 25, 'z'}
    };
    public static void Main(string[] args){

        string text = @"zwu mkcbqcbv kcvwz gyxvwz wul yzzubzcpb. twu zwpxvwz ympxz cz y mcz ybe gpxkeb'z
luiuimul uful bpzcgcbv cz munplu. zwyz syt tzlybvu tcbgu cz syt pmfcpxt zwu nkytwcbv kcvwz
wye muub zwulu npl ruylt. bps twu spbeulue wps twu icttue cz npl zwyz yipxbz pn zciu ybe swyz
pzwul zwcbvt cb wul tiykk zpsb twu wye nyckue zp bpzcgu.";
        Dictionary<char, int> table = freqAnalysis(text);
        printDict(table);
        while(true){
            Console.WriteLine("Insert sub cipher key here:\t");
            char key = char.Parse(Console.ReadLine());
            Console.WriteLine("Insert second key here:\t");
            char key2 = char.Parse(Console.ReadLine());
            Console.WriteLine($"Mapped {key} -> {key2}");
            string plaintext = decrypt(text, key, key2);
            Console.WriteLine(plaintext);
            if(Console.ReadKey().Key==ConsoleKey.Escape) break;
        }
    }
    //Decrypt a caesar cipher map a = z
public static string decrypt(string cipherText, char key, char key2)
{
    StringBuilder decrypt = new StringBuilder();
    int index;
    // Calculate the decryption shift value using modulo 26 (assuming alphabet size)
    if(sub_cipher.GetValueOrDefault(key)>sub_cipher.GetValueOrDefault(key2)){
        //What is the forward shift? Now 25->4, what about 0 - 21 though? -21 mod 25
        index = (sub_cipher.GetValueOrDefault(key) - sub_cipher.GetValueOrDefault(key2)) % 26;
    }
    else{
        index = sub_cipher.GetValueOrDefault(key)+(sub_cipher.GetValueOrDefault(key2) - sub_cipher.GetValueOrDefault(key))% 26;
    }
    //What if we were mapping e->f, or 4->5?


    foreach (char chara in cipherText)
    {
        if (Char.IsLetter(chara))
        {   
            // Get the decrypted character using modular arithmetic
            char newChara = modular_arithmetic.GetValueOrDefault((sub_cipher.GetValueOrDefault(key)+index)%26);
            decrypt.Append(newChara);
        }
        else
        {
            // Append non-letter characters as is
            decrypt.Append(chara);
        }
    }
    
    return decrypt.ToString();
}

    // public static string sub_cipher_decrypt(){

    // }

    public static Dictionary<char, int> freqAnalysis(string cipherText){
            
        Dictionary<char, int> freqTable = new Dictionary<char, int>();

        char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        foreach(char letter in letters){
            freqTable.Add(letter, 0);
        }

        foreach(char chara in cipherText){
            if(freqTable.ContainsKey(chara)){
                freqTable[chara] = freqTable.GetValueOrDefault(chara)+1;
            }
        }
        return freqTable;
    }

    public static void printDict(Dictionary<char, int> d){
        foreach(KeyValuePair<char,int> kp in d){
            Console.WriteLine(kp.Key + "\t=\t" + kp.Value);
        }
    }
}


