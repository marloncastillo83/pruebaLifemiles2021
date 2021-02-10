using System;
using System.Collections.Generic;

namespace convertidorCodigos
{
    class Program
    {
        static Dictionary<char, string> translator;
        static void Main(string[] args)
        {
            string cadenaOut = "";

            InitialiseDictionary();

            Console.WriteLine("Bienvenido, Favor ingrese la cadena a convertir: ");
            String cadenaIN = Console.ReadLine();

            Console.WriteLine("Ingrese el formato Origen: ");
            String fmtOrigen = Console.ReadLine();

            Console.WriteLine("Ahora ingrese el formato Destino: ");
            String fmtDestino = Console.ReadLine();

            switch (fmtOrigen)
            {
                case "TEXT":
                    switch (fmtDestino.ToUpper())
                    {
                        case "BINARY":
                            cadenaOut=ftn_convert_text_to_binary(cadenaIN);
                            break;

                        case "MORSE":
                            cadenaOut=ftn_convert_text_to_morse(cadenaIN);
                            break;

                        default:
                            Console.WriteLine("Opcion ingresada no válida!!!");
                            break;


                    }
                    break;

                case "BINARY":
                    switch (fmtDestino.ToUpper())
                    {
                        case "TEXT":
                            cadenaOut = ftn_convert_binary_to_text(cadenaIN);
                            break;

                        case "MORSE":
                            cadenaOut = ftn_convert_binary_to_morse(cadenaIN);
                            break;

                        default:
                            Console.WriteLine("Opcion ingresada no válida!!!");
                            break;


                    }
                    break;

                case "MORSE":
                    switch (fmtDestino.ToUpper())
                    {
                        case "TEXT":
                            cadenaOut = ftn_convert_morse_to_text(cadenaIN);
                            break;

                        case "BINARY":
                            cadenaOut = ftn_convert_morse_to_binary(cadenaIN);
                            break;

                        default:
                            Console.WriteLine("Opcion ingresada no válida!!!");
                            break;


                    }
                    break;

                default:
                    Console.WriteLine("Opcion ingresada no válida!!!");
                    break;

            }

            Console.WriteLine("El texto convertido: " + cadenaOut);
            Console.ReadKey();
        }

        static string ftn_convert_text_to_binary(string cadena)
        {
            string[] numOut = new string[cadena.Length];
            int contador = 0;
            foreach (char c in cadena)
            {
                numOut[contador] = Convert.ToString(Convert.ToInt32(((int)c).ToString("X"), 16), 2);
                contador++;
            }
            string cadenaOut = string.Join(" ", numOut);
            return cadenaOut;
        }

        static string ftn_convert_binary_to_text(string cadena)
        {
            string base64String;
            byte[] binaryData = System.Text.ASCIIEncoding.Default.GetBytes(cadena);
            base64String = System.Convert.ToBase64String(binaryData, 0, cadena.Length);

            return base64String;
        }

        static string ftn_convert_text_to_morse(string cadena)
        {
            cadena = cadena.ToLower();
            return translate(cadena);
        }

        static string ftn_convert_morse_to_text(string cadena)
        {
            return "This is a text";
        }

        static string ftn_convert_morse_to_binary(string cadena)
        {
            string toText = ftn_convert_morse_to_text(cadena);
            string toBinary = ftn_convert_text_to_binary(toText);
            return null;
        }

        static string ftn_convert_binary_to_morse(string cadena)
        {

            String toText = ftn_convert_binary_to_text(cadena);
            String toMorse = ftn_convert_text_to_morse(toText);

            return toMorse;
        }

        private static string translate(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char character in input)
            {
                if (translator.ContainsKey(character))
                {
                    sb.Append(translator[character] + " ");
                }
                else if (character == ' ')
                {
                    sb.Append("/ ");
                }
                else
                {
                    sb.Append(character + " ");
                }
            }
            return sb.ToString();
        }

        private static void InitialiseDictionary()
        {
            char dot = '.';
            char dash = '−';

            translator = new Dictionary<char, string>()
            {
                {'a', string.Concat(dot, dash)},
                {'b', string.Concat(dash, dot, dot, dot)},
                {'c', string.Concat(dash, dot, dash, dot)},
                {'d', string.Concat(dash, dot, dot)},
                {'e', dot.ToString()},
                {'f', string.Concat(dot, dot, dash, dot)},
                {'g', string.Concat(dash, dash, dot)},
                {'h', string.Concat(dot, dot, dot, dot)},
                {'i', string.Concat(dot, dot)},
                {'j', string.Concat(dot, dash, dash, dash)},
                {'k', string.Concat(dash, dot, dash)},
                {'l', string.Concat(dot, dash, dot, dot)},
                {'m', string.Concat(dash, dash)},
                {'n', string.Concat(dash, dot)},
                {'o', string.Concat(dash, dash, dash)},
                {'p', string.Concat(dot, dash, dash, dot)},
                {'q', string.Concat(dash, dash, dot, dash)},
                {'r', string.Concat(dot, dash, dot)},
                {'s', string.Concat(dot, dot, dot)},
                {'t', string.Concat(dash)},
                {'u', string.Concat(dot, dot, dash)},
                {'v', string.Concat(dot, dot, dot, dash)},
                {'w', string.Concat(dot, dash, dash)},
                {'x', string.Concat(dash, dot, dot, dash)},
                {'y', string.Concat(dash, dot, dash, dash)},
                {'z', string.Concat(dash, dash, dot, dot)},
                {'0', string.Concat(dash, dash, dash, dash, dash)},
                {'1', string.Concat(dot, dash, dash, dash, dash)},
                {'2', string.Concat(dot, dot, dash, dash, dash)},
                {'3', string.Concat(dot, dot, dot, dash, dash)},
                {'4', string.Concat(dot, dot, dot, dot, dash)},
                {'5', string.Concat(dot, dot, dot, dot, dot)},
                {'6', string.Concat(dash, dot, dot, dot, dot)},
                {'7', string.Concat(dash, dash, dot, dot, dot)},
                {'8', string.Concat(dash, dash, dash, dot, dot)},
                {'9', string.Concat(dash, dash, dash, dash, dot)}
            };
        }

    }

}
