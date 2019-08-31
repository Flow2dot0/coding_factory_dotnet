using System;
namespace TD_console
{
    public class TD4
    {
        // Ne pas modifier ces variables
        public static string[][] cadrans = {
           new string[] { // 3
                "111",
                "001",
                "111",
                "001",
                "111"
            },
            new string[] { // 21
                "111001",
                "001001",
                "111001",
                "100001",
                "111001"
            },
            new string[] { // 86
                "1111110",
                "1011000",
                "1111110",
                "1011010",
                "1111110"
            },
            new string[] { // 86? -> Error
                "1111110",
                "1011000",
                "1111110",
                "1011010",
                "1111110"
            },
            new string[] { // 57014
                "111111111001100",
                "100001101001100",
                "111001101001111",
                "001001101001001",
                "111001111001001"
            },
            new string[] { // 5 - 0 * 4 -> 5
                "111000111000100",
                "100000101000100",
                "111000101101111",
                "001111101010001",
                "111000111101001"
            },
            new string[] { // 5 ? 0 -> Error
                "111000111",
                "100000101",
                "111001101",
                "001111101",
                "111001111"
            }
        };

        public static int[][][] passerelles = {
            new int[][] {
                new int[] {1, 0, 0, 1},
                new int[] {0, 1, 0, 0},
                new int[] {0, 1, 1, 0},
                new int[] {0, 0, 0, 1},
                new int[] {0, 1, 0, 0},
            },
            new int[][] {
                new int[] {1, 0, 0, 1, 0, 1},
                new int[] {0, 1, 1, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0, 1},
                new int[] {1, 0, 0, 1, 0, 0},
                new int[] {1, 0, 0, 0, 0, 1},
                new int[] {0, 0, 0, 1, 1, 0},
                new int[] {0, 1, 1, 0, 0, 1},
                new int[] {1, 0, 0, 1, 0, 0}
            }
        };

        public static int[][][][] labys = {
            new int[][][] {
                new int[][] {
                    new int[] {1, 1, 1, 0},
                    new int[] {1, 1, 0, 0},
                    new int[] {0, 1, 0, 1},
                    new int[] {0, 1, 1, 0}
                },
                new int[][] {
                    new int[] {1, 0, 0, 1},
                    new int[] {0, 0, 0, 1},
                    new int[] {0, 1, 1, 0},
                    new int[] {1, 0, 1, 0}
                },
                new int[][] {
                    new int[] {1, 1, 0, 0},
                    new int[] {0, 1, 0, 1},
                    new int[] {0, 0, 1, 1},
                    new int[] {1, 0, 1, 0}
                },
                new int[][] {
                    new int[] {1, 0, 0, 1},
                    new int[] {0, 1, 1, 1},
                    new int[] {1, 1, 0, 1},
                    new int[] {0, 0, 1, 1}
                }
            }
        };

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
            Writer("Titaah_encode", "Hello world !", "Titititi ti titaahtiti titaahtiti taahtaahtaah, titaahtaah taahtaahtaah titaahti titaahtiti tahhtiti, !", Titaah_encode("Hello world !"));
            Writer("Titaah_decode", "Titititi ti titaahtiti titaahtiti taahtaahtaah, titaahtaah taahtaahtaah titaahti titaahtiti tahhtiti, !", "Hello world !", Titaah_decode("Titititi ti titaahtiti titaahtiti taahtaahtaah, titaahtaah taahtaahtaah titaahti titaahtiti tahhtiti, !"));
            Writer("Passerelle_display", "int[][]", "\nA B C D E F G H\n|=| | |=|=| | |=\n| |=| | | | |=|\n| |=| | | | |=|\n|=| | |=| |=| |=\n| | | | | |=| |\n|=| |=| |=| |=|\n1 2 3 4 5 6 7 8", "\n" + Passerelle_display(passerelles[1]));
            Writer("Passerelle", "int[][]", "A3 ; B2 ; Error ; D1 ; Error.", Passerelle(passerelles[0]));
            Writer("Cadran", "string[]", "\n111001\n001001\n111001\n100001\n111001", "\n" + Cadran(cadrans[1]));
            Writer("Cadran", "string[]", "Error", Cadran(cadrans[3]));
            Writer("Cadran_to_long", "string[]", "57014", Cadran_to_long(cadrans[4]).ToString());
            Writer("Cadran_addition", "string[]", "24", Cadran_addition(cadrans[0], cadrans[1]).ToString());
            Writer("Cadran_soustraction", "string[]", "18", Cadran_soustraction(cadrans[1], cadrans[0]).ToString());
            Writer("Cadran_multiplication", "string[]", "63", Cadran_multiplication(cadrans[0], cadrans[1]).ToString());
            Writer("Cadran_division", "string[]", "7", Cadran_division(cadrans[0], cadrans[1]).ToString());
            Writer("Cadran_operation", "string[]", "5", Cadran_operation(cadrans[5]).ToString());
            Writer("Cadran_operation", "string[]", "Error", Cadran_operation(cadrans[6]).ToString());
            Writer("Open_close_is_valid", "([ahy[op_i]]op{}())", "True", Open_close_is_valid("([ahy[op_i]]op{}())").ToString());
            Writer("Laby", "int[][][]", "??", "\n" + Laby(labys[0]));
            Writer("Laby_is_valid", "int[][][]", "False", Laby_is_valid(labys[0]).ToString());
            Writer("Laby_resolve", "int[][][]", "10", Laby_resolve(labys[0]).ToString());
        }

        public static string Titaah_encode(string sentence)
        {
            string sequences = "";
            // Ne rien modifier au dessus de ce commentaire

            char[] letters_sentence = sentence.ToCharArray();

            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', ':', '?', '!', '\\', '/', '"', '@', '=' };
            //string[] morseLetters = { "ti", "taahtititi", "tahtitahti", "tahtiti", "ti", "tititahti", "tahtahti", "titititi", "titi", "titahtahtah", "tahtitah", "titahtiti", "tahtah", "tahti", "tahtahtah", "titahtahti", "tahtahtitah", "titahti", "tititi", "tah", "tititah", "titititah", "titahtah", "tahtititah", "tahtitahtah", "tahtahtiti", "titahtahtahtah", "tititahtahtah", "titititahtah", "tititititah", "tititititi", "tahtitititi", "tahtahtititi", "tahtahtahtiti", "tahtahtahtahti", "titahtahtahtahtahtahtahtahtah", ". _ . _ . _", "_ _ . . _ _", "_ _ _ . . .", ". . _ _ . .", "_ _ _ .", ". _ _ _ _ .", "_ . . . . _", "_ . . _ .", ". _ . . _ .", ". _ _ . _ .", "_ . . . _" };
            string[] morseLetters = { " / ", ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _ ", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", ". _ _ _ _  _ _ _ _ _", ". _ . _ . _", "_ _ . . _ _", "_ _ _ . . .", ". . _ _ . .", "_ _ _ .", ". _ _ _ _ .", "_ . . . . _", "_ . . _ .", ". _ . . _ .", ". _ _ . _ .", "_ . . . _" };


            string morse = TD4.Morse_encode(sentence.ToLower());

            morse = morse.Replace(". ", "ti");
            morse = morse.Replace("_ ", "taah");
            morse = morse.Replace("/", ",");
            morse = morse.Replace("taahtaahtaah.", "!");
            morse = morse.Replace("  ", " ");

            int count = 0;

            string tmp = "";
            foreach (char letter in morse)
            {
                tmp = letter.ToString();

                if (count == 0)
                {
                    tmp = tmp.ToUpper();

                }
                count++;
                sequences += tmp;

            }

            // Ne rien modifier au dessous de ce commentaire
            return sequences;
        }

        public static string Titaah_decode(string sentence)
        {
            string sequences = "";
            // Ne rien modifier au dessus de ce commentaire

            sentence = sentence.Replace("ti", ". ");
            sentence = sentence.Replace("Ti", ". ");
            sentence = sentence.Replace("taah", "_ ");
            sentence = sentence.Replace("Taah", "_ ");
            sentence = sentence.Replace("!", "_ _ _ .");
            sentence = sentence.Replace(",", " / ");
            sentence = sentence.Replace("  /  ", " / ");
            sentence = sentence.Replace("  .", "   .");
            sentence = sentence.Replace("  _", "   _");

            sequences = TD4.Morse_decode(sentence);
            
            // Ne rien modifier au dessous de ce commentaire
            return sequences;
        }
        public static string Passerelle_display(int[][] map)
        {
            string passerelle = "";
            // Ne rien modifier au dessus de ce commentaire

            // BYE BYE J'ABANDONNE

            // Ne rien modifier au dessous de ce commentaire
            return passerelle;
        }

        public static string Passerelle(int[][] map)
        {
            Console.WriteLine(Passerelle_display(map));
            string sequence = "";
            // Ne rien modifier au dessus de ce commentaire

            // TOI AUSSI BYE BYE

            // Ne rien modifier au dessous de ce commentaire
            return sequence;
        }

        public static string Cadran(string[] sequences)
        {
            string cadran = "";
            // Ne rien modifier au dessus de ce commentaire

            // CA AUSSI

            // Ne rien modifier au dessous de ce commentaire
            return cadran;
        }

        public static long Cadran_to_long(string[] sequences)
        {
            Console.WriteLine(Cadran(sequences));
            long cadran = 0;
            // Ne rien modifier au dessus de ce commentaire

            // EVIDEMMENT QUE CA AUSSI

            // Ne rien modifier au dessous de ce commentaire
            return cadran;
        }

        public static decimal Cadran_addition(string[] a, string[] b)
        {
            decimal operation = 0;
            // Ne rien modifier au dessus de ce commentaire

            // N'EN PARLONS MEME PAS

            // Ne rien modifier au dessous de ce commentaire
            return operation;
        }

        public static decimal Cadran_soustraction(string[] a, string[] b)
        {
            decimal operation = 0;
            // Ne rien modifier au dessus de ce commentaire

            // N'EN PARLONS MEME PAS

            // Ne rien modifier au dessous de ce commentaire
            return operation;
        }

        public static decimal Cadran_multiplication(string[] a, string[] b)
        {
            decimal operation = 0;
            // Ne rien modifier au dessus de ce commentaire

            // N'EN PARLONS MEME PAS

            // Ne rien modifier au dessous de ce commentaire
            return operation;
        }

        public static decimal Cadran_division(string[] a, string[] b)
        {
            decimal operation = 0;
            // Ne rien modifier au dessus de ce commentaire

            // N'EN PARLONS MEME PAS

            // Ne rien modifier au dessous de ce commentaire
            return operation;
        }

        public static decimal Cadran_operation(string[] sequence)
        {
            decimal operation = 0;
            // Ne rien modifier au dessus de ce commentaire

            // N'EN PARLONS MEME PAS

            // Ne rien modifier au dessous de ce commentaire
            return operation;
        }

        public static bool Open_close_is_valid(string sequence)
        {
            bool is_valid = true;
            // Ne rien modifier au dessus de ce commentaire

            // DESOLE J'AI PAS UN DIPLOME EN INGE MATH SPE, J'AI QU'UNE SEMAINE D'ALGO

            // Ne rien modifier au dessous de ce commentaire
            return is_valid;
        }

        public static string Laby(int[][][] map)
        {
            string laby = "";
            // Ne rien modifier au dessus de ce commentaire
            string labyBis = "";
            string tmp1 ="";
            string tmp2 ="";
            foreach (int[][] i in map)
            {

                foreach(int[] j in i)
                {
                    foreach(int k in j)
                    {
                        labyBis += k;
                    }
                }
            }
            for (int x = 0; x <= labyBis.Length-52; x = x+4)
            {
                tmp1 = labyBis.Substring(x, 4);
                Console.WriteLine(tmp1);

                for (int z = 0; z <= tmp1.Length-1; z++)
                {

                    if (tmp1[z] == '1')
                    {
                        if(z == 0 && z == 3)
                        {
                            tmp2 += '|';
                        }
                        else if(z == 1 && z == 2)
                        {
                            tmp2 += '_';
                        }
                    }
                    else if(tmp1[z] == '0')
                    {
                        tmp2 += ' ';
                    }
                }
            }
            tmp2 = laby;







            // Ne rien modifier au dessous de ce commentaire
            return laby;
        }

        public static bool Laby_is_valid(int[][][] map)
        {
            bool is_valid = true;
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return is_valid;
        }

        public static long Laby_resolve(int[][][] map)
        {
            long laby_step = 0;
            // Ne rien modifier au dessus de ce commentaire

            // Ne rien modifier au dessous de ce commentaire
            return laby_step;
        }
    }
}
