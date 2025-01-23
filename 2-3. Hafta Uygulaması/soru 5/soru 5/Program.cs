using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace soru_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Birinci polinomu girin (örneğin 2x^2 + 3x - 5): ");
                string poly1Input = Console.ReadLine();
                if (poly1Input.ToLower() == "exit") break;

                Console.WriteLine("İkinci polinomu girin (örneğin x^2 - 4): ");
                string poly2Input = Console.ReadLine();
                if (poly2Input.ToLower() == "exit") break;

                var poly1 = ParsePolynomial(poly1Input);
                var poly2 = ParsePolynomial(poly2Input);

                var sumPoly = AddPolynomials(poly1, poly2);
                var diffPoly = SubtractPolynomials(poly1, poly2);

                Console.WriteLine("Polinomların toplamı: " + FormatPolynomial(sumPoly));
                Console.WriteLine("Polinomların farkı: " + FormatPolynomial(diffPoly));
            }
        }

        //polinomu ayıran fonksiyon
        static List<(int, int)> ParsePolynomial(string poly)
        {
            //polinomu listeye dönüştürmek için parçalayacağız
            var terms = Regex.Matches(poly.Replace(" ", ""), @"[+-]?\s*\d*x\^?\d*");
            var parsedPoly = new List<(int, int)>();

            foreach (Match term in terms)
            {
                string coeffStr = term.Value;
                int coeff = 1, exp = 0;

                if (coeffStr.Contains("x^"))
                {
                    var parts = coeffStr.Split(new[] { "x^" }, StringSplitOptions.None);
                    coeff = string.IsNullOrEmpty(parts[0]) ? 1 : int.Parse(parts[0]);
                    exp = int.Parse(parts[1]);
                }
                else if (coeffStr.Contains("x"))
                {
                    var parts = coeffStr.Split('x');
                    coeff = string.IsNullOrEmpty(parts[0]) ? 1 : int.Parse(parts[0]);
                    exp = 1;
                }
                else
                {
                    coeff = int.Parse(coeffStr);
                }

                parsedPoly.Add((coeff, exp));
            }

            return parsedPoly;
        }

        //iki polinomu toplayan fonksiyon
        static List<(int, int)> AddPolynomials(List<(int, int)> poly1, List<(int, int)> poly2)
        {
            //polinomların terimlerini toplamak için birleştiriyoruz
            var result = new Dictionary<int, int>();

            foreach (var (coeff, exp) in poly1)
                result[exp] = result.ContainsKey(exp) ? result[exp] + coeff : coeff;

            foreach (var (coeff, exp) in poly2)
                result[exp] = result.ContainsKey(exp) ? result[exp] + coeff : coeff;

            var resultList = new List<(int, int)>();
            foreach (var kvp in result)
                resultList.Add((kvp.Value, kvp.Key));

            resultList.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            return resultList;
        }

        //iki polinomu çıkaran fonksiyon
        static List<(int, int)> SubtractPolynomials(List<(int, int)> poly1, List<(int, int)> poly2)
        {
            //çıkarma için poly2'nin katsayılarını ters çeviriyoruz
            for (int i = 0; i < poly2.Count; i++)
                poly2[i] = (-poly2[i].Item1, poly2[i].Item2);

            return AddPolynomials(poly1, poly2);
        }

        //polinomu string formatında gösteren fonksiyon
        static string FormatPolynomial(List<(int, int)> poly)
        {
            //sonucu okunabilir bir string haline getiriyoruz
            var terms = new StringBuilder();

            foreach (var (coeff, exp) in poly)
            {
                if (terms.Length > 0 && coeff > 0)
                    terms.Append(" + ");

                if (exp == 0)
                    terms.Append(coeff);
                else if (exp == 1)
                    terms.Append($"{coeff}x");
                else
                    terms.Append($"{coeff}x^{exp}");
            }

            return terms.ToString().Replace("+ -", "- ");
        }
    }
}
