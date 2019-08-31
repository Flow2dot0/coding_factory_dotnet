using System;
namespace TD_console
{
    public class TD2
    {
        // Faites vos tests dans cette méthode
        public TD2()
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
            Writer("Alphabet_aZ", "none", "aBcDeFgHiJkLmNoPqRsTuVwXyZ", Alphabet_aZ());
            Writer("Position_az", "Je sUiS uN StrinG, S", "6", Position_az("Je sUiS uN StrinG", 'S').ToString());
            Writer("Replace_az", "Je sUiS uN StrinG, i", "Je sUS uN StrnG", Replace_az("Je sUiS uN StrinG", 'i'));
            Writer("River_max_sequence", "42, 100", "42 ; 48 ; 60 ; 66 ; 78 ; 93 ; 105.", River_max_sequence(42, 100));
            Writer("Conway_next", "1211", "111221", Conway_next("1211"));
            Writer("Conway_is_sequence", "1132121", "False", Conway_is_sequence("1132121").ToString());
            Writer("Conway_n_sequence", "7", "\n1\n11\n21\n1211\n111221\n312211\n13112221", "\n" + Conway_n_sequence(7));
            Writer("Conway_delimiter", "3, 5", "\n21\n1211\n111221", "\n" + Conway_delimiter(3, 5));
            Writer("Pyramide", "3", "\n  /*\\\n /***\\\n/*****\\", "\n" + Pyramide(3));
        }

        public static string Alphabet_aZ()
        {
            string alphabet = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return alphabet;
        }

        public static int Position_az(string sentence, char search)
        {
            int position = 0;
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return position;
        }

        public static string Replace_az(string sentence, char search)
        {
            string newSentence = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return newSentence;
        }

        public static string River_max_sequence(long river, long max)
        {
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }

        public static string Conway_next(string start)
        {
            string conway = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return conway;
        }

        public static bool Conway_is_sequence(string conway)
        {
            bool isSequence = true;
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return isSequence;
        }

        public static string Conway_n_sequence(int n)
        {
            string sequences = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return sequences;
        }

        public static string Conway_delimiter(int min, int max)
        {
            string sequences = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return sequences;
        }

        public static string Pyramide(int height)
        {
            string pyramide = "";
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return pyramide;
        }
    }
}
