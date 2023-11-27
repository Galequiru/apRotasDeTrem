using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Gabriel Leonardo Quimbayo Ruiz 22132
// Pietro Gutiérrez García-Urrutia 22148

public class Arvore<Dado> where Dado : IComparable<Dado>, IRegistro, new()
{ 
//atributos

    private NoArvore<Dado> raiz, atual, anterior;

//construtores

    public Arvore()
    {
        raiz = atual = anterior = null;
    }
    public Arvore(Dado dado)
    {
        raiz = new NoArvore<Dado>(dado);
        atual = anterior = null;
    }
    public Arvore(string rotaArq)
    {
        LerArquivoDeRegistros(rotaArq);
    }

//acessadores

    public NoArvore<Dado> Raiz { get => raiz; }
    public NoArvore<Dado> Atual { get => atual; }
    public NoArvore<Dado> Anterior { get => anterior; }

//metodos publicos

    public int QuantosNos()
    {
        return QuantosNos(raiz);
    }

    public override string ToString()
    {
        return "[ " + Visitar(raiz) + " ]";
    }

    public void Desenhar(int x, int y, Graphics g, double incremento = 0.5, double comprimento = 100)
    {
        DesenharArvore(true, raiz, x, y, 0, incremento, comprimento, g);
    }

    public bool Existe(Dado procurado)
    {
        anterior = null;
        atual = raiz;
        while (atual != null)
        {
            if (atual.Info.CompareTo(procurado) == 0)
                return true;
            else
            {
                anterior = atual;   // aponta o pai do nó procurado
                if (procurado.CompareTo(atual.Info) < 0)
                    atual = atual.Esq; // Desloca apontador para o ramo à esquerda
                else
                    atual = atual.Dir; // Desloca apontador para o ramo à direita
            }
        }
        return false; // Se atual == null, a chave não existe
    }

    public bool Incluir(Dado dado)
    {
        if (Existe(dado)) return false;
        else
        {
            // o novoRegistro tem uma chave inexistente, então criamos um
            // novo nó para armazená-lo e depois ligamos esse nó na árvore
            var novoNo = new NoArvore<Dado>(dado);
            // se a árvore está vazia, a raiz passará a apontar esse novo nó
            if (raiz == null)
                raiz = novoNo;
            else
            // nesse caso, antecessor aponta o pai do novo registro e
            // verificamos em qual ramo o novo nó será ligado
            if (dado.CompareTo(anterior.Info) < 0) // novo é menor que antecessor
            {
                anterior.Esq = novoNo; // vamos para a esquerda
                atual = anterior.Esq;
            }
            else
            {
                anterior.Dir = novoNo; // ou vamos para a direita
                atual = anterior.Dir;
            }
            return true;
        }
    }

    public bool Excluir(Dado dado)
    {
        if (raiz == null) return false;
        atual = raiz;
        anterior = null;
        bool isFilhoEsquerdo = false;
        while (atual.Info.CompareTo(dado) != 0) //enquanto nao achar a chave a remover
        {
            anterior = atual;
            if (atual.Info.CompareTo(dado) > 0)
            {
                isFilhoEsquerdo = true;
                atual = atual.Esq;
            }
            else
            {
                isFilhoEsquerdo = false;
                atual = atual.Dir;
            }
            if (atual == null)  //a chave a excluir não existe
                return false;
        }   //a chave a excluir foi encontrada
            //atual aponta a essa chave
        if (atual.isFolha())
        {
            if (atual == raiz)
                raiz = null;    //esvazia a arvore
            else
                if (isFilhoEsquerdo)
                    anterior.Esq = null;
                else
                    anterior.Dir = null;
            atual = anterior;
        }
        else
        if (atual.Dir == null) //só tem o filho esquerdo
        {
            if (atual == raiz)
                raiz = atual.Esq;
            else
                if (isFilhoEsquerdo)
                    anterior.Esq = atual.Esq;
                else
                    anterior.Dir = atual.Esq;
            atual = anterior;
        }
        else
        if (atual.Esq == null) //só tem o filho direito
        {
            if (atual == raiz)
                raiz = atual.Dir;
            else
                if (isFilhoEsquerdo)
                    anterior.Esq = atual.Dir;
                else
                    anterior.Dir = atual.Dir;
            atual = anterior;
        }
        else //tem os dois filhos
        {
            NoArvore<Dado> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
            atual.Info = menorDosMaiores.Info;
            menorDosMaiores = null;
        }
        return true;

        NoArvore<Dado> ProcuraMenorDosMaioresDescendentes(NoArvore<Dado> noAExcluir)
        {
            NoArvore<Dado> paiDoSucessor = noAExcluir;
            NoArvore<Dado> sucessor = noAExcluir;
            NoArvore<Dado> atual = noAExcluir.Dir; // vai ao ramo direito do nó a ser excluído,
                                                   // pois este ramo contém os descendentes que
                                                   // são maiores que o nó a ser excluído
            while (atual != null)
            {
                if (atual.Esq != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.Esq;
            }
            if (sucessor != noAExcluir.Dir)
            {
                paiDoSucessor.Esq = sucessor.Dir;
                sucessor.Dir = noAExcluir.Dir;
            }
            return sucessor;
        }
    }

    public void LerArquivoDeRegistros(string nomeArquivo)
    {
        raiz = null;
        Dado dado = new Dado();
        var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
        var arquivo = new BinaryReader(origem);
        
        int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro -1;
        Particionar(0, posicaoFinal, ref raiz);
        origem.Close();

        void Particionar(long inicio, long fim, ref NoArvore<Dado> atual)
        {
            if (inicio <= fim)
            {
                long meio = (inicio + fim) / 2;  // registro do meio da partição sob leitura
                dado = new Dado();               // cria um objeto para armazenar os dados

                dado.LerRegistro(arquivo, meio); // o objeto lê os dados no arquivo e
                atual = new NoArvore<Dado>(dado);// é adicionado à arvore
                
                var novoEsq = atual.Esq;
                Particionar(inicio, meio - 1, ref novoEsq); // Particiona à esquerda
                atual.Esq = novoEsq;

                var novoDir = atual.Dir;
                Particionar(meio + 1, fim, ref novoDir);    // Particiona à direita
                atual.Dir = novoDir;
            }
        }
    }

    public void GravarArquivoDeRegistros(string nomeArquivo)
    {
        var destino = new FileStream(nomeArquivo, FileMode.Create);
        var arquivo = new BinaryWriter(destino);
        GravarInOrdem(raiz);
        arquivo.Close();

        void GravarInOrdem(NoArvore<Dado> r)
        {
            if (r != null)
            {
                GravarInOrdem(r.Esq);
                r.Info.GravarRegistro(arquivo);
                GravarInOrdem(r.Dir);
            }
        }
    }

    public List<Dado> ToList()
    {
        var ret = new List<Dado>();
        AdicionarNaLista(ret, raiz);
        return ret;

        void AdicionarNaLista(List<Dado> lista, NoArvore<Dado> no)
        {
            if (no != null)
            {
                AdicionarNaLista(lista, no.Esq);
                lista.Add(no.Info);
                AdicionarNaLista(lista, no.Dir);
            }
        }
    }

//metodos privados

    protected int QuantosNos(NoArvore<Dado> no)
    {
        if (no == null) return 0;
        else return 1 + QuantosNos(no.Esq) + QuantosNos(no.Dir);
    }

    protected string Visitar(NoArvore<Dado> no)
    {
        if (no != null)
        {
            return Visitar(no.Esq) + no.ToString() + Visitar(no.Dir);
        }
        return " ";
    }

    protected void DesenharArvore(bool primeiraVez, NoArvore<Dado> no,
                                int x, int y, double angulo, double incremento,
                                double comprimento, Graphics g)
    {
        if (no != null)
        {
            int xf, yf;
            xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento/2);
            yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);
            if (primeiraVez)
            {
                yf = 25;
                xf = x;
            }

            g.DrawLine(new Pen(Color.Black), x, y, xf, yf);

            DesenharArvore(false, no.Esq, xf, yf, Math.PI / 2 + incremento, incremento * 0.6
                , comprimento * 0.8, g);
            DesenharArvore(false, no.Dir, xf, yf, Math.PI / 2 - incremento, incremento * 0.6
                , comprimento * 0.8, g);

            string texto = no.Info.ToString();
            int pixels = texto.Length * 8;
            g.FillEllipse(new SolidBrush(Color.Black), xf - pixels/2, yf - 15, pixels, 30);
            g.DrawString(texto, new Font("Consolas", 10), new SolidBrush(Color.White), xf - pixels/2, yf - 7);
        }
    }
}