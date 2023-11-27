using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Gabriel Leonardo Quimbayo Ruiz 22132
// Pietro Gutiérrez García-Urrutia 22148

internal class Cidade : IComparable<Cidade>, IRegistro
{
//atributos

    string nome;
    double coordenadaX, coordenadaY;
    List<Caminho> caminhos;

//construtores

    public Cidade() 
    {
        caminhos = new List<Caminho>();
    }

    public Cidade(string nome, double coordenadaX, double coordenadaY)
    {
        this.nome = nome;
        this.coordenadaX = coordenadaX;
        this.coordenadaY = coordenadaY;
        caminhos= new List<Caminho>();
    }

//acessadores

    public string Nome { get => nome; set => nome = value; }
    public double CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
    public double CoordenadaY { get => coordenadaY; set => coordenadaY = value; }
    public List<Caminho> Caminhos { get => caminhos; set => caminhos = value; }
    public int TamanhoRegistro => 15 + sizeof(double) * 2;

//metodos

    public int CompareTo(Cidade other)
    {
        return this.nome.CompareTo(other.nome);
    }

    public void GravarRegistro(BinaryWriter arq)
    {
        if (arq != null)
        {
            char[] nomeCidade = this.nome.PadRight(15, ' ').Substring(0, 15).ToCharArray();
            arq.Write(nomeCidade);
            arq.Write(this.coordenadaX);
            arq.Write(this.coordenadaY);
        }
    }

    public void LerRegistro(BinaryReader arq, long registro)
    {
        if(arq != null)
        {
            long bytes = registro * TamanhoRegistro;
            arq.BaseStream.Seek(bytes, SeekOrigin.Begin);

            char[] novoNome = arq.ReadChars(15);
            string nomeFinal = "";
            for (int i = 0; i < 15; i++)
                nomeFinal += novoNome[i];

            this.nome = nomeFinal.Trim();
            this.coordenadaX = arq.ReadDouble();
            this.coordenadaY = arq.ReadDouble();
        }
    }

    public override string ToString()
    {
        return this.nome + '(' + this.caminhos.Count + ')';
    }
}
