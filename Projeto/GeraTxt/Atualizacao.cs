using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaTxt
{
    public class Atualizacao
    {
        public void Executa()
        {
            var configuracao = new Configuracao();

            var executou = false;

            while (!executou)
            {
                try
                {
                     
                    executou = true;
                }
                catch (Exception exception)
                {
                    LogErro.Registrar(exception.Message); 
                }
            }
        }
    }
}
