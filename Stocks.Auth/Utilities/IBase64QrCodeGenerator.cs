using System;

namespace Stocks.Auth.Domain.Utilities
{
    public interface IBase64QrCodeGenerator
    {
        string Generate(Uri target);
    }
}