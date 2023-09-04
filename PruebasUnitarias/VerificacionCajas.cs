using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class VerificacionCajas
    {
        [TestMethod]
        public void TraspasosGet()
        {
            using (WCF.Service1Client c  = new WCF.Service1Client())
            {
                var result = c.VerificacionCajas("079");
                if (result == null)
                    throw new ArgumentException("Error ");
            }

        }
    }
}
