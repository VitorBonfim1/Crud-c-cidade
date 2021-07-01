using Microsoft.EntityFrameworkCore;
namespace crudCidade.Models
{
    public class HabitanteContexto : DbContext
    {
      public HabitanteContexto(DbContextOptions<HabitanteContexto> options):base(options)
      {
      }
         public DbSet<Habitantes> Habitantes {get; set;} 
      }  
    }
