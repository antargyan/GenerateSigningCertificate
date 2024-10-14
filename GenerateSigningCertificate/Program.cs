using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using var algorithm = RSA.Create(keySizeInBits: 2048);
var subject = new X500DistinguishedName("CN=OpenIddict Server Signing Certificate");
var request = new CertificateRequest(subject, algorithm, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyEncipherment, critical: true));
var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(12));
File.WriteAllBytes("server-encryption-certificate.pfx", certificate.Export(X509ContentType.Pfx, "SigningP@ssw0rd"));