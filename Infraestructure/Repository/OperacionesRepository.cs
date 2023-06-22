using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using infraestructure.Model;

namespace infraestructure.Repository
{
    public class OperacionesRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;

        public OperacionesRepository(string connectionString)
        {
            this._connectionString = connectionString;  
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }


        public string depositar(double saldo ,  int id)
        {
            try
            {

                var valorSaldoAnterior = saldoActual(id);
                var valorSaldoLimite = saldoLimite(id);
                var valorDepositado = saldo;
                var valorNuevo = valorSaldoAnterior + valorDepositado;
               
                if(valorNuevo <= valorSaldoLimite)
                {
                    _ = connection.Execute($" UPDATE cuenta set " +
                   $"saldo = {valorNuevo}  " +
                   $"where id = {id}");

                    return "Deposito realizado correctamente";
                }
                else
                    return "El valor depositado supera el saldo limite de la cuenta!";
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }


        public string retirar(double valorRetirado, int id)
        {
            try
            { 
                var valorSaldoActual = saldoActual(id);
                var valoraRetirar = valorRetirado;



                if (valoraRetirar <= valorSaldoActual)
                {
                    var valorNuevo = valorSaldoActual - valoraRetirar ;

                    _ = connection.Execute($" UPDATE cuenta set " +
                   $"saldo = {valorNuevo}  " +
                   $"where id = {id}");

                    return "Retiro realizado correctamente";
                }
                else
                    return "No tiene saldo suficiente para realizar el retiro!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public double saldoActual(int id)
        {
            return connection.QuerySingle<double>($" select saldo from cuenta where id = {id}");
        }
        public double saldoLimite(int id)
        {
            return connection.QuerySingle<double>($" select saldo_limite from cuenta where id = {id}");
        }

     
    }
}
