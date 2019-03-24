using System;
using SuperHeroAPI.Common.Hash;

namespace SuperHeroAPI.EntityFramework.PreparaHash
{
    public class PreparaHash
    {
        public string RetornaSenhaCriptografada(string senha)
        {
            return new Hash(System.Security.Cryptography.SHA1.Create()).Criptografar(senha);
        }
    }
}