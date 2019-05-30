using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Contexto
{
    public class TIS_VContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<TISV.Models.Equipe> Equipes { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Jogo> Jogo { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Jogador> Jogador { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Cartao> Cartao { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Falta> Falta { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Penalti> Penalti { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Escalacao> Escalacao { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Escanteio> Escanteio { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Gols> Gols { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Resultado> Resultado { get; set; }
        public System.Data.Entity.DbSet<TISV.Models.Subtituicao> Subtituicao { get; set; }

        public System.Data.Entity.DbSet<TIS_V.Models.Usuario> Usuarios { get; set; }
    }
}
