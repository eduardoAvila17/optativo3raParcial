using infraestructure.Model;
using infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class OperacionesServices
    {

        private OperacionesRepository operacionesRepository;
        private CuentaRepository cuentaRepository;


        public OperacionesServices(String connectionString)
        {
            this.operacionesRepository = new OperacionesRepository(connectionString);
            this.cuentaRepository = new CuentaRepository(connectionString);
        }

     


        public bool transferir()
        {
            return true;
        }

        public string depositar(double saldo, int id)
        {
            return validarNegativo(saldo) ? operacionesRepository.depositar(saldo, id) : throw new Exception("No se puede depositar un valor negativo");
        }


        public string retirar(double saldo, int id)
        {
            return validarNegativo(saldo) ? operacionesRepository.retirar(saldo, id) : throw new Exception("No se puede depositar un valor negativo");
        }

        public bool extracto()
        {
            return true;
        }



        private bool validarNegativo( double saldo )
        {
            if(saldo < 0)
            {
            return false;
            }
            return true;
        }

    }
}
