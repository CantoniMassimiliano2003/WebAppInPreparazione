using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using WebAppInPreparazione.Models.Entities;

namespace WebAppInPreparazione.Helpers
{
    public class DatabaseHelper
    {
        public static string ConnectionString { get; internal set; }

        public static List<Dipendente> GetAllDipendenti()
        {
            var dipendenti = new List<Dipendente>();
            using(var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM dipendenti AS d " +
                    "INNER JOIN azienda AS a ON d.IdAzienda = a.Id";
                dipendenti = db.Query<Dipendente, Azienda, Dipendente>(querySql,
                    (dipendente, azienda) =>
                    {
                        dipendente.Azienda = azienda;
                        return dipendente;
                    }
                ).ToList();
            }
            return dipendenti;
        }

        public static Dipendente GetDipendenteById(int id)
        {
            var dipendente = new Dipendente();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM dipendenti AS d " +
                    "INNER JOIN azienda AS a ON d.IdAzienda = a.Id"
                    +
                    " WHERE d.Id = @id ;";
                dipendente = db.Query<Dipendente, Azienda, Dipendente>(querySql,
                    (dipendente, azienda) =>
                    {
                        dipendente.Azienda = azienda;
                        return dipendente;
                    }
                    , new { id = id }
                ).FirstOrDefault();
            }
            return dipendente;
        }

        internal static Dipendente SaveDipendente(Dipendente model)
        {
            if(model.Id == 0)
            {
                return InsertDipendente(model);
            }
            else
            {
                return UpdateDipendente(model);
            }
        }

        private static Dipendente InsertDipendente(Dipendente model)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var sqlQuery = "INSERT INTO Dipendenti (nome,cognome,IdAzienda) " +
                    " VALUE (@nome, @cognome, @IdAzienda); " +
                    "SELECT LAST_INSERT_ID()";
                model.Id = db.Query<int>(sqlQuery, model).FirstOrDefault();
                if (model.Id > 0)
                    return model;
            }
            throw new Exception("Errore inserimento non completato");
        }

        private static Dipendente UpdateDipendente(Dipendente model)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var sqlQuery = "UPDATE dipendente SET nome=@nome, cognome=@cognome, IdAzienda=@IdAzienda WHERE id=@id ";

                var affectedRows = db.Execute(sqlQuery, model);
                if (affectedRows == 1)
                    return model;
            }
            throw new Exception("Errore inserimento non completato");
        }

        public static Azienda GetAziendaById(int id)
        {
            var azienda = new Azienda();
            using (var db= new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM azienda WHERE id = @id";
                azienda = db.Query<Azienda>(querySql, new { id = id }).FirstOrDefault();
            }

            return azienda;
        }

        public static List<Azienda> GetAllAzienda()
        {
            var aziende = new List<Azienda>();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM azienda";
                aziende = db.Query<Azienda>(querySql).ToList();
            }
            return aziende;
        }




    }
}
