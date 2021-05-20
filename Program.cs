using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<string> fiosDaBombaNaoCortados = new List<string>() { "Branco", "Preto", "Vermelho", "Laranja", "Verde", "Roxo" };
        List<string> fiosDaBombaDesarmado = new List<string>();
        string fioAnterior = "";
        string tentarNovamente = "S";
        bool explode = false;
        int i = 1;

        do
        {
            Console.Write("Jogo: Desarmar uma bomba\r\n\r\n");
            Console.Write("Se cortares um fio branco não podes cortar um fio branco ou preto \r\nSe cortares um fio vermelho tens de cortar um fio verde \r\nSe cortares um fio preto não é permitido cortar um fio branco, verde ou laranja \r\nSe cortares um fio laranja tu deves cortar um fio vermelho ou preto \r\nSe cortares um fio verde tens de cortar um fio laranja ou branco \r\nSe cortares um fio roxo não podes cortar um fio roxo, verde, laranja ou branco");
            Console.Write("\r\n\r\nRonda: " + i);
            Console.Write("\r\nPodes inserir os teus inputs!!\r\n");

            do
            {
                string stringInserida = Console.ReadLine();
                stringInserida = String.Concat(stringInserida.Where(c => !Char.IsWhiteSpace(c)));
                List<string> arrayInserido = stringInserida.Split(',').ToList();

                if (stringInserida != null)
                {
                    foreach (string cor in arrayInserido)
                    {
                        if (cor != "Branco" && cor != "Preto" && cor != "Vermelho" && cor != "Laranja" && cor != "Verde" && cor != "Roxo")
                        {
                            Console.Write("Bad input!\r\n");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(fioAnterior))
                            {
                                fiosDaBombaDesarmado.Add(cor);
                                fiosDaBombaNaoCortados.Remove(cor);
                                fioAnterior = cor;
                            }
                            else
                            {
                                if (fioAnterior == "Vermelho")
                                {
                                    if (cor == "Verde")
                                    {
                                        fiosDaBombaDesarmado.Add(cor);
                                        fiosDaBombaNaoCortados.Remove(cor);
                                        fioAnterior = cor;
                                    }
                                    else
                                    {
                                        Console.Write("\r\nBomba explodiu!\r\n");
                                        explode = true;
                                    }
                                }
                                else if (fioAnterior == "Laranja")
                                {
                                    if (cor == "Vermelho" || cor == "Preto")
                                    {
                                        fiosDaBombaDesarmado.Add(cor);
                                        fiosDaBombaNaoCortados.Remove(cor);
                                        fioAnterior = cor;
                                    }
                                    else
                                    {
                                        Console.Write("\r\nBomba explodiu!\r\n");
                                        explode = true;
                                    }
                                }
                                else if (fioAnterior == "Verde")
                                {
                                    if (cor == "Branco" || cor == "Laranja")
                                    {
                                        fiosDaBombaDesarmado.Add(cor);
                                        fiosDaBombaNaoCortados.Remove(cor);
                                        fioAnterior = cor;
                                    }
                                    else
                                    {
                                        Console.Write("\r\nBomba explodiu!\r\n");
                                        explode = true;
                                    }
                                }
                                else if (fioAnterior == "Branco")
                                {
                                    if (cor != "Branco" || cor != "Preto")
                                    {
                                        fiosDaBombaDesarmado.Add(cor);
                                        fiosDaBombaNaoCortados.Remove(cor);
                                        fioAnterior = cor;
                                    }
                                    else
                                    {
                                        Console.Write("\r\nBomba explodiu!\r\n");
                                        explode = true;
                                    }
                                }
                                else if (fioAnterior == "Preto")
                                {
                                    if (cor != "Branco" || cor != "Verde" || cor != "Laranja")
                                    {
                                        fiosDaBombaDesarmado.Add(cor);
                                        fiosDaBombaNaoCortados.Remove(cor);
                                        fioAnterior = cor;
                                    }
                                    else
                                    {
                                        Console.Write("\r\nBomba explodiu!\r\n");
                                        explode = true;
                                    }
                                }
                                else if (fioAnterior == "Roxo")
                                {
                                    if (cor != "Roxo" || cor != "Verde" || cor != "Laranja" || cor != "Branco")
                                    {
                                        fiosDaBombaDesarmado.Add(cor);
                                        fiosDaBombaNaoCortados.Remove(cor);
                                        fioAnterior = cor;
                                    }
                                    else
                                    {
                                        Console.Write("\r\nBomba explodiu!\r\n");
                                        explode = true;
                                    }
                                }
                            }
                        }
                    }


                    if (fiosDaBombaDesarmado.Count() < 6 && explode == false)
                    {
                        Console.Write("\r\nFios disponiveis: ");

                        foreach (string fio in fiosDaBombaNaoCortados)
                        {
                            Console.Write("\r\n" + fio);
                        }

                        Console.Write("\r\n\r\n------------------------------------\r\n");
                        i++;
                        Console.Write("Ronda: " + i + "\r\n");
                        Console.Write("Podes inserir novamente!!\r\n");
                    }
                }

            } while (fiosDaBombaDesarmado.Count() < 6 && explode == false);

            if (explode == false)
                Console.Write("\r\n \r\nBomba desarmada");

            Console.Write("\r\n\r\nFim\r\n");
            Console.Write("Tentar novamente: Carregar S. Sair: Carregar N\r\n");
            i = 1;
            fiosDaBombaDesarmado.Clear();
            fiosDaBombaNaoCortados = new List<string>() { "Branco", "Preto", "Vermelho", "Laranja", "Verde", "Roxo" };
            fioAnterior = "";
            explode = false;
            tentarNovamente = Console.ReadLine();
            Console.Write("\r\n\r\n------------------------------------\r\n");
        } while (tentarNovamente == "S");
    }
}