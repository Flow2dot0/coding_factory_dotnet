using System;
using System.Collections;
using System.Linq;

namespace TD_console
{
    public class TD4
    {
        // Faites vos tests dans cette méthode
        public TD4()
        {

        }

        // Ne pas modifier cette méthode
        public static void Writer(string methode, string param, string attendu, string resultat)
        {
            Console.WriteLine("Test " + methode + "(" + param + ");\n"
                              + "Résultat attendu : \"" + attendu + "\";\n"
                              + "Résultat : \"" + resultat + "\";\n"
                              + "Test : " + (string.Equals(attendu, resultat) ? "ok" : "echec") + "\n\n");
        }

        // Ne pas modifier cette méthode
        public static void Test()
        {
            Writer("River_unique", "100", "1 ; 3 ; 5 ; 7 ; 9 ; 20 ; 31 ; 42 ; 53 ; 64 ; 75 ; 86 ; 97.", River_unique(100));
            Writer("Encode_RL", "abcdefghijk", "ghijbcadefk", Encode_RL("abcdefghijk"));
            Writer("Decode_RL", "ghijbcadefk", "abcdefghijk", Decode_RL("ghijbcadefk"));
            Writer("Fibonacci_is_sequence", "9", "False", Fibonacci_is_sequence(9).ToString());
            Writer("Fibonacci_previous", "8", "5", Fibonacci_previous(8).ToString());
            Writer("Fibonacci_next", "8", "13", Fibonacci_next(8).ToString());
            Writer("Fibonacci_max_sequence", "20", "0 ; 1 ; 1 ; 2 ; 3 ; 5 ; 8 ; 13 ; 21.", Fibonacci_max_sequence(20));
            Writer("Fibonacci_n_sequence", "5", "0 ; 1 ; 1 ; 2 ; 3.", Fibonacci_n_sequence(5));
            Writer("Fibonacci_delimiter", "3, 6", "1 ; 2 ; 3 ; 5.", Fibonacci_delimiter(3, 6));
            Writer("Conway_previous", "111221", "1211", Conway_previous("111221"));
            Writer("Syracuse_is_sequence", "34, 18", "False", Syracuse_is_sequence(34, 18).ToString());
            Writer("Syracuse_previous", "22", "7 ; 44.", Syracuse_previous(22));
            Writer("Syracuse_next", "42", "21", Syracuse_next(42).ToString());
            Writer("Syracuse_sequence", "20", "20 ; 10 ; 5 ; 16 ; 8 ; 4 ; 2 ; 1.", Syracuse_sequence(20));
            Writer("Syracuse_n_sequence", "14, 5", "14 ; 7 ; 22 ; 11 ; 34.", Syracuse_n_sequence(14, 5));
            Writer("Syracuse_delimiter", "14, 3, 6", "22 ; 11 ; 34 ; 17.", Syracuse_delimiter(14, 3, 6));
            Writer("Morse_to_morse", "a", ". _", Morse_to_morse('a'));
            Writer("Morse_to_char", ". _", "a", Morse_to_char(". _").ToString());
            Writer("Morse_encode", "Hello World !", ". . . .   .   . _ . .   . _ . .   _ _ _ / . _ _   _ _ _   . _ .   . _ . .   _ . . / _ _ _ .", Morse_encode("Hello World !"));
            Writer("Morse_decode", ". . . .   .   . _ . .   . _ . .   _ _ _ / . _ _   _ _ _   . _ .   . _ . .   _ . . / _ _ _ .", "Hello World !", Morse_decode(". . . .   .   . _ . .   . _ . .   _ _ _ / . _ _   _ _ _   . _ .   . _ . .   _ . . / _ _ _ ."));
        }


        public static string River_unique(long max)
        {
            string sequences = "";

            // Ne rien modifier au dessus de ce commentaire
            string presequence = "";

            // Génération d'un tableau de longueur de notre argument max
            int[] comparateur = new int[max];

            // Compteurs
            int count = 0;
            int count2 = 0;

            // Remplir le tableau avec l'ensemble des River Next
            for (int i = 1; i <= max; i++)
            {
                String river = TD1.River_next(i).ToString();

                if (int.Parse(river) < 100)
                {

                    if (Array.IndexOf(comparateur, river) <= 0)
                    {
                        comparateur[count] = int.Parse(river);
                        count++;
                    }
                }
            }

            // Tri croissant avec method .sort de Array
            Array.Sort(comparateur);

            // Import de "using System.Linq;" pour utiliser .Distinct()
            var uniqued = comparateur.Distinct();

            // Transformation en Array
            var tab = uniqued.ToArray();


            // Boucle pour remplir "presequence" avec les sequences uniques en comparant avec l'incrémentation de notre compteur
            foreach (int items in comparateur)
            {
                // Si True et égalité de la valeur avec le compteur
                if (Array.Exists(tab, element => element == count2))
                {
                    count2++;
                }
                // Sinon concaténation
                else
                {
                    presequence += count2 + " ; ";
                    count2++;
                }
            }

            //Un string est immuable donc je transforme presequence 
            //en tableau de char pour corriger le " ; " de la derniere itération 
            //de la boucle foreach ci dessus

            char[] modificateur = presequence.ToCharArray();

            modificateur[presequence.Length - 3] = '.';

            //for pour remplir sequence/ bloqué manuellement 
            //par Length-3 afin de terminer sur le '.'
            for (int i = 0; i <= (presequence.Length - 3); i++)
            {
                sequences += modificateur[i].ToString();
            }
            // Ne rien modifier au dessous de ce commentaire
            return sequences;
        }

        public static string Encode_RL(string sentence) // a.bc.def.ghij.k
        {
            string newSentence = "";
            // Ne rien modifier au dessus de ce commentaire

            int connard = sentence.Length - 1;
            int compteur = 0;
            for (int i = 0; i <= connard; i++)
            {
                if (i + compteur - 1 < connard) // adefk
                {
                    if (compteur % 2 == 0)
                    {
                        newSentence = sentence.Substring(i, compteur) + newSentence;
                    }
                    else
                    {
                        newSentence += sentence.Substring(i, compteur);
                    }
                }
                else // bcghij
                {
                    int terrible = connard - i + 1;
                    if (compteur % 2 == 0)
                    {
                        newSentence = sentence.Substring(i, terrible) + newSentence;
                    }
                    else
                    {
                        newSentence += sentence.Substring(i, terrible);
                    }
                }
                i += compteur - 1;
                compteur++;
            }
            // Ne rien modifier au dessous de ce commentaire
            return newSentence;
        }

        public static string Decode_RL(string sentence)
        {
            string newSentence = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return newSentence;
        }

        public static bool Fibonacci_is_sequence(long sequence)
        {
            bool isSequence = true;
            // Ne rien modifier au dessus de ce commentaire

            long start = 0;
            long add = 1;
            long final = 0;

            for (int i = 0; i < sequence; i++)
            {
                final = start + add;
                start = add;
                add = final;

                if (add > sequence)
                {
                    isSequence = false;
                    break;
                }
                else if (add == sequence)
                {
                    break;
                }
            }

            // Ne rien modifier au dessous de ce commentaire
            return isSequence;
        }

        public static long Fibonacci_previous(long n)
        {
            long fibonacci = 0;
            // Ne rien modifier au dessus de ce commentaire

            long a = 0;
            long b = 1;
            long nb = 1;

            while (nb <= n)
            {
                nb = a;
                a = b;
                b = nb + b;

                if (nb == n)

                {
                    fibonacci += a - nb;
                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return fibonacci;

        }

        public static long Fibonacci_next(long n)
        {
            long fibonacci = 0;
            // Ne rien modifier au dessus de ce commentaire
            long a = 0;
            long b = 1;
            long nb = 1;

            while (nb <= n)
            {
                nb = a;
                a = b;
                b = nb + b;

                if (nb > n)

                {
                    fibonacci += nb;
                }
            }

            // Ne rien modifier au dessous de ce commentaire
            return fibonacci;
        }

        public static string Fibonacci_max_sequence(long max)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire
            long tmp = 0;
            for (long i = 0; i <= max; i++)
            {
                if (i == 1 && i != max)
                {
                    sequence += "0 ; 1 ; 1 ; ";
                }
                else if (i == 1 && max == 1)
                {
                    sequence += "0 ; 1 ; 1.";
                    break;
                }

                if (Fibonacci_is_sequence(i))
                {
                    if (tmp < Fibonacci_next(i) && Fibonacci_next(i) < max)
                    {
                        tmp = Fibonacci_next(i);
                        sequence += tmp + " ; ";
                    }
                    else if (Fibonacci_next(i) >= max)
                    {
                        sequence += Fibonacci_next(i) + ".";
                        break;
                    }
                }
                else if (i == max)
                {
                    sequence += tmp + ".";
                    break;
                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }


        public static string Fibonacci_n_sequence(int n)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire
            sequence = Fibonacci_max_sequence(n - 2);
            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }


        public static string Fibonacci_delimiter(int min, int max)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire
            // On applique la méthode n sequence de Fibo sur notre arg max
            string tmp1 = Fibonacci_n_sequence(max);
            // On retire les " ; " 
            string[] tmp2 = tmp1.Split(new[] { " ; " }, StringSplitOptions.None);
            // On retire le dernier élément
            tmp2[max - 1] = tmp2[max - 1].Remove(1);

            //On boucle pour réaffecter et concaténer
            for (int tmp3 = min - 1; tmp3 <= tmp2.Length - 1; tmp3++)
            {
                if (tmp3 == tmp2.Length - 1)
                {
                    sequence += tmp2[tmp3] + ".";

                }
                else
                {
                    sequence += tmp2[tmp3] + " ; ";

                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }

        public static string Conway_previous(string start)
        {
            string conway = "";
            // Ne rien modifier au dessus de ce commentaire
            string onTry = "";

            // On parcoure le string et on attribue à onTry ce qu'on désire
            for (int i = 0; i < start.Length - 1; i = i + 2)
            {
                string tmp = start.Substring(i, 2);

                if (tmp == "11")
                {
                    onTry += '1';
                }
                else if (tmp == "12")
                {
                    onTry += '2';
                }
                else if (tmp == "21")
                {
                    onTry += "11";
                }

            }
            conway = onTry;
            // Ne rien modifier au dessous de ce commentaire
            return conway;
        }


        public static bool Syracuse_is_sequence(long syracuse, long sequence)
        {
            bool isSequence = true;
            // Ne rien modifier au dessus de ce commentaire
            int count = 1;

            // On boucle tant le compteur n'atteint pas la longeur de la séquence
            while (count != sequence)
            {
                if (syracuse <= 1)
                {
                    // On change le bool
                    isSequence = false;
                    break;
                }
                else
                {
                    if (syracuse % 2 == 0)
                    {
                        syracuse /= 2;
                    }
                    else if (syracuse % 2 != 0)
                    {
                        syracuse = (syracuse * 3) + 1;
                    }
                    count++;
                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return isSequence;
        }

        public static string Syracuse_previous(long n)
        {
            string syracuses = "";
            // Ne rien modifier au dessus de ce commentaire

            // Cas pair
            if (n % 2 == 0)
            {
                syracuses = "" + (n - 1) / 3 + " ; " + n * 2 + ".";
            }
            // Ne rien modifier au dessous de ce commentaire
            return syracuses;
        }

        public static long Syracuse_next(long n)
        {
            long syracuse = 0;
            // Ne rien modifier au dessus de ce commentaire
            if (n % 2 == 0)
            {
                syracuse = n / 2;
            }
            else
            {
                syracuse = (n * 3) + 1;
            }
            // Ne rien modifier au dessous de ce commentaire
            return syracuse;
        }

        public static string Syracuse_sequence(long syracuse)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire

            sequence += syracuse + " ; ";
            while (syracuse != 1)
            {
                if (syracuse % 2 == 0)
                {
                    syracuse = syracuse / 2;
                }
                else
                {
                    syracuse = (syracuse * 3) + 1;
                }

                if (syracuse == 1)
                {
                    sequence += syracuse + ".";
                }
                else
                {
                    sequence += syracuse + " ; ";
                }
            }


            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }

        public static string Syracuse_n_sequence(long syracuse, int n)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire
            sequence = syracuse + " ; ";

            for (int i = 1; i < n; i++)
            {
                syracuse = Syracuse_next(syracuse);
                if (i == n - 1)
                {
                    sequence += syracuse + ".";

                }
                else
                {
                    sequence += syracuse + " ; ";
                }

            }
            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }

        public static string Syracuse_delimiter(long syracuse, int min, int max)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire
            long[] table = new long[max];
            for (int i = 0; i <= max - 1; i++)
            {

                syracuse = Syracuse_next(syracuse);
                table[i] = syracuse;

                if ((i == min - 1) || (i > min - 1 && i < max - 1))
                {
                    sequence += table[i - 1] + " ; ";

                }
                else if (i == max - 1)
                {
                    sequence += table[i - 1] + ".";
                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }
        public static string Morse_to_morse(char c)
        {
            string morse = "";
            // Ne rien modifier au dessus de ce commentaire

            // On veut obtenir le code morse correspondant à la lettre indiquée => string morse = "a" / string morseLetters = ". _" / morse = morseLetters
            morse = c.ToString();
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', '?', '!', '/', '(', ')', '&', ':', ';', '=', '+', '-', '_', '"', '$', '@' };
            string[] morseLetters = { ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _ ", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", "_ _ _ _ _", ". _ . _ . _", "_ _ . . _ _", ". . _ _ . .", "_ _ _ .", "_ . . _ .", "_ . _ _ .", "_ . _ _ . _", ". _ . . .", "_ _ _ . . .", "_ . _ . _ .", "_ . . . _", ". _ . _ .", "_ . . . . _", ". . _ _ . _", ". _ . . _ .", ". . . _ . . _", ". _ _ . _ ." };

            foreach (char v in morse)
            {
                for (int j = 0; j <= letters.Length; j++)
                {
                    if (v == letters[j])
                    {
                        morse = morseLetters[j];
                        break;
                    }
                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return morse;
        }

        public static char Morse_to_char(string morse)
        {
            char c = '\0';
            // Ne rien modifier au dessus de ce commentaire
            string[] morsecode = { morse };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', '?', '!', '/', '(', ')', '&', ':', ';', '=', '+', '-', '_', '"', '$', '@' };
            string[] morseLetters = { ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _ ", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", "_ _ _ _ _", ". _ . _ . _", "_ _ . . _ _", ". . _ _ . .", "_ _ _ .", "_ . . _ .", "_ . _ _ .", "_ . _ _ . _", ". _ . . .", "_ _ _ . . .", "_ . _ . _ .", "_ . . . _", ". _ . _ .", "_ . . . . _", ". . _ _ . _", ". _ . . _ .", ". . . _ . . _", ". _ _ . _ ." };
            foreach (string test in morsecode)
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    if (test == morseLetters[i])
                    {
                        c = letters[i];
                        break;
                    }
                }
            }
            // Ne rien modifier au dessous de ce commentaire
            return c;
        }


        public static string Morse_encode(string sentence)
        {
            string newSentence = "";
            // Ne rien modifier au dessus de ce commentaire
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', '?', '!', '/', '(', ')', '&', ':', ';', '=', '+', '-', '_', '"', '$', '@' };
            string[] morseLetters = { ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _ ", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", "_ _ _ _ _", ". _ . _ . _", "_ _ . . _ _", ". . _ _ . .", "_ _ _ .", "_ . . _ .", "_ . _ _ .", "_ . _ _ . _", ". _ . . .", "_ _ _ . . .", "_ . _ . _ .", "_ . . . _", ". _ . _ .", "_ . . . . _", ". . _ _ . _", ". _ . . _ .", ". . . _ . . _", ". _ _ . _ ." };
            // On met en smallcase
            string testcode = sentence.ToLower();
            // On créer la variable qui placera le slash
            string slash = " / ";

            // 1ere boucle pour parcourir la sentence
            for (int i = 0; i < testcode.Length; i++)
            {
                // 2 eme boucle pour parcourir les alphabets
                for (int j = 0; j < letters.Length; j++)
                {
                    if (testcode[i] == letters[j])
                    {
                        // Pour mettre les triples espaces
                        if (i < testcode.Length - 1 && testcode[i + 1] != ' ')
                        {
                            newSentence += morseLetters[j] + "   ";
                            break;
                        }
                        // Pour mettre le code morse
                        newSentence += morseLetters[j];
                        break;
                    }
                    // Pour attribuer le slash et son espace -1 et + 1
                    else if (testcode[i] == ' ')
                    {
                        newSentence += slash;
                        break;
                    }


                }
            }
            return newSentence;
        }
        public static string Morse_decode(string sentence)
        {
            string newSentence = "";
            // Ne rien modifier au dessus de ce commentaire
            string[] split = sentence.Split(new string[] { "   " }, StringSplitOptions.None);

            char[] letters = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', ':', '?', '!', '\\', '/', '"', '@', '=' };
            string[] morseLetters = { " / ", ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _ ", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", ". _ _ _ _  _ _ _ _ _", ". _ . _ . _", "_ _ . . _ _", "_ _ _ . . .", ". . _ _ . .", "_ _ _ .", ". _ _ _ _ .", "_ . . . . _", "_ . . _ .", ". _ . . _ .", ". _ _ . _ .", "_ . . . _" };

            foreach (string item in split)
            {
                if (item.IndexOf("/") > 0)
                {
                    string[] tmp = item.Split(new string[] { " / " }, StringSplitOptions.None);
                    newSentence += Morse_to_char(tmp[0]) + " " + Morse_to_char(tmp[1]);
                }
                else
                {

                    newSentence += Morse_to_char(item);
                }
            }

            newSentence = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(newSentence.ToLower());
            // Ne rien modifier au dessous de ce commentaire
            return newSentence;
        }
    }
}



