
using Microsoft.EntityFrameworkCore;

#region Veri Nasıl Silinir?
//ETicaretContext context = new();
//Urun urun=await context.Urunler.FirstOrDefaultAsync(u=>u.Id==5);
//context.Urunler.Remove(urun);
//await context.SaveChangesAsync();
#endregion

#region Silme işleminde ChangeTracker'ın Rolü
//ChangeTracker Context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır.
//Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler neticesinde Update veya Deleted sorgularının oluşturulacağı anlaşılır. 
#endregion

#region Takip edilmeyen nesneler nasıl silinir?
//ETicaretContext context = new();
//Urun u = new()
//{
//    Id = 2,
//    UrunAdi="B Ürünü",
//};
//context.Urunler.Remove(u);
//await context.SaveChangesAsync();
#endregion

#region EntityState İle Silme İşlemi
//ETicaretContext context = new();
//Urun u = new() { Id = 1 };
//context.Entry(u).State = EntityState.Deleted;
//await context.SaveChangesAsync();
#endregion

#region RemoveRange
//ETicaretContext context = new();
//List<Urun> urunler = await context.Urunler.Where(u => u.Id >= 7 && u.Id <= 9).ToListAsync();
//context.Urunler.RemoveRange(urunler);
//await context.SaveChangesAsync();
#endregion




public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = ASUS; Database = ECommerceDb; Trusted_Connection = True");
    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }

}