using System;
using System.Security.Cryptography.X509Certificates;

namespace Laximo.Guayaquil.Data.Interfaces
{
    public interface ILaximoProxy : IDisposable
    {
        string QueryData(string query);

        string QueryDataLogin(string query, string login, string hmac);
        X509CertificateCollection ClientCertificates { get; }
    }
}