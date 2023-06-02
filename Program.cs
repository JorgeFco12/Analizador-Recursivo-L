//JORGE FRANCISCO ANGULO FLORES

using System;

public class SyntaxAnalyzer
{
    private string input;
    private int position;
    private bool syntaxError;

    public void Analyze(string expression)
    {
        input = expression.Replace(" ", ""); // Eliminar los espacios en blanco
        position = 0;
        syntaxError = false;

        Console.WriteLine("Iniciando análisis sintáctico...");

        Expr();

        if (position == input.Length && !syntaxError)
        {
            Console.WriteLine("Análisis sintáctico exitoso.");
        }
        else
        {
            Console.WriteLine("Error de análisis sintáctico en la posición " + position + ".");
        }
    }

    private void Expr()
    {
        Term();
        RestExpr();
    }

    private void RestExpr()
    {
        if (position < input.Length && (input[position] == '+' || input[position] == '-'))
        {
            position++;
            Term();
            RestExpr();
        }
    }

    private void Term()
    {
        Factor();
        RestTerm();
    }

    private void RestTerm()
    {
        if (position < input.Length && (input[position] == '*' || input[position] == '/'))
        {
            position++;
            Factor();
            RestTerm();
        }
    }

    private void Factor()
    {
        if (position < input.Length && Char.IsDigit(input[position]))
        {
            position++;
        }
        else if (position < input.Length && input[position] == '(')
        {
            position++;
            Expr();
            if (position < input.Length && input[position] == ')')
            {
                position++;
            }
            else
            {
                syntaxError = true;
                Console.WriteLine("Error de análisis sintáctico. Se esperaba ')' en la posición " + position + ".");
            }
        }
        else
        {
            syntaxError = true;
            Console.WriteLine("Error de análisis sintáctico. Símbolo inesperado en la posición " + position + ".");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Ingrese una expresión aritmética:");
        string input = Console.ReadLine();

        SyntaxAnalyzer analyzer = new SyntaxAnalyzer();
        analyzer.Analyze(input);

        Console.ReadLine();
    }
}

