using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;

namespace OpenKeySystems
{
    public class DiffieHellmanProtocol
    {
        private int _privateKey;

        public int PrivateKey => _privateKey;

        public int OpenKey => _openKey;

        public BigInteger SharedPrivateKey => _sharedPrivateKey;

        public BigInteger CrossOpenKey => _crossOpenKey;

        public int P => _p;

        public int G => _g;

        private int _openKey;
        private BigInteger _sharedPrivateKey;
        private int _crossOpenKey;
        private int _p;
        private int _g;

        public DiffieHellmanProtocol(int p, int g, int privateKey)
        {
            Reset(p, g, privateKey);
        }

        public void Reset(int p, int g, int privateKey)
        {
            SetPandG(p, g);   
            _privateKey = privateKey;
            //BigInteger.ModPow(g, _privateKey, p)

            _openKey = MulModClass.MulMod(g, _privateKey, p);
            _sharedPrivateKey = -1;
            _crossOpenKey = -1;
        }

        private void SetPandG(int p, int g)
        {
            if (PrimeCheckerClass.isPrime(p) && PrimeCheckerClass.isPrime(g))
            {
                if (PrimeCheckerClass.isPrimitiveRoot(g, p)) throw new DataException("G has to be a primitive root of P");
                _p = p;
                _g = g;
            }
            else
            {
                throw new DataException("P and G numbers have to be prime");
            }
        }

        public void CountSharedSecret(int crossOpenKey)
        {
            _crossOpenKey = crossOpenKey;
            BigInteger.ModPow(_crossOpenKey, _privateKey, _p);
            _sharedPrivateKey = MulModClass.MulMod(_crossOpenKey, _privateKey, _p);
        }
    }
}