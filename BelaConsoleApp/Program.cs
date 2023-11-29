using System.Runtime.CompilerServices;

namespace BelaConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite 1 para somar números pares, 2 para ordenar uma sequencia de numeros, 3 para simular um caixa eletronico, digite 0 para sair.");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    {
                        Console.WriteLine("Vamos somar os dois menores valores pares que vc digitar, informe 10 valores.");
                        List<double> numeros = new List<double>();
                        for (int i = 0;i < 10; i++)
                        {
                            Console.WriteLine($"Diite o {i}° valor:");
                            double valor = double.Parse(Console.ReadLine());
                            numeros.Add(valor);
                        }
                        double retorno = SomarNumerosPares(numeros);
                        if(retorno == 1 )
                        {
                            Console.WriteLine("Você não informou nenhum número par.");
                            break;
                        }
                        Console.WriteLine($"O menor valor das somas de numeros pares encontrado é: {retorno}");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Vamos ordenar os valores de forma crescente, informe 10 valores inteiros.");
                        int[] numeros = {0,1,2,3,4,5,6,7,8,9};

                        for (int i = 0;i < numeros.Length; i++)
                        {
                            Console.WriteLine($"Diite o {i}° valor:");
                            
                            int valor = int.Parse(Console.ReadLine());
                            numeros[i] = valor;
                        }

                        InsertionSort(numeros);
                        Console.WriteLine("************** resultado **************");
                        foreach (int numero in numeros.Skip(0))
                        {
                            Console.WriteLine(numero);
                        }
                        break;
                    }
                case 3:
                    {
                        int[] cedulas = { 100, 50, 20, 10, 5, 2 };

                        Console.WriteLine("Digite o valor que deseja sacar: ");
                        int valorSaque = int.Parse(Console.ReadLine());

                        int[] quantidadeCedulas = new int[cedulas.Length];
                        for (int i = 0; i < quantidadeCedulas.Length; i++)
                        {
                            quantidadeCedulas[i] = 0;
                        }

                        for (int i = 0; i < cedulas.Length; i++)
                        {

                            int quantidadeRetirada = valorSaque / cedulas[i];

                            if (quantidadeRetirada > 0)
                            {
                                quantidadeCedulas[i] = quantidadeRetirada;
                                valorSaque -= quantidadeRetirada * cedulas[i];
                            }
                        }

                        Console.WriteLine("Cédulas de 100: {0}", quantidadeCedulas[0]);
                        Console.WriteLine("Cédulas de 50: {0}", quantidadeCedulas[1]);
                        Console.WriteLine("Cédulas de 20: {0}", quantidadeCedulas[2]);
                        Console.WriteLine("Cédulas de 10: {0}", quantidadeCedulas[3]);
                        Console.WriteLine("Cédulas de 5: {0}", quantidadeCedulas[4]);
                        Console.WriteLine("Cédulas de 2: {0}", quantidadeCedulas[5]);

                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }
        public static double SomarNumerosPares(List<double> numeros)
        {
            double menorValor = double.MaxValue;
            for (int i = 0; i < numeros.Count; i++)
            {
                if (numeros[i] % 2 == 0 && numeros[i] < menorValor)
                {
                    menorValor = numeros[i];
                }
            }

            // Encontra o segundo menor valor par
            double segundoMenorValor = double.MaxValue;
            for (int i = 0; i < numeros.Count; i++)
            {
                if (numeros[i] % 2 == 0 && numeros[i] < segundoMenorValor && numeros[i] != menorValor)
                {
                    segundoMenorValor = numeros[i];
                }
            }

            if (menorValor == double.MaxValue && segundoMenorValor == double.MaxValue)
                return 1;

            return menorValor + segundoMenorValor;
        }
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int valorAtual = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > valorAtual)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = valorAtual;
            }
        }
    }
}