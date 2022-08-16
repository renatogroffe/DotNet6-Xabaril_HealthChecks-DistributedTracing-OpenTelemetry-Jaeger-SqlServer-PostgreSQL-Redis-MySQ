using System.Runtime.InteropServices;
using APIContagem.Tracing;

namespace APIContagem;

public class Contador
{
    private static readonly string _LOCAL;
    private static readonly string _KERNEL;
    private static readonly string _FRAMEWORK;

    static Contador()
    {
        _LOCAL = OpenTelemetryExtensions.ServiceName;
        _KERNEL = Environment.OSVersion.VersionString;
        _FRAMEWORK = RuntimeInformation.FrameworkDescription;
    }

    private int _valorAtual = 20000;

    public int ValorAtual { get => _valorAtual; }
    public string Local { get => _LOCAL; }
    public string Kernel { get => _KERNEL; }
    public string Framework { get => _FRAMEWORK; }

    public void Incrementar()
    {
        _valorAtual++;
    }
}