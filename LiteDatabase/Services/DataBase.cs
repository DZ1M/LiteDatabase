using LiteDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteDatabase.Services
{
    public class DataBase
    {
        public bool Inserir(Usuario newUser)
        {
            using (var db = new LiteDB.LiteDatabase("bancoDeDados.db"))
            {
                newUser.Id = Guid.NewGuid();
                var userCollection = db.GetCollection<Usuario>("usuarios");
                userCollection.Insert(newUser);
                return true;
            }
        }
        public List<Usuario> Listar()
        {
            using (var db = new LiteDB.LiteDatabase("bancoDeDados.db"))
            {
                var usersCollection = db.GetCollection<Usuario>("usuarios");
                return usersCollection.FindAll().ToList();
            }
        }
        public bool Excluir(Guid id)
        {
            using (var db = new LiteDB.LiteDatabase("bancoDeDados.db"))
            {
                var usersCollection = db.GetCollection<Usuario>("usuarios");
                return usersCollection.Delete(id);
            }
        }
        public Usuario BuscaPorId(Guid id)
        {
            using (var db = new LiteDB.LiteDatabase("bancoDeDados.db"))
            {
                var usersCollection = db.GetCollection<Usuario>("usuarios");
                return usersCollection.FindOne(x => x.Id == id);
            }
        }
        public bool Alterar(Usuario user)
        {
            using (var db = new LiteDB.LiteDatabase("bancoDeDados.db"))
            {
                var usersCollection = db.GetCollection<Usuario>("usuarios");
                var usuario = usersCollection.FindOne(x => x.Id == user.Id);

                if (!string.IsNullOrWhiteSpace(user.Nome))
                    usuario.Nome = user.Nome;
                if (!string.IsNullOrWhiteSpace(user.Senha))
                    usuario.Senha = user.Senha;

                return usersCollection.Update(usuario);
            }
        }
    }
}
