using System;
using System.Runtime.InteropServices;

namespace Validador_do_cpf
{
    internal class Program
    {

        static void Main(string[] args)
        {

            /* 
             * Cpf: 461.188.068-02
             * Validação do primerio digito
             * 
             * 97699985320
             * 
             *  Primerio multplica os 9 primeiros digitos de 10 á 2
             *  4*10 + 6*9 + 1*8 + 1*7 + 8*6 + 8*5 + 0*4 + 6*3 + 8*2
             *  = 231
             *  
             *  Segundo multplica o resltado por 10 e divide por 11
             *  231*10%11 = 0 || O que interessa é o resto
             *  Observação Importante: Se o resto da divisão for igual a 10, nós o consideramos como 0.
             *  
             *  Se o resultado for igual o numero depois do "-" a primeira parte da validação ta correta
             *
             * Validação do segundo digito
             *  
             *  Primeiro pega os 0 primeiros digitos mais o primeiro valor depois do "-" e vai de 11 a 2
             *  4*11 + 6*10 + 1*9 + 1*8 + 8*7 + 8*6 + 0*5 + 6*4 + 8*3 + 0*2
             *  = 273
             *  
             *  Segundo multplica o resltado por 10 e divide por 11
             *  273*10%11 = 2 || O que interessa é o resto
             *  
             *  Se o resultado for igual o segundo numero depois do "-" o cpf é valido
             */
           
            Console.Write("Insira o seu cpf: ");
            string cpf = Console.ReadLine().Replace(".", "").Replace("-", ""); ;

            char[] valor_cpf = cpf.ToCharArray();

            // Verifica se o valor de cpf possui 11 caracteres
            int validação = valor_cpf.Length;
            if (validação != 11)
            {
                Console.WriteLine("Insira um cpf valido");
                
            } 
            else
            {
                // Variaveis de cada caractere
                int char1_cpf = 0,
                    char2_cpf = 0,
                    char3_cpf = 0,
                    char4_cpf = 0,
                    char5_cpf = 0,
                    char6_cpf = 0,
                    char7_cpf = 0,
                    char8_cpf = 0,
                    char9_cpf = 0,
                    char10_cpf = 0,
                    char11_cpf = 0;

                if (validação == 11)
                {
                    char1_cpf = valor_cpf[0] - '0';
                    char2_cpf = valor_cpf[1] - '0';
                    char3_cpf = valor_cpf[2] - '0';
                    char4_cpf = valor_cpf[3] - '0';
                    char5_cpf = valor_cpf[4] - '0';
                    char6_cpf = valor_cpf[5] - '0';
                    char7_cpf = valor_cpf[6] - '0';
                    char8_cpf = valor_cpf[7] - '0';
                    char9_cpf = valor_cpf[8] - '0';
                    char10_cpf = valor_cpf[9] - '0';
                    char11_cpf = valor_cpf[10] - '0';
                }

                // Pega o resultado dos 9 primeiros caracteres multiplicados por 10 a 2 para a fazer a primeira verificação
                int verification1 =
                    char1_cpf * 10 +
                    char2_cpf * 9 +
                    char3_cpf * 8 +
                    char4_cpf * 7 +
                    char5_cpf * 6 +
                    char6_cpf * 5 +
                    char7_cpf * 4 +
                    char8_cpf * 3 +
                    char9_cpf * 2
                    ;

                // Pega o resultado do modulo da verificação 1
                int verification2 = verification1 * 10 % 11;

                // valor 1 da verificação final do cpf
                // Se modulo for igual a 10 ele recebe 0, se não continua com o valor anterior
                int FirstVerificationCpf = (verification2 == 10) ? 0 : verification2;

                // Pega o resultado dos 9 primeiros digitos, mais o primeiro o valor após o "-" do cpf e multiplica por 11 a 2
                int verification3 =
                        char1_cpf * 11 +
                        char2_cpf * 10 +
                        char3_cpf * 9 +
                        char4_cpf * 8 +
                        char5_cpf * 7 +
                        char6_cpf * 6 +
                        char7_cpf * 5 +
                        char8_cpf * 4 +
                        char9_cpf * 3 +
                        char10_cpf * 2
                    ;
                // Pega o resultado do modulo da verificação 3
                int verification4 = verification3 * 10 % 11;

                // valor 2 da verificação final do cpf
                // Se modulo for igual a 10 ele recebe 0, se não continua com o valor anterior
                int SecondVerificationCpf = (verification2 == 10) ? 0 : verification4;

                /*
                    Verificação final do cpf

                    Onde o valor da primeira verificação tem que ser igual o primeiro valor após o "-"
                    Onde o valor da segunda verificação tem que ser igual o segundo valor após o "-"
                        [No caso serem iguais o valor do digito]

                */

                if (FirstVerificationCpf != char10_cpf || SecondVerificationCpf != char11_cpf)
                {
                    Console.WriteLine("Cpf invalido");
                }
                else
                {
                    Console.WriteLine("Cpf verificado");
                }
            }


            Console.ReadKey();
        }
    }
}
