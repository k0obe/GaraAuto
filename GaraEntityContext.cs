using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraAuto
{
    public class GaraEntityContext : DbContext
    {
        public GaraEntityContext()
            : base("GraDBConnection") { }

        public virtual DbSet<Angajat> Angajats { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Clienti_Rute> Clienti_Rute { get; set; }
        public virtual DbSet<Localitate> Localitates { get; set; }
        public virtual DbSet<Raion> Raions { get; set; }
        public virtual DbSet<Ruta> Rutas { get; set; }
        public virtual DbSet<Rutiera> Rutieras { get; set; }

    }
    public partial class Angajat
    {
        public Angajat()
        {
            this.Rutas = new HashSet<Ruta>();
        }

        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string IDNP { get; set; }
        public Nullable<System.DateTime> DataNasterii { get; set; }
        public string Gen { get; set; }
        public string Email { get; set; }
        public string NrTelefon { get; set; }
        public string Adresa { get; set; }
        public int Functia { get; set; }
        public Nullable<decimal> Salariu { get; set; }
        public string Login { get; set; }
        public string Parola { get; set; }

        public virtual ICollection<Ruta> Rutas { get; set; }
    }
    public partial class Client
    {
        public Client()
        {
            this.Clienti_Rute = new HashSet<Clienti_Rute>();
        }

        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public Nullable<System.DateTime> DataNasterii { get; set; }
        public string Gen { get; set; }
        public string Email { get; set; }
        public string NrTelefon { get; set; }
        public string Adresa { get; set; }
        public string Login { get; set; }
        public string Parola { get; set; }

        public virtual ICollection<Clienti_Rute> Clienti_Rute { get; set; }
    }
    public partial class Rutiera
    {
        public Rutiera()
        {
            this.Rutas = new HashSet<Ruta>();
        }

        public int Id { get; set; }
        public string Denumire { get; set; }
        public string Model { get; set; }
        public string Culoare { get; set; }
        public string Numar { get; set; }
        public int NumarLocuri { get; set; }
        public string Imagine { get; set; }

        public virtual ICollection<Ruta> Rutas { get; set; }
    }
    public partial class Raion
    {
        public Raion()
        {
            this.Localitates = new HashSet<Localitate>();
        }

        public int Id { get; set; }
        public string Denumire { get; set; }
        public virtual ICollection<Localitate> Localitates { get; set; }
    }
    public partial class Localitate
    {
        public Localitate()
        {
            this.Rutas = new HashSet<Ruta>();
            this.Rutas1 = new HashSet<Ruta>();
        }

        public int Id { get; set; }
        public string Denumire { get; set; }
        public int RaionId { get; set; }

        public virtual Raion Raion { get; set; }
        public virtual ICollection<Ruta> Rutas { get; set; }
        public virtual ICollection<Ruta> Rutas1 { get; set; }
    }
    public partial class Ruta
    {
        public Ruta()
        {
            this.Clienti_Rute = new HashSet<Clienti_Rute>();
        }

        public int Id { get; set; }
        public int AngajatId { get; set; }
        public int RutieraId { get; set; }
        public int LocStartId { get; set; }
        public int LocDestinatieId { get; set; }
        public System.TimeSpan OraPornire { get; set; }
        public decimal PretBilet { get; set; }

        public virtual Angajat Angajat { get; set; }
        public virtual ICollection<Clienti_Rute> Clienti_Rute { get; set; }
        public virtual Localitate Localitate { get; set; }
        public virtual Localitate Localitate1 { get; set; }
        public virtual Rutiera Rutiera { get; set; }
    }
    public partial class Clienti_Rute
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RutaId { get; set; }
        public System.DateTime Data { get; set; }
        public virtual Client Client { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
    public partial class RutaAfisare
    {
        public string Id { get; set; }
        public string Imagine { get; set; }
        public TimeSpan Ora { get; set; }
        public string Rutiera { get; set; }
        public string RutieraNumar { get; set; }
        public string RutieraCuloare { get; set; }
        public string Angajat { get; set; }
        public string LocStart { get; set; }
        public string RaionStart { get; set; }
        public string LocDestinatie { get; set; }
        public string RaionDestinatie { get; set; }
        public string Pret { get; set; }
    }
    public partial class RuteComandate
    {
        public TimeSpan Ora { get; set; }
        public string RutieraNumar { get; set; }
        public string Angajat { get; set; }
        public string LocStart { get; set; }
        public string LocDestinatie { get; set; }
        public string Pret { get; set; }
        public string Data { get; set; }
    }
}
