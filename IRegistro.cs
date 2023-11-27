using System.IO;

public interface IRegistro
{
    void LerRegistro(BinaryReader arq, long registro);
    void GravarRegistro(BinaryWriter arq);
    int TamanhoRegistro { get; }
}