using System;
public class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>
{
//atributos
    protected Dado info;
    protected NoArvore<Dado> esq, dir;

//construtores
    public NoArvore(Dado info)
    {
        this.info = info;
        this.esq = null;
        this.dir = null;
    }
    public NoArvore(Dado info, NoArvore<Dado> esq, NoArvore<Dado> dir)
    {
        this.info = info;
        this.esq = esq;
        this.dir = dir;
    }

//acessadores
    public Dado Info
    {
        get => info; 
        set => info = value;
    }
    public NoArvore<Dado> Esq
    {
        get => esq;
        set => esq = value;
    }
    public NoArvore<Dado> Dir
    {
        get => dir;
        set => dir = value;
    }

//metodos
    public bool isFolha()
    {
        return this.esq == null && this.dir == null;
    }
    public int CompareTo(NoArvore<Dado> other)
    {
        return info.CompareTo(other.info);
    }
    public bool Equals(NoArvore<Dado> other)
    {
        return info.Equals(other.info);
    }
}