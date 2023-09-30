using System.Security.AccessControl;
using System.IO;
using System.Text.RegularExpressions;
using System;

class Programa {
    static void Main() {
        string[] Meses = {"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"};
        string[] Dias = {"Lunes","Martes","Miércoles","Jueves","Viernes"};

        int dias = 5;
        int meses = 12;
        int[,] MatrizVentas = new int[meses,dias];

        Random random = new ();
        for (int i = 0; i < meses; i++)
        {
            for (int j = 0; j < dias; j++)
            {
                MatrizVentas[i,j] = random.Next(1,100);
            }
        }

        for (int i = 0; i < meses; i++)
        {
            for (int j = 0; j < dias; j++)
            {
                Console.Write("{0} ", MatrizVentas[i,j].ToString("0#"));
            }
        Console.WriteLine();
        }

        Resumen gus = new();
        Console.WriteLine("$"+gus.SumarTotal(MatrizVentas));
        int[,] DiaxMes;
        DiaxMes = gus.SumarDiaxMes(MatrizVentas);
        for (int i = 0; i < DiaxMes.GetLength(0); i++)
        {
            for (int j = 0; j < DiaxMes.GetLength(1); j++)
            {
                Console.Write (Dias[j]+": ");
                Console.Write("${0} | ",DiaxMes[i,j]);
            }
        }
        Console.WriteLine();

        int Max = gus.ResumirMayorV(MatrizVentas);
        Console.WriteLine("Mayor Venta realizada:");
        for (int i = 0; i < MatrizVentas.GetLength(0); i++)
        {
            for (int j = 0; j < MatrizVentas.GetLength(1); j++)
            {
                if(MatrizVentas[i,j] == Max){
                    Console.WriteLine("La mayor venta fue de: ${0}, se realizó un {1} en {2}",Max,Dias[j],Meses[i]);
                }
            }
        }

        int Min = gus.ResumirMenorV(MatrizVentas);
        Console.WriteLine("Menor Venta realizada:");
        for (int i = 0; i < MatrizVentas.GetLength(0); i++)
        {
            for (int j = 0; j < MatrizVentas.GetLength(1); j++)
            {
                if(MatrizVentas[i,j] == Min){
                    Console.WriteLine("La mayor venta fue de: ${0}, se realizó un {1} en {2}",Min,Dias[j],Meses[i]);
                }
            }
        }
    }
}
public class Resumen {
    public int ResumirMayorV (int[,] MatrizVentas) {
        int Max = 0;
        for (int i = 0; i < MatrizVentas.GetLength(0); i++)
        {
            for (int j = 0; j < MatrizVentas.GetLength(1); j++)
            {
                if(Max < MatrizVentas[i,j]){
                    Max = MatrizVentas[i,j];
                }
            }
        }
        return Max;
    }
    public int ResumirMenorV (int[,] MatrizVentas) {
        int Min = MatrizVentas[0,0];
        for (int i = 0; i < MatrizVentas.GetLength(0); i++)
        {
            for (int j = 0; j < MatrizVentas.GetLength(1); j++)
            {
                if(Min > MatrizVentas[i,j]){
                    Min = MatrizVentas[i,j];
                }
            }
        }
        return Min;
    }
    public int SumarTotal (int[,] MatrizVentas) {
        int Total = 0;
        for (int i = 0; i < MatrizVentas.GetLength(0); i++)
        {
            for (int j = 0; j < MatrizVentas.GetLength(1); j++)
            {
                Total += MatrizVentas[i,j];
            }
        }
        return Total;
    }
    public int[,] SumarDiaxMes (int[,] MatrizVentas) {
        int[,] Ventas = new int [1,5];
        for (int i = 0; i < MatrizVentas.GetLength(0); i++)
        {
            for (int j = 0; j < MatrizVentas.GetLength(1); j++)
            {
                Ventas[0,j] += MatrizVentas[i,j];
            }
        }
        return Ventas;
    }
}