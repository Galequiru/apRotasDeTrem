using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Gabriel Leonardo Quimbayo Ruiz 22132
// Pietro Gutiérrez García-Urrutia 22148

internal class Caminho : IRegistro, IComparable<Caminho>
{
//atributos

    string cidadeOrigem, cidadeDestino;
    int distancia, tempo;

//construtores

    public Caminho() { }

    public Caminho(string cidadeOrigem, string cidadeDestino, int distancia, int tempo)
    {
        this.cidadeOrigem = cidadeOrigem;
        this.cidadeDestino = cidadeDestino;
        this.distancia = distancia;
        this.tempo = tempo;
    }

//acessadores

    public string CidadeOrigem { get => cidadeOrigem; set => cidadeOrigem = value; }
    public string CidadeDestino { get => cidadeDestino; set => cidadeDestino = value; }
    public int Distancia { get => distancia; set => distancia = value; }
    public int Tempo { get => tempo; set => tempo = value; }

    public int TamanhoRegistro => 30 + sizeof(int) * 2;

    public int CompareTo(Caminho other)
    {
        int ret = cidadeOrigem.CompareTo(other.cidadeOrigem);
        if (ret == 0) ret = cidadeDestino.CompareTo(other.cidadeDestino);
        return ret;
    }

    //metodos

    public void GravarRegistro(BinaryWriter arq)
    {
        if (arq != null)
        {
            char[] nomeCidadeOrigem = cidadeOrigem.PadRight(15, ' ').Substring(0, 15).ToCharArray();
            char[] nomeCidadeDestino = cidadeDestino.PadRight(15, ' ').Substring(0, 15).ToCharArray();
            arq.Write(nomeCidadeOrigem);
            arq.Write(nomeCidadeDestino);
            arq.Write(distancia);
            arq.Write(tempo);
        } 
    }

    public void LerRegistro(BinaryReader arq, long registro)
    {
        if (arq != null) 
        {
            long bytes = registro * TamanhoRegistro;
            arq.BaseStream.Seek(bytes, SeekOrigin.Begin);

            char[] aux = arq.ReadChars(15);
            string auxFinal = "";
            for (int i = 0; i < 15; i++)
                auxFinal += aux[i];

            this.cidadeOrigem = auxFinal.Trim();

            aux = arq.ReadChars(15);
            auxFinal = "";
            for (int i = 0; i < 15; i++)
                auxFinal += aux[i];

            this.cidadeDestino = auxFinal.Trim();
            this.distancia = arq.ReadInt32();
            this.tempo = arq.ReadInt32();
        }
    }
    public override string ToString()
    {
        return this.cidadeOrigem;
    }
}